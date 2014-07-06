using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class Urun
    {
        public string UrunID { get; set; }
        public string UrunAdi { get; set; }
        public string Kategori { get; set; }
        public decimal Fiyat { get; set; }
        public string Resim { get; set; }
        public byte StokMiktari { get; set; }
        public string Aciklama { get; set; }

        //Sepet kısmında kullanılacaktır.
        public int TalepMiktar { get; set; }
    }
}
