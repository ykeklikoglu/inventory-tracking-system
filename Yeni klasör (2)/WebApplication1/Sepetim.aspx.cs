using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Services;
using Core.Entity;

namespace WebApplication1
{
    public partial class Sepetim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Doldur();
            }
        }

        private void Doldur()
        {
            List<Urun> kaynak = SepetServis.Sepetim();
            GridView1.DataSource = kaynak;
            GridView1.DataKeyNames = new string[] { "UrunID" };
            GridView1.DataBind();
            if (kaynak != null)
            {
                decimal toplam = 0;
                foreach (Urun item in kaynak)
                {
                    toplam += item.Fiyat * item.TalepMiktar;
                }
                Label1.Text = toplam.ToString("C");
            }
            else
            {
                Label1.Text = "";
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            SepetServis.SepetiBosalt();
            Doldur();
        }

        protected void LinkButton1_Command(object sender, CommandEventArgs e)
        {

        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int sayi = Convert.ToInt32((GridView1.Rows[e.RowIndex].FindControl("TextBox1") as TextBox).Text);

            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();

            SepetServis.UrunAdetGuncelle(id, sayi);
            Doldur();



        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string id = GridView1.DataKeys[e.RowIndex].Value.ToString();
            SepetServis.UrunKaldir(id);
            Doldur();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            SepetServis.SepetiOnayla();
            Doldur();
        }
    }
}