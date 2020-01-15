using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entities
{
    public class UyeRezervasyonlari
    {
        public int RezervasyonID { get; set; }
        public DateTime GirisTarihi { get; set; }
        public DateTime CikisTarihi { get; set; }
        public int ToplamKisiSayisi { get; set; }
        public string RezervasyonTipi { get; set; }
        public string DurumBilgisi { get; set; }
        public int DurumBilgisiGuncelle()
        {
            int girisKalanGun = (GirisTarihi - DateTime.Now).Days;
            int bitisGecenGun = (DateTime.Now - CikisTarihi).Days;
            if (girisKalanGun < 0 && bitisGecenGun > 0)
            {
                DurumBilgisi = "Çıkış Yapılmış";
            }
            else if (girisKalanGun <= 0 && bitisGecenGun <= 0)
            {
                DurumBilgisi = "Henüz Çıkış Yapılmamış";
            }
            else if (girisKalanGun > 0)
            {
                DurumBilgisi = $"{girisKalanGun} Gün Var";
                if (girisKalanGun >= 10)
                {
                    DurumBilgisi = DurumBilgisi + " " + "(İptal Edilebilir)";
                }
            }
            return girisKalanGun;
        }
    }
}
