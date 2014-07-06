using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.Yönetim.Sistem
{
    public partial class Satıs : System.Web.UI.Page
    {
        public static List<int> Güncellenecekler = new List<int>();
        public static int Guncellenecek = 1;
        public List<Model.UrunVeSiparis> kaynak = new List<Model.UrunVeSiparis>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Takvimim"] != null)
            {
                Calendar1.SelectedDate = Convert.ToDateTime(Session["Takvimim"]);
            }
            if (Session["loginOlanKisi"] == null)
            {
                Response.Redirect("/Yönetim/Giriş/Login.aspx");
                return;
            }
            if (Session["GirilenBilgiler"] != null)
            {
                DegistirilemezEyle(((Model.MusteriBilgileri)Session["GirilenBilgiler"]));
            }
            if (!IsPostBack)
            {
                Doldur();
                if (Session["GenelToplam"] != null)
                {
                    Label3.Text = ((Label)Session["GenelToplam"]).Text;
                }
                DropDownList1.Items.Add(((Model.Person)Session["loginOlanKisi"]).İsim + " " + ((Model.Person)Session["loginOlanKisi"]).Soyisim);
            }

        }
        /*void GridviewDataBind(int Harf)
        {
            SQL.SqlTanımı bag = new SQL.SqlTanımı();

            bool m;
            do
            {
                SqlConnection Cnn = bag.BaglantiAl();
                string SqlQuery = "SELECT ID, AdSoyad FROM Musteriler WHERE AdSoyad LIKE '" + Convert.ToChar(Harf) + "%' ORDER BY Adsoyad";
                SqlCommand Cmd = new SqlCommand(SqlQuery, Cnn);
                SqlDataReader Dr = Cmd.ExecuteReader();
                GridView3.DataSource = Dr;
                GridView3.DataBind();
                m = !Dr.HasRows;
                Cnn.Close();
                Harf++;
            } while (m && Harf <= Convert.ToInt16('Z'));

        }*/
        void GridviewDataBind(string sorgu)
        {
            SQL.SqlTanımı bag = new SQL.SqlTanımı();
            SqlConnection Cnn = bag.BaglantiAl();
            string SqlQuery = "SELECT ID, AdSoyad FROM Musteriler WHERE AdSoyad LIKE '" + sorgu + "%' ORDER BY Adsoyad";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cnn);
            SqlDataReader Dr = Cmd.ExecuteReader();
            GridView3.DataSource = Dr;
            GridView3.DataBind();
            Cnn.Close();

        }
        /*protected void GridView3_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Footer)
            {
                e.Row.Cells.Clear();
                TableCell Tc = new TableCell();
                e.Row.Cells.Add(Tc);
                LinkButton Lbtn;
                for (byte X = 65; X <= 90; X++)
                {
                    Lbtn = new LinkButton();
                    Lbtn.Text = Convert.ToChar(X).ToString();
                    Lbtn.CommandName = "HarfGonder";
                    Lbtn.CommandArgument = Convert.ToChar(X).ToString();
                    Tc.Controls.Add(Lbtn);
                    Tc.Controls.Add(new LiteralControl(" "));
                }
            }
        }//GridView1_RowCreated  */

        /*protected void GridView3_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "HarfGonder")
                GridviewDataBind(Convert.ToInt16(Convert.ToChar(e.CommandArgument)));
        }//GridView1_RowCommand  */

        private void Doldur()
        {
            if (Session["SiparisSepetim"] != null)
            {

                kaynak = (List<Model.UrunVeSiparis>)Session["SiparisSepetim"];

            }
            GridviewDose temp = new GridviewDose();
            GridView1.DataSource = temp.Doseme(kaynak);
            GridView1.DataKeyNames = new string[] { "UrunID" };
            GridView1.DataBind();
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                if (((Label)(GridView1.Rows[i].Cells[4].FindControl("Label1"))).Text != "0" ||
                    ((Label)(GridView1.Rows[i].Cells[6].FindControl("Label2"))).Text != "0" ||
                    ((Label)(GridView1.Rows[i].Cells[8].FindControl("Label3"))).Text != "0" ||
                    ((Label)(GridView1.Rows[i].Cells[10].FindControl("Label4"))).Text != "0")
                {
                    GridView1.Rows[i].BackColor = System.Drawing.Color.WhiteSmoke;
                    Güncellenecekler.Add(i);
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            TextBox_isim.Text = TextBox_isim.Text.ToUpper();
            if (TextBox_isim.Text == "" && TextBox_TcNo.Text == "")
            {
                Label7.Text = "Müsteri Adı Soyadı veya TcNo kutularını doldurunuz.";
                Label7.Visible = true;
                return;
            }
            if (Session["SiparisSepetim"] == null)
            {
                Label7.Text = "Siparis Sepeti Boş";
                Label7.Visible = true;
                return;
            }

            if (Guncellenecek == 1)
            {
                TextBox_ID.Text = (SQL.MusteriIslemleri.MusteriBilgisiGüncelle(TextBox_ID.Text, TextBox_isim.Text, TextBox_TcNo.Text, TextBox_adres.Text, TextBox_TelNo.Text, TextBox_VergiAdrs.Text, TextBox_VergiNo.Text)).ToString();
            }
            if (Guncellenecek == 0)
            {
                SQL.MusteriIslemleri.MusterilereEkle(TextBox_isim.Text, TextBox_TcNo.Text, TextBox_adres.Text, TextBox_TelNo.Text, TextBox_VergiAdrs.Text, TextBox_VergiNo.Text);
            }
            if (Güncellenecekler.Count > 0)
            {

                for (int i = 0; i < Güncellenecekler.Count; i++)
                {
                    SQL.Stokİslemleri.StoklarıGuncelleByID(
                        Convert.ToInt16(((Label)GridView1.Rows[Güncellenecekler[i]].Cells[0].FindControl("Label5")).Text),
                        Convert.ToInt16(((Label)GridView1.Rows[Güncellenecekler[i]].Cells[6].FindControl("Label2")).Text),
                        Convert.ToInt16(((Label)GridView1.Rows[Güncellenecekler[i]].Cells[8].FindControl("Label3")).Text),
                        Convert.ToInt16(((Label)GridView1.Rows[Güncellenecekler[i]].Cells[10].FindControl("Label4")).Text),
                        Convert.ToInt16(((Label)GridView1.Rows[Güncellenecekler[i]].Cells[4].FindControl("Label1")).Text));
                }
            }
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                List<Model.SipariseKalan> Kalan = new List<Model.SipariseKalan>();
                if ((((Label)GridView1.Rows[i].Cells[13].FindControl("Label6")).Text) != "0")
                {
                    Model.SipariseKalan gec = new Model.SipariseKalan();
                    gec.IstenenAdet = Convert.ToInt16(((Label)GridView1.Rows[i].Cells[13].FindControl("Label6")).Text);
                    gec.UrunID = Convert.ToInt16(((Label)GridView1.Rows[i].Cells[0].FindControl("Label5")).Text);
                    gec.MusteriIsimSoyisim = TextBox_isim.Text;
                    gec.MusteriID = Convert.ToInt32(TextBox_ID.Text);
                    gec.SatısTipi = DropDownList2.SelectedItem.Text;
                    gec.SiparisTarihi = DateTime.Today.ToShortDateString();
                    gec.TeslimTarihi = Calendar1.SelectedDate.ToShortDateString();
                    gec.SiparisNotu = TextBox5.Text;
                    SQL.Siparisİsleri.SiparisKaydet(gec);
                }
            }
            Session["LabelNotu"] = "İşlem gerçekleşmiştir.";
            Session["Takvimim"] = null;
            Session["SiparisSepetim"] = null;
            Session["GenelToplam"] = null;
            Session["GirilenBilgiler"] = null;
            Response.Redirect("/Yönetim/Sistem/Masaüstü.aspx");
        }
        private void DegistirilemezEyle(Model.MusteriBilgileri musterim)
        {
            TextBox_ID.Text = musterim.ID.ToString();
            TextBox_isim.Text = musterim.AdSoyad.ToString();
            TextBox_isim.ReadOnly = true;
            TextBox_TcNo.Text = musterim.TcNo.ToString();
            TextBox_TcNo.ReadOnly = true;
            TextBox_adres.Text = musterim.Adres.ToString();
            TextBox_adres.ReadOnly = true;
            TextBox_TelNo.Text = musterim.TelNo.ToString();
            TextBox_TelNo.ReadOnly = true;
            TextBox_VergiAdrs.Text = musterim.VergiDairesi != null ? musterim.VergiDairesi.ToString() : string.Empty;//(obj != null ? obj).tostring();
            TextBox_VergiAdrs.ReadOnly = true;
            TextBox_VergiNo.Text = musterim.VergiNo != null ? musterim.VergiNo.ToString() : string.Empty;
            TextBox_VergiNo.ReadOnly = true;
            Button_güncelle.Visible = true;
            Button_Sıfırla.Visible = true;
            Calendar1.SelectedDate.Equals(Session["Takvimim"]);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            DegisebilirEyle();
            Guncellenecek = 1;
        }

        private void DegisebilirEyle()
        {
            TextBox_adres.ReadOnly = false;
            TextBox_TelNo.ReadOnly = false;
            TextBox_TcNo.ReadOnly = false;
            TextBox_VergiAdrs.ReadOnly = false;
            TextBox_VergiNo.ReadOnly = false;
            Button_güncelle.Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox_isim.Text != "")
            {
                GirileriHatırla();
            }
            Response.Redirect("~/Yönetim/Sepetim.aspx");

        }

        private void GirileriHatırla()
        {
            Model.MusteriBilgileri input = new Model.MusteriBilgileri();
            if (TextBox_ID.Text != "")
                input.ID = Convert.ToInt32(TextBox_ID.Text);
            input.AdSoyad = TextBox_isim.Text;
            if (TextBox_adres.Text != "")
                input.Adres = TextBox_adres.Text;
            if (TextBox_TcNo.Text != "")
                input.TcNo = TextBox_TcNo.Text;
            if (TextBox_TelNo.Text != "")
                input.TelNo = TextBox_TelNo.Text;
            if (TextBox_VergiAdrs.Text != "")
                input.VergiDairesi = TextBox_VergiAdrs.Text;
            if (TextBox_VergiNo.Text != "")
                input.VergiNo = TextBox_VergiNo.Text;
            Session["GirilenBilgiler"] = input;
            Session["Takvimim"] = Calendar1.SelectedDate.ToString();
        }

        protected void Button_Sıfırla_Click(object sender, EventArgs e)
        {
            Guncellenecek = 1;
            TextBox_adres.Text = string.Empty;
            TextBox_ID.Text = string.Empty;
            TextBox_isim.Text = string.Empty;
            TextBox_TcNo.Text = string.Empty;
            TextBox_TelNo.Text = string.Empty;
            TextBox_VergiAdrs.Text = string.Empty;
            TextBox_VergiNo.Text = string.Empty;
            DegisebilirEyle();
            TextBox_isim.ReadOnly = false;
            TextBox_TcNo.ReadOnly = false;
            Button_Sıfırla.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Session["LabelNotu"] = "İşlem İptal edilmiştir.";
            Session["SiparisSepetim"] = null;
            Session["Takvimim"] = null;
            Session["GenelToplam"] = null;
            Session["GirilenBilgiler"] = null;
            Response.Redirect("/Yönetim/Sistem/Masaüstü.aspx");
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            if (Calendar1.SelectedDate < DateTime.Today)
            {
                Label_takvim.Visible = true;
                Calendar1.SelectedDate = DateTime.Today;
                return;
            }
            Label_takvim.Visible = false;
            Session["Takvimim"] = Calendar1.SelectedDate.ToString();
        }

        protected void GridView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            Model.MusteriBilgileri musterim = new Model.MusteriBilgileri();
            musterim = SQL.MusteriIslemleri.MusteriBilgileriAl(Convert.ToInt32(GridView3.SelectedDataKey.Value));
            DegistirilemezEyle(musterim);
            Guncellenecek = 0;
            GridView3.Visible = false;
        }

       /*protected void _Click(object sender, EventArgs e)
        {
            Button_TamamTıklama++;
            if (Button_TamamTıklama % 2 == 0) { GridView3.Visible = false; }
            else
            {
                GridviewDataBind(Convert.ToInt16('A'));
                GridView3.Visible = true;
            }
        }*/

        protected void TextBox_isim_TextChanged(object sender, EventArgs e)
        {
            GridviewDataBind(TextBox_isim.Text);
            GridView3.Visible = true;
        }

    }
    public class GridviewDose
    {
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public int TalepMiktar { get; set; }
        public int StokCubuk { get; set; }
        public int CubukStok { get; set; }
        public int Stokİstcad { get; set; }
        public int IstanbulcadStok { get; set; }
        public int StokHasköy { get; set; }
        public int HasköyStok { get; set; }
        public int StokEsenboga { get; set; }
        public int EsenbogaStok { get; set; }
        public int SipariseGecen { get; set; }
        public double Fiyat { get; set; }
        public double Toplam { get; set; }
        public List<GridviewDose> Doseme(List<Model.UrunVeSiparis> Ana)
        {
            List<GridviewDose> anakaynak = new List<GridviewDose>();

            for (int i = 0; i < Ana.Count; i++)
            {
                GridviewDose temp = new GridviewDose();
                temp.UrunID = Ana[i].Urunbilgisi.UrunID;
                temp.UrunAd = Ana[i].Urunbilgisi.UrunAd;
                temp.TalepMiktar = Ana[i].SiparisBilgisi.IstenenAdet;
                temp.StokCubuk = Ana[i].Urunbilgisi.StokCubuk;
                temp.CubukStok = Ana[i].SiparisBilgisi.CubukStok;
                temp.StokHasköy = Ana[i].Urunbilgisi.Stokİstcad;
                temp.HasköyStok = Ana[i].SiparisBilgisi.HasköyStok;
                temp.Stokİstcad = Ana[i].Urunbilgisi.Stokİstcad;
                temp.IstanbulcadStok = Ana[i].SiparisBilgisi.IstanbulcadStok;
                temp.StokEsenboga = Ana[i].Urunbilgisi.StokEsenboga;
                temp.EsenbogaStok = Ana[i].SiparisBilgisi.EsenbogaStok;
                temp.Fiyat = Ana[i].Urunbilgisi.Fiyat;
                temp.Toplam = Ana[i].SiparisBilgisi.IstenenAdet * Ana[i].Urunbilgisi.Fiyat;
                temp.SipariseGecen = temp.TalepMiktar - (temp.CubukStok + temp.HasköyStok + temp.IstanbulcadStok + temp.EsenbogaStok);
                anakaynak.Add(temp);
            }
            return (anakaynak);
        }
    }
}