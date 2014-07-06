using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class Siparis
    {
        public string id { get; set; }
        public string MusteriID { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public List<Urun> UrunListesi { get; set; }
    }
}
