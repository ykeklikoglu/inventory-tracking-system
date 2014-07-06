using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml.Linq;
using System.Web;
using Core.Entity;

namespace Core.Services
{
    public class KategoriServis
    {

        public List<Core.Entity.Kategori> KategoriListesi()
        {
            //App_Data içerisindeki Xml Kaynagi XDocument'e yukluyoruz...
            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Kategoriler.xml"));

            var sonuc = from item in doc.Descendants("Kategori")
                        select item;


            List<Kategori> KategoriListesi = new List<Kategori>();

            foreach (string item in sonuc)
            {
                Kategori k = new Kategori();
                k.KategoriAdi = item;
                KategoriListesi.Add(k);
            }

            return KategoriListesi;
        }
    }
}
