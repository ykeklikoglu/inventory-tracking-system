using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class SipariseKalan
    {
        public int UrunID{get;set;}
        public int MusteriID { get; set; }
        public int IstenenAdet { get; set; }
        public string MusteriIsimSoyisim { get; set; }
        public string SatısTipi { get; set; }
        public string SiparisTarihi { get; set; }
        public string TeslimTarihi { get; set; }
        public string SiparisNotu { get; set; }

    }
}