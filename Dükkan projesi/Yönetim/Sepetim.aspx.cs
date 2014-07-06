using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dükkan_projesi.Yönetim
{
    public partial class Sepetim : System.Web.UI.Page
    {
       protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginOlanKisi"] == null)
            {
                Response.Redirect("/Yönetim/Giriş/Login.aspx");
                return;
            }
            if (!IsPostBack)
            {
                Doldur();
            }
        }

        private void Doldur()
        {
           
            List<Model.Urun> kaynak = SQL.SepetServis.Sepetim();
            GridView1.DataSource = kaynak;
            GridView1.DataKeyNames = new string[] { "UrunID" };
            GridView1.DataBind();
            if (kaynak != null)
            {
                double toplam = 0;
                ListboxKaynak();
                foreach (Model.Urun item in kaynak)
                {
                    toplam += item.Fiyat * item.TalepMiktar;
                }
                Label1.Text = toplam.ToString();
            }
            else
            {
                Label1.Text = "0";
            }
            Labelİskonto.Text = (Convert.ToDouble(Label1.Text) * (Convert.ToDouble(TextBoxİskonto.Text) / 100)).ToString();
            LabelTotal.Text = (Convert.ToDouble(Label1.Text) - (Convert.ToDouble(Label1.Text) * (Convert.ToDouble(TextBoxİskonto.Text) / 100))).ToString();
        }

        private void ListboxKaynak()
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                ListBox a = ((ListBox)GridView1.Rows[i].Cells[4].FindControl("ListBox1"));
                for (int l = 1; l <= Convert.ToInt16(((Label)GridView1.Rows[i].FindControl("Label4")).Text); l++)
                {
                    a.Items.Add(l.ToString());
                }
                ListBox b = ((ListBox)GridView1.Rows[i].Cells[5].FindControl("ListBox2"));
                for (int l = 1; l <= Convert.ToInt16(((Label)GridView1.Rows[i].FindControl("Label3")).Text); l++)
                {
                    b.Items.Add(l.ToString());
                }
                ListBox c = ((ListBox)GridView1.Rows[i].Cells[6].FindControl("ListBox3"));
                for (int l = 1; l <= Convert.ToInt16(((Label)GridView1.Rows[i].FindControl("Label1")).Text); l++)
                {
                    c.Items.Add(l.ToString());
                }
                ListBox d = ((ListBox)GridView1.Rows[i].Cells[7].FindControl("ListBox4"));
                for (int l = 1; l <= Convert.ToInt16(((Label)GridView1.Rows[i].FindControl("Label2")).Text); l++)
                {
                    d.Items.Add(l.ToString());
                }
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SQL.SepetServis.SepetiBosalt();
            Doldur();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {
           
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int sayi = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text);

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            SQL.SepetServis.UrunAdetGuncelle(id, sayi);
            Doldur();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SQL.SepetServis.UrunKaldir(id);
            Doldur();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            List<Model.UrunVeSiparis> Siparislerim = new List<Model.UrunVeSiparis>();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                Model.UrunVeSiparis temp = new Model.UrunVeSiparis(((Label)GridView1.Rows[i].Cells[0].FindControl("Label7")).Text);
                temp.SiparisBilgisi.UrunID = Convert.ToInt16(((Label)GridView1.Rows[i].Cells[0].FindControl("Label7")).Text);
                temp.SiparisBilgisi.HasköyStok = Convert.ToInt16(((ListBox)GridView1.Rows[i].Cells[5].FindControl("ListBox1")).SelectedValue);
                temp.SiparisBilgisi.EsenbogaStok = Convert.ToInt16(((ListBox)GridView1.Rows[i].Cells[8].FindControl("ListBox4")).SelectedValue);
                temp.SiparisBilgisi.CubukStok = Convert.ToInt16(((ListBox)GridView1.Rows[i].Cells[7].FindControl("ListBox3")).SelectedValue);
                temp.SiparisBilgisi.IstanbulcadStok= Convert.ToInt16(((ListBox)GridView1.Rows[i].Cells[6].FindControl("ListBox2")).SelectedValue);
                temp.SiparisBilgisi.IstenenAdet = Convert.ToInt16(((TextBox)GridView1.Rows[i].Cells[1].FindControl("TextBox1")).Text);
                if (temp.SiparisBilgisi.IstenenAdet < (temp.SiparisBilgisi.HasköyStok + temp.SiparisBilgisi.EsenbogaStok + temp.SiparisBilgisi.CubukStok + temp.SiparisBilgisi.IstanbulcadStok))
                {
                    Label_not.Text = "Istenenden Fazla miktarda urun teslimi seçildi.";
                    Label_not.Visible = true;
                    Siparislerim = null;
                    return;
                }
                temp.SiparisBilgisi.Toplam = Convert.ToDouble(((Label)GridView1.Rows[i].Cells[4].FindControl("Label5")).Text) * temp.SiparisBilgisi.IstenenAdet;
                temp.SiparisBilgisi.IndirimliFiyat = temp.SiparisBilgisi.Toplam * (Convert.ToDouble(TextBoxİskonto.Text) / 100);
                Siparislerim.Add(temp);
            }
            if (Siparislerim == null) { Response.Redirect("/Yönetim/Giriş/Satıs.aspx"); }
            Session["SiparisSepetim"] = Siparislerim;
            Session["GenelToplam"] = LabelTotal;
            Response.Redirect("/Yönetim/Sistem/Satıs.aspx");
        }

        protected void TextBoxİskonto_TextChanged(object sender, EventArgs e)
        {
            LabelTotal.Text = (Convert.ToDouble(Label1.Text)-(Convert.ToDouble(Label1.Text) * (Convert.ToDouble(TextBoxİskonto.Text) / 100))).ToString();
            Labelİskonto.Text = (Convert.ToDouble(Label1.Text) - Convert.ToDouble(LabelTotal.Text)).ToString();
        }
        protected void LinkButton4_Click1(object sender, EventArgs e)
        {
            Session["LabelNotu"] = "İşlem İptal edilmiştir.";
        }

    }
}
