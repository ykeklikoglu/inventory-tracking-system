using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class PersonelIsleri
    {
        public static SQL.SqlTanımı bag = new SQL.SqlTanımı();
        public static List<Model.Person> TumPersonel()
        {
            List<Model.Person> tumPersoneller = new List<Model.Person>();

            SqlConnection baglanti = bag.BaglantiAl();


            string query = "SELECT * FROM Personeller  ORDER BY İsim";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = query;
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                Model.Person yeniPersonel = new Model.Person();
                yeniPersonel.ID = Convert.ToInt16(reader["Id"]);
                yeniPersonel.İsim = reader["İsim"].ToString();
                yeniPersonel.Soyisim = reader["Soyisim"].ToString();
                yeniPersonel.KullanıcıAdı = reader["KullanıcıAdı"].ToString();
                yeniPersonel.Şifre = reader["Şifre"].ToString();
                yeniPersonel.Tc_No = reader["TcNo"].ToString();
                tumPersoneller.Add(yeniPersonel);
            }

            baglanti.Close();

            return tumPersoneller;
        }
        public static Model.Person GetPersonByID(string ID)
        {
            SqlConnection baglanti = bag.BaglantiAl();
            SqlCommand komut = baglanti.CreateCommand();
            string query = "SELECT * FROM Personeller Where Id=@ID";
            komut.CommandText = query;
            SqlParameter Idm = new SqlParameter("ID", SqlDbType.Int);
            Idm.Value = Convert.ToInt16(ID);
            komut.Parameters.Add(Idm);
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return null;//
            }
            Model.Person yeniPersonel = new Model.Person();
            yeniPersonel.ID = Convert.ToInt16(ID);
            yeniPersonel.İsim = reader["İsim"].ToString();
            yeniPersonel.Soyisim = reader["Soyisim"].ToString();
            yeniPersonel.KullanıcıAdı = reader["KullanıcıAdı"].ToString();
            yeniPersonel.Şifre = reader["Şifre"].ToString();
            yeniPersonel.Tc_No = reader["TcNo"].ToString();
            return (yeniPersonel);
        }

    }
}