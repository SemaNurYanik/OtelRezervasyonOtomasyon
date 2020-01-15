using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class RezervasyonTipDAL : BaseConnection, ICrud<RezervasyonTip>
    {
        public int Add(RezervasyonTip rTip)
        {
            cmd = new SqlCommand("insert into RezervasyonTip (Ad,Aciklama) values (@ad,@aciklama)", con);
            cmd.Parameters.AddWithValue("@ad", rTip.RezervasyonTipAd);
            cmd.Parameters.AddWithValue("@aciklama", rTip.RezervasyonTipAciklama);
            return ExecuteCommand();
        }
        
        public List<RezervasyonTip> GetAll()
        {
            List<RezervasyonTip> RezervasyonTipler = new List<RezervasyonTip>();
            cmd = new SqlCommand("select * from RezervasyonTip", con);
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    RezervasyonTipler.Add(new RezervasyonTip()
                    {
                        RezervasyonTipID = Convert.ToInt32(dr[0]),
                        RezervasyonTipAd = dr[1].ToString(),
                        RezervasyonTipAciklama = dr[2].ToString()
                    });
                }
                con.Close();
                return RezervasyonTipler;
            }
            catch (Exception ex)
            {

                return RezervasyonTipler;
            }
        }

        public RezervasyonTip GetByID(int ID)
        {
            cmd = new SqlCommand("select * from RezervasyonTip where RezervasyonTipID=@id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            RezervasyonTip rezervasyonTip = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();
                rezervasyonTip = new RezervasyonTip()
                {
                    RezervasyonTipID = (int)dr["RezervasyonTipID"],
                    RezervasyonTipAd = dr["Ad"].ToString(),
                    RezervasyonTipAciklama = dr["Aciklama"].ToString()
                };
                dr.Close();
                return rezervasyonTip;
            }
            catch (Exception ex)
            {
                return rezervasyonTip;
            }
        }

        public int Update(RezervasyonTip rtip)
        {
            cmd = new SqlCommand("update RezervasyonTip set Ad=@ad,Aciklama=@aciklama where RezarvasyonTipID=@rtid", con);
            cmd.Parameters.AddWithValue("@rtid", rtip.RezervasyonTipID);
            cmd.Parameters.AddWithValue("@ad", rtip.RezervasyonTipAd);
            cmd.Parameters.AddWithValue("@aciklama", rtip.RezervasyonTipAciklama);
            return ExecuteCommand();
        }
    }
}
