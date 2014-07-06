using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class MusteriIslemleri
    {
        public static SQL.SqlTanımı bag = new SQL.SqlTanımı();
        public static List<Model.MusteriBilgileri> TumMusteriler()
        {
            SqlConnection baglanti = bag.BaglantiAl();
            string Query = "Select * From Musteriler Order By ID";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = Query;
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return null;//
            }
            List<Model.MusteriBilgileri> Musteriler = new List<Model.MusteriBilgileri>();
            while (reader.Read())
            {
                Model.MusteriBilgileri musterim = new Model.MusteriBilgileri();
                musterim.AdSoyad = reader["AdSoyad"].ToString();
                musterim.ID = Convert.ToInt32(reader["ID"]);
                musterim.Adres = reader["Adres"].ToString();
                musterim.TcNo = reader["TcNo"].ToString();
                musterim.TelNo = reader["TelNo"].ToString();
                musterim.VergiDairesi = reader["TelNo"].ToString();
                musterim.VergiNo = reader["vergiNo"].ToString() ;
                Musteriler.Add(musterim);
            }
            baglanti.Close();
            return Musteriler;
        }
        public static Model.MusteriBilgileri MusteriBilgileriAl(int ID) 
        {
            SqlConnection baglanti = bag.BaglantiAl();
            string Query = "Select * from Musteriler Where ID=@ID";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText=Query;
            SqlParameter Id = new SqlParameter("@ID", SqlDbType.Int);
            Id.Value = ID;
            komut.Parameters.Add(Id);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Model.MusteriBilgileri musterim = new Model.MusteriBilgileri();
                musterim.AdSoyad = reader["AdSoyad"].ToString();
                musterim.ID = Convert.ToInt32(reader["ID"]);
                musterim.Adres = reader["Adres"].ToString();
                musterim.TcNo = reader["TcNo"].ToString();
                musterim.TelNo = reader["TelNo"].ToString();
                musterim.VergiDairesi = reader["TelNo"].ToString();
                musterim.VergiNo = reader["vergiNo"].ToString();
                baglanti.Close();
                return musterim;
            }
            baglanti.Close();
            return null;
        }
        public static int MusteriBilgisiGüncelle(string ID,string İsimSoyisim ,string TcNo,string Adres,string TelNo,string VergiAdresi,string VergiNo)
        {
            SqlConnection baglanti = bag.BaglantiAl();
            SqlCommand Komut = baglanti.CreateCommand();
            string Query =" ";
            if (MusteriBilgileriAl(Convert.ToInt32(ID)) != null)
            {
                Query = "UPDATE Musteriler SET Adres=@ADR, TelNo=@TELNO,VergiDairesi=@VERGİDAİRESİ,vergiNo=@VERGİNO WHERE ID=@ıd";
                Komut.CommandText = Query;
                SqlParameter telno = new SqlParameter("@TELNO", SqlDbType.NChar);
                telno.Value = TelNo;
                SqlParameter adres = new SqlParameter("@ADR", SqlDbType.NVarChar);
                adres.Value = Adres;
                SqlParameter vergidairesi = new SqlParameter("@VERGİDAİRESİ", SqlDbType.NVarChar);
                vergidairesi.Value = VergiAdresi;
                SqlParameter vergino = new SqlParameter("@VERGİNO", SqlDbType.Int);
                vergino.Value = VergiNo;
                SqlParameter IDM = new SqlParameter("@ıd", SqlDbType.Int);
                IDM.Value = ID;
                Komut.Parameters.Add(telno);
                Komut.Parameters.Add(adres);
                Komut.Parameters.Add(vergidairesi);
                Komut.Parameters.Add(vergino);
                Komut.Parameters.Add(IDM);
                Komut.ExecuteReader();
                baglanti.Close();
                return (Convert.ToInt32(ID));
            }
            return(MusterilereEkle(İsimSoyisim,TcNo, Adres, TelNo, VergiAdresi, VergiNo));
        }
        public static int MusterilereEkle(string İsimSoyisim, string TcNo, string Adres, string TelNo, string VergiAdresi, string VergiNo)
        {
            SqlConnection baglanti = bag.BaglantiAl();
            string Query = "INSERT INTO Musteriler VALUES (@ADSOYAD,@TELNO,@ADR,@VergiDairesi,@VERGİNO,@TCNO)";
            SqlCommand Komut = baglanti.CreateCommand();
            Komut.CommandText = Query;
            SqlParameter teln = new SqlParameter("@TELNO", SqlDbType.NChar);
            teln.Value = TelNo;
            SqlParameter adre = new SqlParameter("@ADR", SqlDbType.NVarChar);
            adre.Value = Adres;
            SqlParameter vergidaires = new SqlParameter("@VergiDairesi", SqlDbType.NVarChar);
            vergidaires.Value = VergiAdresi;
            SqlParameter vergin = new SqlParameter("@VERGİNO", SqlDbType.NVarChar);
            vergin.Value = VergiNo;
            SqlParameter AdıSoyadı = new SqlParameter("@ADSOYAD", SqlDbType.NVarChar);
            AdıSoyadı.Value = İsimSoyisim;
            SqlParameter TC = new SqlParameter("@TCNO", SqlDbType.NVarChar);
            TC.Value =TcNo;
            Komut.Parameters.Add(teln);
            Komut.Parameters.Add(adre);
            Komut.Parameters.Add(vergidaires);
            Komut.Parameters.Add(vergin);
            Komut.Parameters.Add(AdıSoyadı);
            Komut.Parameters.Add(TC);
            Komut.ExecuteReader();
            baglanti.Close();
            baglanti = bag.BaglantiAl();
            string query = "SELECT ID FROM Musteriler Where AdSoyad=@ADSOYA AND TcNo=@TCN AND TelNo=@TELN";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = query;
            SqlParameter AdıSoyad = new SqlParameter("@ADSOYA", SqlDbType.NVarChar);
            AdıSoyad.Value = İsimSoyisim;
            SqlParameter T = new SqlParameter("@TCN", SqlDbType.NChar);
            T.Value = TcNo;
            SqlParameter tel = new SqlParameter("@TELN", SqlDbType.NChar);
            tel.Value = TelNo;
            komut.Parameters.Add(AdıSoyad);
            komut.Parameters.Add(T);
            komut.Parameters.Add(tel);
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return -1;//
            }
            while (reader.Read())
            { 
               return(Convert.ToInt32(reader["ID"])); 
            }
            return -1;
        }

    }
}