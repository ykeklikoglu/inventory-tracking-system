using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Core.Entity;
using System.Xml.Linq;

namespace Core.Services
{
    public class SepetServis
    {

        /// <summary>
        /// Secılı urunu Adeti ile buradan Sessin'a  ekleyebilirsiniz.Eğer Eklemiş oldugunuz urun daha önceden ekli ise sadece adet arttırır.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adet"></param>
        public static void SepeteEkle(string id, string adet)
        {
            //Eğer Sepet Sesssionu null ise yanı ilk defa urun eklenıyor ise if'in bu alanı kullanılır.Session olusturulur ve Urun bu Session'a eklenır.
            if (HttpContext.Current.Session["Sepet"] == null)
            {
                List<Urun> bas = new List<Urun>();
                Urun u = new UrunServis().GetUrunByID(id);
                u.TalepMiktar = Convert.ToInt32(adet);
                bas.Add(u);
                HttpContext.Current.Session["Sepet"] = bas;
            }
            else//Eger daha onceden urun eklenmıs ıse sepet sessionu var ve bu var olan listeye eklenır urun.
            {
                List<Urun> bas = HttpContext.Current.Session["Sepet"] as List<Urun>;

                //Burada Eklenen urun once listede aranır.Eğer eklenen urun listede bulunur ıse sadece adet mıktarı arttılır.
                bool varmiYokmu = false;
                foreach (Urun item in bas)
                {
                    if (item.UrunID == id)
                    {
                        item.TalepMiktar += Convert.ToInt32(adet);
                        varmiYokmu = true;
                        break;
                    }
                }
                //Eger urun listede yok ise  direk olarak listeye eklenır.
                if (varmiYokmu == false)
                {
                    Urun u = new UrunServis().GetUrunByID(id);
                    u.TalepMiktar = Convert.ToInt32(adet);
                    bas.Add(u);
                }
                HttpContext.Current.Session["Sepet"] = bas;
            }
        }

        /// <summary>
        /// Session'daki urun listesini bu method ile elde edebilirsiniz.
        /// </summary>
        /// <returns></returns>
        public static List<Urun> Sepetim()
        {
            if (HttpContext.Current.Session["Sepet"] != null)
            {
                return HttpContext.Current.Session["Sepet"] as List<Urun>;
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Sepetinizdeki urunun adet'inde bır degısıklık yapmak ıstersenız bu methodu kullanmalısınız
        /// </summary>
        /// <param name="id"></param>
        /// <param name="adet"></param>
        public static void UrunAdetGuncelle(string id, int adet)
        {
            List<Urun> bas = HttpContext.Current.Session["Sepet"] as List<Urun>;
            //Session'daki urunler listelenir.Daha sonra  ID'ye gore urun bulunur ve adet'i arttırılır.
            foreach (Urun item in bas)
            {
                if (item.UrunID == id)
                {
                    item.TalepMiktar = adet;
                }

            }

        }

        /// <summary>
        /// Sepetteki urunu bu method ile kaldırabilirsiniz.
        /// </summary>
        /// <param name="id"></param>
        public static void UrunKaldir(string id)
        {
            List<Urun> bas = HttpContext.Current.Session["Sepet"] as List<Urun>;
            foreach (Urun item in bas)
            {
                if (item.UrunID == id)
                {
                    bas.Remove(item);
                    break;
                }
            }
            HttpContext.Current.Session["Sepet"] = bas;

        }

        /// <summary>
        /// Eğer alışveris bitti ve kullanıcı  sepetti urunleri onaylamak ıstıyor ise bu method kullanılır.
        /// </summary>
        public static void SepetiOnayla()
        {
            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Siparisler.xml"));

            List<Urun> bas = HttpContext.Current.Session["Sepet"] as List<Urun>;

            string siparisID = Guid.NewGuid().ToString();
            string musteriID = "1";


            XElement xml = new XElement("Siparis",
           new XAttribute("SiparisID", siparisID),
           new XElement("MusteriID", musteriID),
           new XElement("SiparisTarihi", DateTime.Now));


            XElement urunler = new XElement("Urunler");
            foreach (Urun item in bas)
            {
                urunler.Add(new XElement("UrunID", item.UrunID, new XAttribute("TalepMiktar", item.TalepMiktar)));
            }
            xml.Add(urunler);

            doc.Root.Add(xml);
            doc.Save(HttpContext.Current.Server.MapPath("~/App_Data/Siparisler.xml"));
        }
        /// <summary>
        /// Sepeti Bosalt
        /// </summary>
        public static void SepetiBosalt()
        {
            HttpContext.Current.Session.Remove("Sepet");
        }


    }
}
