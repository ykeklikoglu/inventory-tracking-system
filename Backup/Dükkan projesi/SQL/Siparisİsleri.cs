using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class Siparisİsleri
    {
        public static SQL.SqlTanımı bag = new SQL.SqlTanımı();
        public static string SiparisKaydet(Model.SipariseKalan kalan)
        {
            SqlConnection baglanti = bag.BaglantiAl();
            string query = @"Insert into Siparisler (UrunID,MusteriID,IstenenAdet,MusteriIsimSoyisim,SatısTipi,SiparisTarihi,TeslimTarihi,SiparisNotu) 
            VALUES(@ID,@MusteriID,@Adet,@isim,@tipi,@siparistarihi,@teslimTarihi,@SiparisNotu)";
            //string query =@"INSERT INTO TabloAdı (Alan1, Alan2, ...) VALUES ("Değer1", "Değer2", ...);
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = query;
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = kalan.UrunID;
            SqlParameter MID = new SqlParameter("@MusteriID", SqlDbType.Int);
            MID.Value = kalan.MusteriID;
            SqlParameter Adet = new SqlParameter("@Adet", SqlDbType.Int);
            Adet.Value = kalan.IstenenAdet;
            SqlParameter İsimSoyisim = new SqlParameter("@İsim", SqlDbType.NVarChar);
            İsimSoyisim.Value = kalan.MusteriIsimSoyisim;
            SqlParameter Tipi = new SqlParameter("@tipi", SqlDbType.NChar);
            Tipi.Value=kalan.SatısTipi;
            SqlParameter SiparisTarihi = new SqlParameter("@siparistarihi", SqlDbType.DateTime);
            SiparisTarihi.Value = kalan.SiparisTarihi;
            SqlParameter TeslimTarihi = new SqlParameter("@teslimTarihi", SqlDbType.DateTime);
            TeslimTarihi.Value = kalan.TeslimTarihi;
            SqlParameter SiparisNotu = new SqlParameter("@SiparisNotu", SqlDbType.Text);
            SiparisNotu.Value = kalan.SiparisNotu;
            komut.Parameters.Add(ID);
            komut.Parameters.Add(MID);
            komut.Parameters.Add(Adet);
            komut.Parameters.Add(İsimSoyisim);
            komut.Parameters.Add(Tipi);
            komut.Parameters.Add(SiparisTarihi);
            komut.Parameters.Add(TeslimTarihi);
            komut.Parameters.Add(SiparisNotu);
            komut.ExecuteReader();
            baglanti.Close();
            return ("Siparişlere Başarı ile eklenmiştir");
        }
    }
}