using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class UserControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Page.User.Identity.IsAuthenticated && Page.User.IsInRole("Admin"))
            {
                MultiView1.ActiveViewIndex = 2;
            }
            else if (Page.User.Identity.IsAuthenticated)
            {
                MultiView1.ActiveViewIndex = 1;
            }
            else
            {
                MultiView1.ActiveViewIndex = 0;
            }

            Label1.Text = Page.User.Identity.Name;
            Label2.Text = Page.User.Identity.Name;

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            System.Web.Security.FormsAuthentication.SignOut();
            System.Web.Security.FormsAuthentication.RedirectToLoginPage();
        }
    }
}