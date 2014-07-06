using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Services;

namespace WebApplication1
{
    public partial class Giris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            KullaniciServis ks = new KullaniciServis();
            ks.UyeGiris(TextBox1.Text, System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(TextBox2.Text, "SHA1"));
        }
    }
}