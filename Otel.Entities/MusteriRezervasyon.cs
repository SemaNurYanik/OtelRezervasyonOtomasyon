using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.Entities
{
    public class MusteriRezervasyon
    {
        public int ID { get; set; }
        public int RezervasyonID { get; set; }
        public int MusteriID { get; set; }
        public int OdaID { get; set; }
    }
}
