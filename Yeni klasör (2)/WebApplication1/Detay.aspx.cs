using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Entity;
using Core.Services;

namespace WebApplication1
{
    public partial class Detay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //Eğer Request.QueryString Boş veya null degiş ise
            if (!string.IsNullOrEmpty(Request.QueryString["ID"]))
            {
                Urun u = new UrunServis().GetUrunByID(Request.QueryString["ID"]);
                lblAciklama.Text = u.Aciklama;
                lblFiyat.Text = u.Fiyat.ToString("C");
                lblKategori.Text = u.Kategori;
                lblStokMiktari.Text = u.StokMiktari.ToString();
                lblUrunAdi.Text = u.UrunAdi;
                Image1.ImageUrl = "~/InputFiles/images/" + u.Resim;

            }
        }
        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (User.Identity.IsAuthenticated)
            {
                //Eger kullanıcı giriş yapmıs ıse  Secmıs oldugu urunu sepete ekle.
                SepetServis.SepeteEkle(Request.QueryString["ID"], TextBox1.Text);
                Response.Redirect("Default.aspx");
            }
            else
            {
                //eger kullanıcı gırıs yapmamız ıse kullanıcıyı gırıs sayfasına yonlendır.
                System.Web.Security.FormsAuthentication.RedirectToLoginPage();
            }
        }
    }
}