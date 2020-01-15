using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class MusteriBLL : ICrud<Musteri>
    {
        MusteriDAL _musteriDAL;
        public MusteriBLL()
        {
            _musteriDAL =new MusteriDAL();
        }
        public int Add(Musteri musteri)
        {
            //ValidateNullTCKN(musteri.TCKN);
            //ValidateSameTCKN(musteri.TCKN);
            return _musteriDAL.Add(musteri);
        }
               
        public List<Musteri> GetAll()
        {
            return _musteriDAL.GetAll();
        }

        public Musteri GetByID(int ID)
        {
            return _musteriDAL.GetByID(ID);
        }
        public List<Musteri> GetByRezervasyonID(int ID)
        {
            return _musteriDAL.GetByRezervasyonID(ID);
        }
        public int Update(Musteri musteri)
        {
            ValidateNullTCKN(musteri.TCKN);
            return _musteriDAL.Update(musteri);
        }

        public int UpdateStatus(int ID)
        {
            return _musteriDAL.UpdateStatus(ID);
        }
        void ValidateNullTCKN(string tckn)
        {
            if (tckn == null)
            {
                throw new NullTCKNException();
            }
        }

        void ValidateSameTCKN(string tckn)
        {
            List<Musteri> musteriler = _musteriDAL.GetAll();
            foreach (var item in musteriler)
            {
                if (item.TCKN == tckn)
                {
                    throw new SameTCKNException();
                }
            }
        }
    }
}
