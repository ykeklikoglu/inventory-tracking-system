using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dükkan_projesi.Yönetim.Sistem
{
    public partial class Masaüstü : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["SiparisSepetim"] = null;
            Session["GenelToplam"] = null;
            Session["GirilenBilgiler"] = null;
            if (Session["LabelNotu"] != null)
            {
                Label1.Text = Session["LabelNotu"].ToString();
                Label1.Visible = true;
            }

        }
    }
}