using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class MusteriRezervasyonBLL : ICrud<MusteriRezervasyon>
    {
        MusteriRezervasyonDAL _musteriRezervasyonDAL;
        public MusteriRezervasyonBLL()
        {
            _musteriRezervasyonDAL = new MusteriRezervasyonDAL();
        }
        public int Add(MusteriRezervasyon entity)
        {
            return _musteriRezervasyonDAL.Add(entity);
        }
        public List<MusteriRezervasyon> GetAll()
        {
            return _musteriRezervasyonDAL.GetAll();
        }

        public MusteriRezervasyon GetByID(int ID)
        {
            return _musteriRezervasyonDAL.GetByID(ID);
        }
        public List<MusteriRezervasyon> GetByRezervasyonID(int ID)
        {
            return _musteriRezervasyonDAL.GetByRezervasyonID(ID);
        }

        public int Update(MusteriRezervasyon entity)
        {
            return _musteriRezervasyonDAL.Update(entity);
        }
    }
}
