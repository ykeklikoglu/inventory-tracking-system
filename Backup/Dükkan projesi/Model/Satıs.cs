using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dükkan_projesi.Model
{
    public class Satıs
    {
        public string Musterİsim { get; set; }
        public string MusteriSoyisim { get; set; }
        public string MusteriTelefon { get; set; }
        public string MusteriAdres { get; set; }
        public string SatısPersonel { get; set; }
        public string TeslimTarihi { set; get; }
        public string Not { get; set; }
        public string SatısDurumu { get; set; }
        public List<Model.Siparis> Satılanlar { get; set; }
    }
}