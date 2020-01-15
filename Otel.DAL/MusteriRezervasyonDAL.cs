using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class MusteriRezervasyonDAL : BaseConnection, ICrud<MusteriRezervasyon>
    {
        public int Add(MusteriRezervasyon entity)
        {
            cmd = new SqlCommand("insert into MusteriRezervasyon(RezervasyonID,MusteriID,OdaID) values(@rezervasyonID,@musteriID,@odaID)", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", entity.RezervasyonID);
            cmd.Parameters.AddWithValue("@musteriID", entity.MusteriID);
            cmd.Parameters.AddWithValue("@odaID", entity.OdaID);
            return ExecuteCommand();
        }
        
        public List<MusteriRezervasyon> GetAll()
        {
            cmd = new SqlCommand("select * from Musteri", con);
            List<MusteriRezervasyon> musteriRezervasyonlari = new List<MusteriRezervasyon>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    musteriRezervasyonlari.Add(new MusteriRezervasyon()
                    {
                        ID = (int)dr["ID"],
                        RezervasyonID = (int)dr["RezervasyonID"],
                        MusteriID = (int)dr["MusteriID"],
                        OdaID = (int)dr["OdaID"]                        
                    });
                }
                dr.Close();
                return musteriRezervasyonlari;
            }
            catch (Exception ex)
            {

                return musteriRezervasyonlari;
            }
        }

        public MusteriRezervasyon GetByID(int ID)
        {
            cmd = new SqlCommand("select * from MusteriRezervasyon where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            MusteriRezervasyon musteriRezervasyon = new MusteriRezervasyon();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();
                musteriRezervasyon.ID = (int)dr["ID"];
                musteriRezervasyon.RezervasyonID = (int)dr["RezervasyonID"];
                musteriRezervasyon.MusteriID = (int)dr["MusteriID"];
                musteriRezervasyon.OdaID = (int)dr["OdaID"];
                dr.Close();
                return musteriRezervasyon;
            }
            catch (Exception ex)
            {

                return musteriRezervasyon;
            }
        }
        public List<MusteriRezervasyon> GetByRezervasyonID(int ID)
        {
            cmd = new SqlCommand("select RezervasyonID,MusteriID,OdaID from MusteriRezervasyon where RezervasyonID=@id", con);
            cmd.Parameters.AddWithValue("@id", ID);
            List<MusteriRezervasyon> musteriRezervasyonlari = new List<MusteriRezervasyon>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    musteriRezervasyonlari.Add(new MusteriRezervasyon()
                    {
                        
                        RezervasyonID = (int)dr["RezervasyonID"],
                        MusteriID = (int)dr["MusteriID"],
                        OdaID = (int)dr["OdaID"]
                    });
                }
                dr.Close();
                return musteriRezervasyonlari;
            }
            catch (Exception ex)
            {

                return musteriRezervasyonlari;
            }
        }
        public int Update(MusteriRezervasyon entity)
        {
            return 0;
        }

        
    }
}
