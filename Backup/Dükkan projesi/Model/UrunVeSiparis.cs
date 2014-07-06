using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class UrunVeSiparis
    {
        public UrunVeSiparis(string UrunID)
        {
            Urunbilgisi = SQL.UrunServis.GetUrunByID(UrunID);
            SiparisBilgisi = new Model.Siparis();
        }
        public Model.Urun Urunbilgisi { get; set; }
        public Model.Siparis SiparisBilgisi { get; set; }
    }
}