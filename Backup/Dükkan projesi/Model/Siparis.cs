using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class Siparis
    {
        public int UrunID { get; set; }
        public int EsenbogaStok { get; set; }
        public int HasköyStok { get; set; }
        public int CubukStok { get; set; }
        public int IstanbulcadStok { get; set; }
        public double Toplam { get; set; }
        public double IndirimliFiyat { get; set; }
        public int IstenenAdet { get; set; } 
    }
}