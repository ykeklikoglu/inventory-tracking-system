using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class SqlBaglantı
    {
        public SQL.SqlTanımı pservis=new SQL.SqlTanımı();
        public Model.Person PesonelId(int PersonelId)
        {

            Model.Person Personelim = new Model.Person();
            SqlConnection Baglanti = pservis.BaglantiAl();
            string query = (@"SELECT * FROM Personeller WHERE ID=@ID");
            SqlCommand Komut = Baglanti.CreateCommand();
            Komut.CommandText = query;
            SqlParameter Id = new SqlParameter("@ID", SqlDbType.Int);
            Id.Value = PersonelId;
            Komut.Parameters.Add(Id);
            SqlDataReader reader = Komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                Baglanti.Close();
                return null;//
            }
            while (reader.Read())
            {
                #region okunan bilgileri LoginOlanPersonel yapisina tek tek kaydetme bolumu
                Personelim.ID = PersonelId;
                Personelim.İsim = reader["İsim"].ToString();
                Personelim.Soyisim = reader["Soyisim"].ToString();
                Personelim.Tc_No=reader["TcNo"].ToString();
                Personelim.KullanıcıAdı=reader["KullanıcıAdı"].ToString();
                Personelim.Şifre = reader["Şifre"].ToString();
                Personelim.Email = reader["Email"].ToString();
                Personelim.Cinsiyet = reader["Cinsiyet"].ToString();
                #endregion
            }
            Baglanti.Close();
            return (Personelim);
        }
        public Model.Person LoginOlanKisi(string KullanıcıAdı, string Sifre)
        {

            Model.Person Personelim = new Model.Person();
            SqlConnection Baglanti = pservis.BaglantiAl();
            string query = (@"SELECT * FROM Personeller WHERE KullanıcıAdı=@Kulad and Şifre=@sfr");
            SqlCommand Komut = Baglanti.CreateCommand();
            Komut.CommandText = query;
            SqlParameter kulad = new SqlParameter("@Kulad", SqlDbType.NVarChar);
            kulad.Value = KullanıcıAdı;
            Komut.Parameters.Add(kulad);
            SqlParameter sifrem = new SqlParameter("@sfr", SqlDbType.NVarChar);
            sifrem.Value = Sifre;
            Komut.Parameters.Add(sifrem);
            SqlDataReader reader = Komut.ExecuteReader(); 
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                Baglanti.Close();
                return null;//
            }
            while (reader.Read())
            {
                #region okunan bilgileri LoginOlanPersonel yapisina tek tek kaydetme bolumu
                Personelim.ID =Convert.ToInt16( reader["ID"]);
                Personelim.İsim = reader["İsim"].ToString();
                Personelim.Soyisim = reader["Soyisim"].ToString();
                Personelim.Tc_No = reader["TcNo"].ToString();
                Personelim.KullanıcıAdı = reader["KullanıcıAdı"].ToString();
                Personelim.Şifre = reader["Şifre"].ToString();
                Personelim.Email = reader["Email"].ToString();
                Personelim.Cinsiyet = reader["Cinsiyet"].ToString();
                #endregion
            }
            Baglanti.Close();
            return (Personelim);
        }
    }
}