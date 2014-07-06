using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Entity;
using Core.Services;

namespace WebApplication1.Admin
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.Email = TextBox3.Text;
            k.Sifre = TextBox2.Text;
            k.KullaniciAdi = TextBox1.Text;
            k.Role = "Uye";
            k.KullaniciID = Guid.NewGuid().ToString();

            KullaniciServis ks = new KullaniciServis();
            ks.KullaniciEkle(k);
        }
    }
}