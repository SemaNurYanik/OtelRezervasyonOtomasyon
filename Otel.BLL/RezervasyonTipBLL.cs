using Otel.DAL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.BLL
{
    public class RezervasyonTipBLL :  ICrud<RezervasyonTip>
    {
        RezervasyonTipDAL _rezervasyonTipDAL;
        public RezervasyonTipBLL()
        {
            _rezervasyonTipDAL = new RezervasyonTipDAL();
        }
        public int Add(RezervasyonTip entity)
        {
            return _rezervasyonTipDAL.Add(entity);
        }

        public List<RezervasyonTip> GetAll()
        {
            return _rezervasyonTipDAL.GetAll();
        }

        public RezervasyonTip GetByID(int ID)
        {
            return _rezervasyonTipDAL.GetByID(ID);
        }

        public int Update(RezervasyonTip entity)
        {
            return _rezervasyonTipDAL.Update(entity);
        }
    }
}
