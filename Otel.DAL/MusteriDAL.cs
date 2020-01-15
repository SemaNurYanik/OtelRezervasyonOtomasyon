using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class MusteriDAL : BaseConnection, ICrud<Musteri>
    {
        public int Add(Musteri musteri)
        {
            cmd = new SqlCommand("insert into Musteri(RezervasyonID,Ad,Soyad,TCKN,Telefon,Email,OdaID,IsActive) values(@rezervasyonID,@ad,@soyad,@tckn,@telefon,@email,@odaID,1) Select cast(SCOPE_IDENTITY() as int)", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", musteri.RezervasyonID);
            cmd.Parameters.AddWithValue("@ad", musteri.Ad);
            cmd.Parameters.AddWithValue("@soyad", musteri.Soyad);
            cmd.Parameters.AddWithValue("@tckn", musteri.TCKN);
            cmd.Parameters.AddWithValue("@telefon", musteri.Telefon);
            cmd.Parameters.AddWithValue("@email", musteri.Email);
            cmd.Parameters.AddWithValue("@odaID", musteri.OdaID);
            int sonID = 0;
            try
            {
                con.Open();
                sonID = (int)cmd.ExecuteScalar();
                con.Close();
                return sonID;
            }
            catch (Exception ex)
            {

                con.Close();
                return sonID;
            }
        }       
        public List<Musteri> GetAll()
        {
            cmd = new SqlCommand("select * from Musteri", con);
            List<Musteri> musteriler = new List<Musteri>();

            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    musteriler.Add(new Musteri()
                    {
                        MusteriID = (int)dr["MusteriID"],
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        TCKN = dr["TCKN"].ToString(),
                        Telefon = dr["Telefon"].ToString(),
                        Email = dr["Email"].ToString(),
                        IsActive =(bool)dr["IsActive"]
                    });
                }
                dr.Close();
                return musteriler;
            }
            catch (Exception ex)
            {

                return musteriler;
            }
        }

        public Musteri GetByID(int ID)
        {
            cmd = new SqlCommand("select MusteriID,OdaID,RezervasyonID from Musteri where MusteriID=@musteriID", con);
            cmd.Parameters.AddWithValue("@musteriID", ID);
            Musteri musteri = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();
                musteri = new Musteri()
                {
                    MusteriID = (int)dr["MusteriID"],
                    //Ad = dr["Ad"].ToString(),
                    //Soyad = dr["Soyad"].ToString(),
                    //TCKN = dr["TCKN"].ToString(),
                    //Telefon = dr["Telefon"].ToString(),
                    //Email = dr["Email"].ToString(),
                    OdaID = (int)dr["OdaID"],
                    RezervasyonID = (int)dr["RezervasyonID"]
                };
                dr.Close();
                return musteri;
            }
            catch (Exception ex)
            {

                return musteri;
            }
        }
        public List<Musteri> GetByRezervasyonID(int ID)
        {

            cmd = new SqlCommand("select m.MusteriID,m.Ad,m.Soyad,m.TCKN,m.Telefon,m.Email from Rezervasyon r join Musteri m on r.RezervasyonID=m.RezervasyonID where m.RezervasyonID=@id and m.IsActive=1", con);
            cmd.Parameters.AddWithValue("@id", ID);


            List<Musteri> musteriler = new List<Musteri>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    musteriler.Add(new Musteri()
                    {
                        MusteriID = (int)dr["MusteriID"],
                        Ad = dr["Ad"].ToString(),
                        Soyad = dr["Soyad"].ToString(),
                        TCKN = dr["TCKN"].ToString(),
                        Telefon = dr["Telefon"].ToString(),
                        Email = dr["Email"].ToString(),
                        //IsActive=(bool)dr["IsActive"]


                    });
                }
                dr.Close();
                return musteriler;
            }
            catch (Exception ex)
            {

                return musteriler;
            }
        }
        public int Update(Musteri musteri)
        {
            cmd = new SqlCommand("update Musteri set Ad = @ad, Soyad = @soyad, TCKN = @tckn, Telefon = @telefon, Email = @email where MusteriID = @musteriID", con);
            cmd.Parameters.AddWithValue("@ad", musteri.Ad);
            cmd.Parameters.AddWithValue("@soyad", musteri.Soyad);
            cmd.Parameters.AddWithValue("@tckn", musteri.TCKN);
            cmd.Parameters.AddWithValue("@telefon", musteri.Telefon);
            cmd.Parameters.AddWithValue("@email", musteri.Email);
            cmd.Parameters.AddWithValue("@musteriID", musteri.MusteriID);

            return ExecuteCommand();
        }

        /// <summary>
        /// İptal işleminde kaydedilen müşterinin durumu pasif olarak güncellenir.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateStatus(int ID)
        {
            cmd = new SqlCommand("update Musteri set IsActive=0 where MusteriID = @musteriID", con);
            
            cmd.Parameters.AddWithValue("@musteriID", ID);

            return ExecuteCommand();
        }
    }
}
