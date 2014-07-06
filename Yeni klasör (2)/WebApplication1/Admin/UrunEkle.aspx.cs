using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.Services;
using Core.Entity;

namespace WebApplication1.Admin
{
    public partial class UrunEkle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            KategorileriDoldur();
        
        
        }
        void KategorileriDoldur()
        {
            KategoriServis s = new KategoriServis();
            DropDownList1.DataTextField = "KategoriAdi";
            DropDownList1.DataValueField = "KategoriAdi";
            DropDownList1.DataSource = s.KategoriListesi();
            DropDownList1.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            if (FileUpload1.HasFile)//Eğer FileUpload Resme Sahipse
            {

                string KlasorAdresi = Server.MapPath("~/InputFiles/images/");
                string BenzersizResimAdi = Guid.NewGuid() + FileUpload1.FileName;
                //Resmi Kaydet
                FileUpload1.SaveAs(KlasorAdresi + BenzersizResimAdi);


                Urun u = new Urun();
                u.Aciklama = txtAciklama.Text;
                u.Fiyat = Convert.ToDecimal(txtFiyat.Text);
                u.Kategori = DropDownList1.Text;
                u.Resim = BenzersizResimAdi;
                u.StokMiktari = Convert.ToByte(txtStokMiktari.Text);
                u.UrunAdi = txtUrunAdi.Text;
                u.UrunID = Guid.NewGuid().ToString();


                UrunServis us = new UrunServis();
                bool durum = us.Ekle(u);

                if (durum)//Eğer kayıt eklenmiş ise MultiView içerisinden Sonu VieW'ini göster
                    MultiView1.ActiveViewIndex = 1;


            }
            else
            {
                lblMesaj.Text = "Lütfen Ürün Resmi Belirleyiniz...";
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            MultiView1.ActiveViewIndex = 0;
        }
    }
}