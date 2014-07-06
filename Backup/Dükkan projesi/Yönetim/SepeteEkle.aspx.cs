using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dükkan_projesi.Yönetim
{
    public partial class SepeteEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Doldur();
            }

        }
        private void Doldur()
        {
            List<Model.Urun> kaynak = SQL.UrunServis.UrunListesi();
            GridView1.DataSource = kaynak;
            GridView1.DataKeyNames = new string[] {"UrunID" };
            GridView1.DataBind();
        }


        protected void Button_tamamla_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                GridViewRow row = GridView1.Rows[i];
                //CheckBox a = ((CheckBox)row.FindControl("CheckBox1"));
                //bool isChecked = a.Checked;
                if (/*isChecked &&*/ Convert.ToInt16(((TextBox)row.FindControl("TextBox_Adet")).Text) > 0)
                {
                    SQL.SepetServis.SepeteEkle(GridView1.Rows[i].Cells[0].Text, ((TextBox)row.FindControl("TextBox_Adet")).Text);
                }
                else if (/*isChecked &&*/ Convert.ToInt16(((TextBox)row.FindControl("TextBox_Adet")).Text) < 0)
                {
                    Label_Uyarı.Text = "Eklenecek Ürün Adeti Negatif Girildi.";
                    Label_Uyarı.Visible = true;
                    return;
                }
            }
            Response.Redirect("/Yönetim/Sepetim.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.Trim() != "Ürün İsmini Giriniz." && TextBox1.Text.Trim()!="")
            {
                List<Model.Urun> kaynak = SQL.UrunServis.SQLSorguluUrunListele(TextBox1.Text.Trim());
                GridView1.DataSource = kaynak;
                GridView1.DataKeyNames = new string[] { "UrunID" };
                GridView1.DataBind();
            }
            else { Doldur(); }
        }


    }
}