using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entities
{
    public class Oda
    {
        public int OdaID { get; set; }
        public int RezervasyonID { get; set; }
        public int KisiSayisi { get; set; }
        public decimal Fiyat { get; set; }
        public bool Durum { get; set; }
        public int HaftaSonuSayisi { get; set; }
        public int HaftaSonuOranı { get; set; } //Db'de haftasonu olarak kayıtlı
        public int MinKisiSayisi { get; set; }
        public int MaxKisiSayisi { get; set; }
        
    }
}
