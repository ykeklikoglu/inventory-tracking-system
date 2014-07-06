using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Data;
namespace Dükkan_projesi.SQL
{
    public class UrunServis
    {
        public static SQL.SqlTanımı bag = new SQL.SqlTanımı();
        public static bool Ekle(Model.Urun value)
        {
            try
            {
                //Ekleyecegimiz Kayit Elementlerini Oluşturuyoruz...
                XElement xml = new XElement("Urun",
                    new XAttribute("ID", value.UrunID),
                    new XElement("UrunAdi", value.UrunAd),
                    new XElement("Kategori", value.Kategori),
                    new XElement("Fiyat", value.Fiyat),
                    //new XElement("Resim", value.Resim),
                    new XElement("StokMiktari", value.Stok));

                //Var olan Xml Kaynagına Ekleyecegimiz icin öncelikle  Kaynagi XDocument'e yukleyelim...
                XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));

                //Daha Sonra Oluşturmuş oldugmuz XElement değerlerini Yuklemiş oldugmuz Kaynagın Root'una eklıyoruz.
                doc.Root.Add(xml);
                //Daha Sonra Kaynagı Kayıt Et
                doc.Save(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));


                //Buraya kadar sorun olmamış ise return true dönderiyoruz.
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Urunleri bu method ile listeyebilirsiniz.
        /// </summary>
        /// <returns></returns>
        public static List<Model.Urun> UrunListesi()
        {
            SqlConnection baglanti = bag.BaglantiAl();
            String Query = @"SELECT * FROM Urun";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = Query;
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return null;//
            }
            List<Model.Urun> urunlistesi = new List<Model.Urun>();

