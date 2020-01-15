using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class UyeBLL : ICrud<Uye>
    {
        UyeDAL _uyeDAL;
        public UyeBLL()
        {
            _uyeDAL = new UyeDAL();
        }
        public int Add(Uye entity)
        {
            ValidateSameEmail(entity.Email);
            SifreKarakterKontrol(entity.Sifre);

            return _uyeDAL.Add(entity);
        }

      
        public List<Uye> GetAll()
        {
            return _uyeDAL.GetAll();
        }

        public Uye GetByID(int ID)
        {
            return _uyeDAL.GetByID(ID);
        }

        public int Update(Uye entity)
        {
            return _uyeDAL.Update(entity);
        }

        public bool UyeMi(string email, string sifre)
        {
            return _uyeDAL.UyeMi(email, sifre);
        }
        public Uye UyeGetir(string email, string sifre)
        {
            return _uyeDAL.UyeGetir(email, sifre);
        }
        public List<UyeRezervasyonlari> UyeRezervasyonGetir(int uyeID)
        {
            return _uyeDAL.UyeRezervasyonGetir(uyeID);
        }
        public bool AdminMi(string email, string sifre)
        {
            return _uyeDAL.AdminMi(email, sifre);

        }

        void SifreKarakterKontrol(string sifre)
        {
            string[] dizi = new string[]
            {
                    ",",
                    ".",
                    ":",
                    " ",
                    "(",
                    ")",
                    "/",
                    "*",
                    "+",
                    "-",
                    "%",
                    "&",
                    "'",
                    "é",
                    "!"
            };
            for (int i = 0; i < sifre.Length; i++)
            {
                for (int j = 0; j < dizi.Length; j++)
                {
                    if (sifre[i].ToString() == dizi[j])
                    {
                        throw new OzelKarakter();
                    }
                }
            }
            if (sifre.Length < 8)
            {
                throw new SekizdenKucuk();
            }
            else if (sifre.Length > 15)
            {
                throw new OnBestenBuyuk();
            }
        
        }

        void ValidateSameEmail(string email)
        {
            List<Uye> uyeler = _uyeDAL.GetAll();
            foreach (var item in uyeler)
            {
                if (email == item.Email)
                {
                    throw new SameEmailException();
                }
            }
        }
    }
}
