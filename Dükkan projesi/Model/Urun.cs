using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class Urun
    {
        public Urun() {
            Stok = StokCubuk + StokEsenboga + StokHasköy + Stokİstcad;
            Kategori=" ";
        }
        public string kodu { get; set; }
        public int UrunID { get; set; }
        public string UrunAd { get; set; }
        public string Malzeme { get; set; }
        public double En { get; set; }
        public double Boy { get; set; }
        public string Kategori { get; set; }
        public double Fiyat { get; set; }
        public int StokHasköy{get; set;}
        public int StokEsenboga { get; set; }
        public int Stokİstcad { get; set; }
        public int StokCubuk { get; set; }
       // public string Resim { get; set; }
        public int Stok { get; set; }
        //Sepet kısmında kullanılacaktır.
        public int TalepMiktar { get; set; }
    }
}