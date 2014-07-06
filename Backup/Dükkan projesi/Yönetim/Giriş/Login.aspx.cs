using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dükkan_projesi.Yönetim.Giriş
{
    public partial class Login : System.Web.UI.Page
    {
        public SQL.SqlBaglantı pservis = new SQL.SqlBaglantı();
        public Model.Person kisi = new Model.Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            Application.Lock();
            Application["visit"] = Convert.ToInt16(Application["visit"]) + 1;
            Application.UnLock();
            Label_visits.Text = Convert.ToString(Application["visit"]);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (kulanıcıadı.Text.Length < 4 || şifre.Text.Length < 4)
            { uyarı.Visible = true; return; }
            uyarı.Visible = false;
            kisi=pservis.LoginOlanKisi(kulanıcıadı.Text, şifre.Text);
            if (kisi == null)
            {
                uyarı.Visible = true;
            }
            if (kisi != null) {
                Session["loginOlanKisi"] = kisi;
                Response.Redirect("/Yönetim/Sistem/Masaüstü.aspx");
            }
            return;
        }
    }
    
}