using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class OdaDAL : BaseConnection, ICrud<Oda>
    {
        public int Add(Oda oda)
        {           
            cmd = new SqlCommand("insert into Oda (RezervasyonID,KisiSayisi,Fiyat,Durum,HaftasonuSayisi,Haftasonu,MinKisi,MaxKisi) values (@rezervasyonID,@kisiSayisi,@fiyat,@durum,@haftaSonuSayisi,@haftaSonuOrani,@minKisiSayisi,@maxKisiSayisi)", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", oda.RezervasyonID);
            cmd.Parameters.AddWithValue("@kisiSayisi", oda.KisiSayisi);            
            cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
            cmd.Parameters.AddWithValue("@durum", oda.Durum);
            cmd.Parameters.AddWithValue("@haftaSonuSayisi", oda.HaftaSonuSayisi);
            cmd.Parameters.AddWithValue("@haftaSonuOrani", oda.HaftaSonuOranı);
            cmd.Parameters.AddWithValue("@minKisiSayisi", oda.MinKisiSayisi);
            cmd.Parameters.AddWithValue("@maxKisiSayisi", oda.MaxKisiSayisi);
            return ExecuteCommand();
        }
       
        public List<Oda> GetAll()
        {
            cmd = new SqlCommand("select * from Oda", con);

            List<Oda> odalar = new List<Oda>();
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    odalar.Add(new Oda()
                    {
                        OdaID = Convert.ToInt32(reader["OdaID"]),
                        KisiSayisi = Convert.ToInt32(reader["KisiSayisi"]),
                        Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                        Durum = (bool)reader["Durum"],
                        HaftaSonuSayisi = Convert.ToInt32(reader["HaftaSonuSayisi"]),
                        HaftaSonuOranı = Convert.ToInt32(reader["Haftasonu"]),
                        MinKisiSayisi = Convert.ToInt32(reader["MinKisi"]),
                        MaxKisiSayisi = Convert.ToInt32(reader["MaxKisi"])
                    });
                }
                reader.Close();
                return odalar;

            }
            catch (Exception)
            {
                return odalar;

            }
        }

        public Oda GetByID(int ID)
        {
            cmd = new SqlCommand("select * from Oda where OdaID=@odaID", con);
            cmd.Parameters.AddWithValue("@odaID", ID);
            Oda oda = null;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                reader.Read();
                oda = new Oda()
                {
                    OdaID = Convert.ToInt32(reader["OdaID"]),
                    KisiSayisi = Convert.ToInt32(reader["KisiSayisi"]),
                    Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                    Durum = (bool)reader["Durum"],
                    HaftaSonuSayisi = Convert.ToInt32(reader["HaftaSonuSayisi"]),
                    HaftaSonuOranı = Convert.ToInt32(reader["Haftasonu"]),
                    MinKisiSayisi = Convert.ToInt32(reader["MinKisi"]),
                    MaxKisiSayisi = Convert.ToInt32(reader["MaxKisi"])
                };
                reader.Close();
                return oda;
            }
            catch (Exception ex)
            {

                return oda;
            }


            
        }
        
        public List<Oda> GetByRezarvasyonID(int ID)
        {
            cmd = new SqlCommand("  select * from Oda where OdaID in (select OdaID as OdaSayisi from MusteriRezervasyon where RezervasyonID = @rezervasyonID group by OdaID)", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", ID);
            List<Oda> odalar = new List<Oda>();
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    odalar.Add(new Oda()
                    {
                        OdaID = Convert.ToInt32(reader["OdaID"]),
                        KisiSayisi = Convert.ToInt32(reader["KisiSayisi"]),
                        Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                        Durum = (bool)reader["Durum"],
                        HaftaSonuSayisi = Convert.ToInt32(reader["HaftaSonuSayisi"]),
                        HaftaSonuOranı = Convert.ToInt32(reader["Haftasonu"]),
                        MinKisiSayisi = Convert.ToInt32(reader["MinKisi"]),
                        MaxKisiSayisi = Convert.ToInt32(reader["MaxKisi"])
                    });
                }
                reader.Close();
                return odalar;

            }
            catch (Exception)
            {
                return odalar;

            }

        }

        public int OdaSayisiniGetir(int rezervasyonID)
        {
            cmd = new SqlCommand("select OdaID from MusteriRezervasyon where RezervasyonID =@rezervasyonID group by OdaID", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", rezervasyonID);
            List<int> oda = new List<int>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    oda.Add((int)dr["OdaID"]);
                }
                dr.Close();
                return oda.Count;
            }
            catch (Exception ex)
            {

                return oda.Count;
            }
           
          
        }

        public int Update(Oda oda)
        {

            cmd = new SqlCommand("update oda set KisiSayisi=@kisiSayisi,Fiyat=@fiyat,Haftasonu=@haftaSonuOrani,MinKisi=@min,MaxKisi=@max where OdaID>0", con);
            cmd.Parameters.AddWithValue("@kisiSayisi", oda.KisiSayisi);
            cmd.Parameters.AddWithValue("@fiyat", oda.Fiyat);
            cmd.Parameters.AddWithValue("@haftaSonuOrani", oda.HaftaSonuOranı);
            cmd.Parameters.AddWithValue("@min", oda.MinKisiSayisi);
            cmd.Parameters.AddWithValue("@max", oda.MaxKisiSayisi);
            return ExecuteCommand();
        }

        public int TutulanOdaGuncelle(Oda oda)
        {
            cmd = new SqlCommand("update Oda set KisiSayisi = @kisiSayisi,HaftasonuSayisi = @haftasonuSayisi,RezervasyonID=@rezervasyonID,Durum=@durum where OdaID=@odaID", con);
            cmd.Parameters.AddWithValue("@odaID", oda.OdaID);
            cmd.Parameters.AddWithValue("@kisiSayisi", oda.KisiSayisi);
            cmd.Parameters.AddWithValue("@haftasonuSayisi", oda.HaftaSonuSayisi);
            cmd.Parameters.AddWithValue("@rezervasyonID", oda.RezervasyonID);
            cmd.Parameters.AddWithValue("@durum", oda.Durum);
            return ExecuteCommand();

        }

        public int PasifOda(Oda oda)
        {
            cmd = new SqlCommand("update Oda set Durum=@durum where OdaID=@odaid", con);
            cmd.Parameters.AddWithValue("@odaid", oda.OdaID);
            cmd.Parameters.AddWithValue("@durum", oda.Durum);
            return ExecuteCommand();

        }

        /// <summary>
        /// Odanın Boş Olduğunu Belirtmek İçin Durum Pasif Olarak Güncellenir.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int PasifOda(int ID)
        {
            cmd = new SqlCommand("update Oda set Durum=0 where OdaID=@odaid", con);
            cmd.Parameters.AddWithValue("@odaid", ID);
           
            return ExecuteCommand();

        }
        public int AktifOda(Oda oda)
        {
            cmd = new SqlCommand("update Oda set Durum=@durum where OdaID=@odaid", con);
            cmd.Parameters.AddWithValue("@odaid", oda.OdaID);
            cmd.Parameters.AddWithValue("@durum", oda.Durum);
            return ExecuteCommand();

        }

        public List<Oda> BosOdaSayisi()
        {
            cmd = new SqlCommand("select * from Oda where Durum=1", con);
            List<Oda> odalar = new List<Oda>();
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    odalar.Add(new Oda()
                    {
                        OdaID = Convert.ToInt32(reader["OdaID"]),
                        KisiSayisi = Convert.ToInt32(reader["KisiSayisi"]),
                        Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                        Durum = (bool)reader["Durum"],
                        HaftaSonuSayisi = Convert.ToInt32(reader["HaftaSonuSayisi"]),
                        HaftaSonuOranı = Convert.ToInt32(reader["Haftasonu"]),
                        MinKisiSayisi = Convert.ToInt32(reader["MinKisi"]),
                        MaxKisiSayisi = Convert.ToInt32(reader["MaxKisi"])
                    });
                }
                reader.Close();
                return odalar;

            }
            catch (Exception)
            {
                return odalar;

            }
        }

        public List<Oda> BosOdaGetir(int hesaplanan)
        {
            cmd = new SqlCommand("select top(@hesaplanan) * from Oda where Durum=1", con);
            cmd.Parameters.AddWithValue("@hesaplanan", hesaplanan);
            List<Oda> odalar = new List<Oda>();
            try
            {
                con.Open();

                SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (reader.Read())
                {
                    odalar.Add(new Oda()
                    {
                        OdaID = Convert.ToInt32(reader["OdaID"]),
                        KisiSayisi = Convert.ToInt32(reader["KisiSayisi"]),
                        Fiyat = Convert.ToDecimal(reader["Fiyat"]),
                        Durum = (bool)reader["Durum"],
                        HaftaSonuSayisi = Convert.ToInt32(reader["HaftaSonuSayisi"]),
                        HaftaSonuOranı = Convert.ToInt32(reader["Haftasonu"]),
                        MinKisiSayisi = Convert.ToInt32(reader["MinKisi"]),
                        MaxKisiSayisi = Convert.ToInt32(reader["MaxKisi"])
                    });
                }
                reader.Close();
                return odalar;

            }
            catch (Exception)
            {
                return odalar;

            }
        }
    }
}
