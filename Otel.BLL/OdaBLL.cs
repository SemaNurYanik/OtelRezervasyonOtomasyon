using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class OdaBLL : ICrud<Oda>
    {
        OdaDAL _odaDAL;

        public OdaBLL()
        {
            _odaDAL = new OdaDAL();
        }

        public int Add(Oda oda)
        {
            OdaFiyati(oda.Fiyat);
            OdaKisiSayisi(oda.KisiSayisi);
            OdaKisiSayisi(oda.MaxKisiSayisi);
            OdaKisiSayisi(oda.MinKisiSayisi);

            return _odaDAL.Add(oda);
        }
        public List<Oda> GetAll()
        {
            return _odaDAL.GetAll();
        }

        public Oda GetByID(int ID)
        {
            return _odaDAL.GetByID(ID);
        }
        public List<Oda> GetByRezarvasyonID(int ID)
        {
            return _odaDAL.GetByRezarvasyonID(ID);
        }
        public int OdaSayisiniGetir(int rezervasyonID)
        {
            return _odaDAL.OdaSayisiniGetir(rezervasyonID);
        }
        public int Update(Oda oda)
        {
            OdaFiyati(oda.Fiyat);
            OdaKisiSayisi(oda.KisiSayisi);
            OdaKisiSayisi(oda.MaxKisiSayisi);
            OdaKisiSayisi(oda.MinKisiSayisi);

            return _odaDAL.Update(oda);
        }
        public int TutulanOdaGuncelle(Oda oda)
        {
            return _odaDAL.TutulanOdaGuncelle(oda);
        }
        public bool PasifOda(Oda oda)
        {
            int result = _odaDAL.PasifOda(oda);
            return result > 0;
        }
        public bool PasifOda(int ID)
        {
            int result = _odaDAL.PasifOda(ID);
            return result > 0;
        }

        public bool AktifOda(Oda oda)
        {
            int result = _odaDAL.AktifOda(oda);
            return result > 0;
        }
        void OdaFiyati(decimal odaFiyat)
        {
            //if (odaFiyat <= 0)
            //{
            //    throw new OdaSayisiSifir();
            //}

        }

        void OdaKisiSayisi(int odaKisiSayisi)
        {
            //if (odaKisiSayisi <= 0)
            //{
            //    throw new OdaKisiSayisi();
            //}
        }

        public List<Oda> BosOdaSayisi()
        {
            return _odaDAL.BosOdaSayisi();
        }
        public List<Oda> BosOdaGetir(int hesaplanan)
        {
            return _odaDAL.BosOdaGetir(hesaplanan);
        }
    }
}
