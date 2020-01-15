using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entities
{
    public class Rezervasyon
    {
        public int RezervasyonID { get; set; }
        public int UyeID { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int ToplamKisiSayisi { get; set; }
        public int RezervasyonTipID { get; set; }
        public decimal ToplamFiyat { get; set; }
        public bool IsActive { get; set; }
    }
}
