using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using System.Xml.Linq;

namespace Core.Services
{
    public class UrunServis
    {

        /// <summary>
        /// Bu method ile urun ekleyebilirsiniz.
        /// </summary>
        /// <param name="value">Urun tipinde bir değer veriniz.</param>
        /// <returns></returns>
        public bool Ekle(Urun value)
        {
            try
            {
                //Ekleyecegimiz Kayit Elementlerini Oluşturuyoruz...
                XElement xml = new XElement("Urun",
                    new XAttribute("ID", value.UrunID),
                    new XElement("UrunAdi", value.UrunAdi),
                    new XElement("Kategori", value.Kategori),
                    new XElement("Fiyat", value.Fiyat),
                    new XElement("Resim", value.Resim),
                    new XElement("StokMiktari", value.StokMiktari),
                    new XElement("Aciklama", value.Aciklama));

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
        public List<Urun> UrunListesi()
        {
            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));

            var sonuc = from item in doc.Descendants("Urun") select item;

            List<Urun> urunlistesi = new List<Urun>();

            foreach (var item in sonuc)
            {
                Urun u = new Urun();
                u.Aciklama = item.Element("Aciklama").Value;
                u.Fiyat = Convert.ToDecimal(item.Element("Fiyat").Value);
                u.Kategori = item.Element("Kategori").Value;
                u.Resim = item.Element("Resim").Value;
                u.StokMiktari = Convert.ToByte(item.Element("StokMiktari").Value);
                u.UrunAdi = item.Element("UrunAdi").Value;
                u.UrunID = item.Attribute("ID").Value;

                urunlistesi.Add(u);
            }
            return urunlistesi;
        }
        /// <summary>
        /// Secılı Urunun Detayını Bu method ıle alabilirsiniz.
        /// </summary>
        /// <param name="id">Urun Guid ID</param>
        /// <returns></returns>
        public Urun GetUrunByID(string id)
        {

            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));
            var sonuc = (from item in doc.Descendants("Urun")
                         where item.Attribute("ID").Value == id
                         select item).SingleOrDefault();
            Urun u = new Urun();
            u.Aciklama = sonuc.Element("Aciklama").Value;
            u.Fiyat = Convert.ToDecimal(sonuc.Element("Fiyat").Value);
            u.Kategori = sonuc.Element("Kategori").Value;
            u.Resim = sonuc.Element("Resim").Value;
            u.StokMiktari = Convert.ToByte(sonuc.Element("StokMiktari").Value);
            u.UrunAdi = sonuc.Element("UrunAdi").Value;
            u.UrunID = sonuc.Attribute("ID").Value;
            return u;
        }



        /// <summary>
        /// Urun adina göre arama yapabilirsiniz.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public List<Urun> UrunAra(string key)
        {
            XDocument doc = XDocument.Load(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/Urunler.xml"));

            var sonuc = from item in doc.Descendants("Urun")
                        where item.Element("UrunAdi").Value.ToLower().Contains(key.ToLower())
                        select item;

            List<Urun> urunlistesi = new List<Urun>();

            foreach (var item in sonuc)
            {
                Urun u = new Urun();
                u.Aciklama = item.Element("Aciklama").Value;
                u.Fiyat = Convert.ToDecimal(item.Element("Fiyat").Value);
                u.Kategori = item.Element("Kategori").Value;
                u.Resim = item.Element("Resim").Value;
                u.StokMiktari = Convert.ToByte(item.Element("StokMiktari").Value);
                u.UrunAdi = item.Element("UrunAdi").Value;
                u.UrunID = item.Attribute("ID").Value;

                urunlistesi.Add(u);
            }
            return urunlistesi;
        }
    }
}
