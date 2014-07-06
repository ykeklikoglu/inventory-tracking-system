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
    public partial class Siparişler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                GridviewDataBind("A");
        }//Page_Load  

        void GridviewDataBind(string Harf)
        {
            string CnnStr = @"Data Source=Keklikoğlu-PC;Initial Catalog=Projem;User ID=sa;
            Password=123;Integrated Security=True";
            SqlConnection Cnn = new SqlConnection(CnnStr);
            string SqlQuery = "sSELECT  AdSoyad FROM Musteriler WHERE AdSoyad LIKE '" + Harf + "%' ORDER BY Adsoyad";
            SqlCommand Cmd = new SqlCommand(SqlQuery, Cnn);
            Cnn.Open();
            SqlDataReader Dr = Cmd.ExecuteReader(CommandBehavior.CloseConnection);
            GridView1.DataSource = Dr;
            GridView1.DataBind();
        }
        protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
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
        }//GridView1_RowCreated  

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "HarfGonder")
                GridviewDataBind(e.CommandArgument.ToString());
        }//GridView1_RowCommand  
    }
}