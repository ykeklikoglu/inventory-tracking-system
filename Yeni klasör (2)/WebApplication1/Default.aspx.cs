using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Entity;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Core.Services.UrunServis us = new Core.Services.UrunServis();
                Repeater1.DataSource = us.UrunListesi();
                Repeater1.DataBind();
            }
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //Secılı olan urunun detayına yönlendırç
            LinkButton lnk = e.Item.FindControl("lnkDetay") as LinkButton;
            Response.Redirect("Detay.aspx?ID=" + lnk.CommandArgument);

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Core.Services.UrunServis us = new Core.Services.UrunServis();
            Repeater1.DataSource = us.UrunAra(TextBox1.Text);
            Repeater1.DataBind();
        }
    }
}