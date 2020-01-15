using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entities
{
    public class Musteri
    {
        public int MusteriID { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TCKN { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int RezervasyonID { get; set; }
        public int OdaID { get; set; }
        public bool IsActive { get; set; }
    }
}
