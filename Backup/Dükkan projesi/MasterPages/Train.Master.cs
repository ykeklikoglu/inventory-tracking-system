using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dükkan_projesi.MasterPages
{
    public partial class Train : System.Web.UI.MasterPage
    {
        Model.Person Personelim = new Model.Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginOlanKisi"] == null)
            {
                Response.Redirect("/Yönetim/Giriş/Login.aspx");
                return;
            }
            Personelim = (Model.Person)Session["loginOlanKisi"];
            LoginOlanKisi.Text = Personelim.İsim + " " + Personelim.Soyisim;
        }
    }
}