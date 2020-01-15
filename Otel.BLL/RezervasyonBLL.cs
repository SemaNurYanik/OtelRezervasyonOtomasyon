using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class RezervasyonBLL : ICrud<Rezervasyon>
    {
        RezervasyonDAL _rezervasyonDAL;
        public RezervasyonBLL()
        {
            _rezervasyonDAL = new RezervasyonDAL();
        }
        public int Add(Rezervasyon entity)
        {
            ValidateNullDate(entity.GirisTarihi, entity.CikisTarihi);
            ValidateNullKisiSayisi(entity.ToplamKisiSayisi);
            ValidateNullKisiSayisi(entity.RezervasyonTipID);
            return _rezervasyonDAL.Add(entity);
        }

        public List<Rezervasyon> GetAll()
        {
            return _rezervasyonDAL.GetAll();
        }
        public List<Rezervasyon> GetAllRezervasyonTipID(int ID)
        {
            return _rezervasyonDAL.GetAllRezervasyonTipID(ID);
        }
        public Rezervasyon GetByID(int ID)
        {
            return _rezervasyonDAL.GetByID(ID);
        }

        public int Update(Rezervasyon entity)
        {
            return _rezervasyonDAL.Update(entity);
        }
        public int UpdateStatus(int ID)
        {
            return _rezervasyonDAL.UpdateStatus(ID);
        }
        void ValidateNullDate(DateTime girisTarihi,DateTime cikisTarihi)
        {
            if (girisTarihi == null || cikisTarihi ==null)
            {
                throw new Exception();
            }
        }

        void ValidateNullKisiSayisi(int toplamKisiSayisi)
        {
            if (toplamKisiSayisi == null)
            {
                throw new Exception();
            }
        }

        void ValidateNullRezervasyonTip(int rezervasyonTip)
        {
            if (rezervasyonTip == null)
            {
                throw new Exception();
            }
        }
    }
}
