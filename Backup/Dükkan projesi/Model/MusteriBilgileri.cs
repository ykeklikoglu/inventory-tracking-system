using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class MusteriBilgileri
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string  TelNo { get; set; }
        public string  Adres { get; set; }
        public string  VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string  TcNo { get; set; }

    }
}