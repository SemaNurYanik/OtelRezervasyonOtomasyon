using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class OdaSayisiSifir : Exception
    {
        public override string Message
        {
            get
            {
                return "Oda fiyati sıfır'a küçük veya eşit olamaz.";
            }
        }
    }

    public class OdaKisiSayisi : Exception
    {
        public override string Message
        {
            get
            {
                return "Kisi sayisi sıfır'a küçük veya eşit olamaz.";
            }
        }
    }

    class SekizdenKucuk : Exception
    {
        public override string Message
        {
            get
            {
                return "Girdiğiniz şifre 8 karakterden azdır.";
            }
        }
    }
    class OnBestenBuyuk : Exception
    {
        public override string Message
        {
            get
            {
                return "Girdiğiniz şifre 15 karakterden fazladır.";
            }
        }
    }
    class SameEmailException : Exception
    {
        public override string Message
        {
            get
            {
                return "Bu Email Sistemde Kayıtlı";
            }
        }
    }
    class OzelKarakter : Exception
    {
        public override string Message
        {
            get
            {
                return "Şifrede özel karakter kullanılmamalıdır.";
            }
        }
    }

    class NullTCKNException : Exception
    {
        public override string Message
        {
            get
            {
                return "TC Kimlik No Alanı Boş Geçilemez";
            }
        }

    }

    class SameTCKNException : Exception
    {
        public override string Message
        {
            get
            {
                return "Bu Müşteri Daha Önceden Kaydedilmiş.";
            }
        }
    }

    class NullDateException : Exception
    {
        public override string Message
        {
            get
            {
                return "Tarih Alanları Boş Geçilemez";
            }
        }
    }
    class NullToplamKisiSayisi : Exception
    {
        public override string Message
        {
            get
            {
                return "Kisi Sayısı Alanı Boş Geçilemez";
            }
        }
    }

    class NullRezervasyonTip : Exception
    {
        public override string Message
        {
            get
            {
                return "Rezervasyon Tipi Seçiniz";
            }
        }
    }
}
