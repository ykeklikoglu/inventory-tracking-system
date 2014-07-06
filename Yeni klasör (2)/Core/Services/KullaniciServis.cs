using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using System.Xml.Linq;
using System.Web;

namespace Core.Services
{
    public class KullaniciServis
    {
        public void KullaniciEkle(Kullanici value)
        {
            XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Kullanicilar.xml"));
            XElement xml = new XElement("Kullanici",
                new XAttribute("KullaniciID", value.KullaniciID),
                new XElement("KullaniciAdi", value.KullaniciAdi),
                new XElement("Sifre", System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(value.Sifre, "SHA1")),
                new XElement("Email", value.Email),
                new XElement("Role", value.Role));

            doc.Root.Add(xml);
            doc.Save(HttpContext.Current.Server.MapPath("~/App_Data/Kullanicilar.xml"));
        }
        public void UyeGiris(string KullaniciAdi, string Sifre)
        {

            try
            {
                XDocument doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Kullanicilar.xml"));

                var sonuc = (from item in doc.Descendants("Kullanici")
                             where item.Element("KullaniciAdi").Value == KullaniciAdi && item.Element("Sifre").Value == Sifre
                             select item).SingleOrDefault();

                if (sonuc == null)
                {
                    throw new Exception("Uye Bulunamadi");
                }
                else
                {
                    System.Web.Security.FormsAuthenticationTicket bilet = new System.Web.Security.FormsAuthenticationTicket(1, sonuc.Element("KullaniciAdi").Value, DateTime.Now, DateTime.Now.AddMinutes(50), true, sonuc.Element("Role").Value, System.Web.Security.FormsAuthentication.FormsCookiePath);


                    string sifrenmisBilet = System.Web.Security.FormsAuthentication.Encrypt(bilet);

                    HttpCookie co = new HttpCookie(System.Web.Security.FormsAuthentication.FormsCookieName, sifrenmisBilet);

                    HttpContext.Current.Response.Cookies.Add(co);

                    if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["returnUrl"]))
                        HttpContext.Current.Response.Redirect(HttpContext.Current.Request.QueryString["returnUrl"]);
                    else
                        HttpContext.Current.Response.Redirect("~/Default.aspx");


                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }






        }


    }
}