            while (reader.Read())
            {
                Model.Urun u = new Model.Urun();
                u.kodu = reader["Kodu"].ToString();
                u.Fiyat = Convert.ToDouble(reader["Fiyat"]);
                u.Kategori = reader["Katagori"].ToString();
                //u.Resim = item.Element("Resim").Value;
                u.StokCubuk = Convert.ToInt16(reader["CubukStok"]);
                u.StokEsenboga = Convert.ToInt16(reader["EsenbogaStok"]);
                u.StokHasköy = Convert.ToInt16(reader["HasköyStok"]);
                u.Stokİstcad = Convert.ToInt16(reader["İstanbuLCadStok"]);
                u.Stok = u.Stokİstcad + u.StokHasköy + u.StokCubuk + u.StokEsenboga;
                u.UrunAd = reader["UrunAd"].ToString();
                u.UrunID = Convert.ToInt16(reader["UrunID"]);
                u.En = Convert.ToDouble(reader["En"]);
                u.Malzeme = reader["Malzeme"].ToString();
                u.Boy = Convert.ToDouble(reader["Boy"]);
                urunlistesi.Add(u);
            }
            baglanti.Close();
            return urunlistesi;
        }
        /// <summary>
        /// Secılı Urunun Detayını Bu method ıle alabilirsiniz.
        /// </summary>
        /// <param name="id">Urun Guid ID</param>
        /// <returns></returns>
        public static Model.Urun GetUrunByID(string id)
        {

            SqlConnection baglanti = bag.BaglantiAl();
            string query = "SELECT [Kodu] , [UrunAd] , [Malzeme],[En],[Boy],[Fiyat],CubukStok,EsenbogaStok,HasköyStok,İstanbuLCadStok FROM Urun where [UrunID] = @ID  ";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = query;
            SqlParameter ID = new SqlParameter("@ID", SqlDbType.Int);
            ID.Value = Convert.ToInt16(id);
            komut.Parameters.Add(ID);
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return null;//
            }
            Model.Urun Urunum = new Model.Urun();
            while (reader.Read())
            {
                #region okunan bilgileri LoginOlanPersonel yapisina tek tek kaydetme bolumu
                Urunum.UrunID = Convert.ToInt16(id);
                Urunum.Kategori = "Hayvan Maketleri";
                Urunum.StokCubuk = Convert.ToInt16(reader["CubukStok"]);
                Urunum.StokEsenboga = Convert.ToInt16(reader["EsenbogaStok"]);
                Urunum.StokHasköy = Convert.ToInt16(reader["HasköyStok"]);
                Urunum.Stokİstcad = Convert.ToInt16(reader["İstanbuLCadStok"]);
                Urunum.UrunAd = reader["UrunAd"].ToString();
                Urunum.kodu = reader["Kodu"].ToString();
                Urunum.Malzeme = reader["Malzeme"].ToString();
                Urunum.En = Convert.ToDouble(reader["En"]);
                Urunum.Boy = Convert.ToDouble(reader["Boy"]);
                Urunum.Stok = Urunum.Stokİstcad + Urunum.StokHasköy + Urunum.StokEsenboga + Urunum.StokCubuk;
                Urunum.Fiyat = Convert.ToDouble(reader["Fiyat"]);
                #endregion
            }
            baglanti.Close();
            return Urunum;

        }
        /// <summary>
        /// Urun adina göre SQL'DEN arama yapabilirsiniz.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<Model.Urun> SQLSorguluUrunListele(string sorgum) 
        {
            SqlConnection baglanti = bag.BaglantiAl();
            String Query = "SELECT * FROM Urun where (UrunAd like '"+sorgum+"%') OR (Kodu='"+sorgum+"')";
            SqlCommand komut = baglanti.CreateCommand();
            komut.CommandText = Query;
            /*SqlParameter Sor = new SqlParameter("@sor", SqlDbType.NVarChar);
            Sor.Value = sorgum;
            SqlParameter Sorg = new SqlParameter("@sorg", SqlDbType.NVarChar);
            Sorg.Value = sorgum;
            komut.Parameters.Add(Sor);
            komut.Parameters.Add(Sorg);*/
            SqlDataReader reader = komut.ExecuteReader();
            if (!reader.HasRows)//Hic Satir Gelmezse.
            {
                baglanti.Close();
                return null;//
            }
            List<Model.Urun> urunlistesi = new List<Model.Urun>();
            while (reader.Read())
            {
                Model.Urun u = new Model.Urun();
                u.kodu = reader["Kodu"].ToString();
                u.Fiyat = Convert.ToDouble(reader["Fiyat"]);
                u.Kategori = reader["Katagori"].ToString();
                //u.Resim = item.Element("Resim").Value;
                u.StokCubuk = Convert.ToInt16(reader["CubukStok"]);
                u.StokEsenboga = Convert.ToInt16(reader["EsenbogaStok"]);
                u.StokHasköy = Convert.ToInt16(reader["HasköyStok"]);
                u.Stokİstcad = Convert.ToInt16(reader["İstanbuLCadStok"]);
                u.Stok = u.Stokİstcad + u.StokHasköy + u.StokCubuk + u.StokEsenboga;
                u.UrunAd = reader["UrunAd"].ToString();
                u.UrunID = Convert.ToInt16(reader["UrunID"]);
                u.En = Convert.ToDouble(reader["En"]);
                u.Malzeme = reader["Malzeme"].ToString();
                u.Boy = Convert.ToDouble(reader["Boy"]);
                urunlistesi.Add(u);
            }
            baglanti.Close();
            return urunlistesi;
        }
        /// <summary>
        /// Urun adina göre HTTPSESSİON'DAN arama yapabilirsiniz.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static List<Model.Urun> UrunAra(string key)
        {
            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));

            var sonuc = from item in doc.Descendants("Urun")
                        where item.Element("UrunAdi").Value.ToLower().Contains(key.ToLower())
                        select item;

            List<Model.Urun> urunlistesi = new List<Model.Urun>();

            foreach (var item in sonuc)
            {
                Model.Urun u = new Model.Urun();
                u.Fiyat = Convert.ToDouble(item.Element("Fiyat").Value);
                u.Kategori = item.Element("Kategori").Value;
                u.Stok = Convert.ToByte(item.Element("StokMiktari").Value);
                u.UrunAd = item.Element("UrunAdi").Value;
                u.UrunID = Convert.ToInt16(item.Attribute("ID"));

                urunlistesi.Add(u);
            }
            return urunlistesi;
        }
    }
}