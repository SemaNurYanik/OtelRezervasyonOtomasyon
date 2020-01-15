using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class RezervasyonDAL : BaseConnection, ICrud<Rezervasyon>
    {
        public int Add(Rezervasyon entity)
        {
            cmd = new SqlCommand("insert into Rezervasyon(UyeID,GirisTarihi,BitisTarihi,ToplamKisiSayisi,RezervasyonTipID,ToplamFiyat,IsActive) values(@uyeID,@girisTarihi,@bitisTarihi,@toplamKisiSayisi,@rezervasyonTipID,@toplamFiyat,1) Select cast(SCOPE_IDENTITY() as int) ", con);
            cmd.Parameters.AddWithValue("@uyeID", entity.UyeID);
            cmd.Parameters.AddWithValue("@girisTarihi", entity.GirisTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", entity.CikisTarihi);
            cmd.Parameters.AddWithValue("@toplamKisiSayisi", entity.ToplamKisiSayisi);
            cmd.Parameters.AddWithValue("@rezervasyonTipID", entity.RezervasyonTipID);
            cmd.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
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

        public List<Rezervasyon> GetAllRezervasyonTipID(int ID)
        {
            cmd = new SqlCommand("select *  from Rezervasyon where IsActive = 1 and RezervasyonTipID=@id", con);

            cmd.Parameters.AddWithValue("@id", ID);
            List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    rezervasyonlar.Add(new Rezervasyon()
                    {
                        RezervasyonID = (int)dr["RezervasyonID"],
                        UyeID = (int)dr["UyeID"],
                        GirisTarihi = DateTime.Parse(dr["GirisTarihi"].ToString()),
                        CikisTarihi = DateTime.Parse(dr["BitisTarihi"].ToString()),
                        ToplamKisiSayisi = (int)dr["ToplamKisiSayisi"],
                        RezervasyonTipID = (int)dr["RezervasyonTipID"],
                        ToplamFiyat = Convert.ToDecimal(dr["ToplamFiyat"]),
                        //IsActive = (bool)dr["IsActive"]

                    });
                }
                dr.Close();
                return rezervasyonlar;
            }
            catch (Exception ex)
            {

                return rezervasyonlar;
            }
        }
        public List<Rezervasyon> GetAll()
        {
            cmd = new SqlCommand("select *  from Rezervasyon where IsActive = 1", con);
            List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    rezervasyonlar.Add(new Rezervasyon()
                    {
                        RezervasyonID = (int)dr["RezervasyonID"],
                        UyeID = (int)dr["UyeID"],
                        GirisTarihi = DateTime.Parse(dr["GirisTarihi"].ToString()),
                        CikisTarihi = DateTime.Parse(dr["BitisTarihi"].ToString()),
                        ToplamKisiSayisi = (int)dr["ToplamKisiSayisi"],
                        RezervasyonTipID = (int)dr["RezervasyonTipID"],
                        ToplamFiyat = Convert.ToDecimal(dr["ToplamFiyat"]),
                        //IsActive = (bool)dr["IsActive"]

                    });
                }
                dr.Close();
                return rezervasyonlar;
            }
            catch (Exception ex)
            {

                return rezervasyonlar;
            }
        }
        public Rezervasyon GetByID(int ID)
        {
            cmd = new SqlCommand("select * from Rezervasyon where RezervasyonID = @rezervasyonID", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", ID);
            Rezervasyon rezervasyon = new Rezervasyon();
            try
            {
                
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();
                rezervasyon.RezervasyonID = (int)dr["RezervasyonID"];
                rezervasyon.UyeID = (int)dr["UyeID"];
                rezervasyon.GirisTarihi = DateTime.Parse(dr["GirisTarihi"].ToString());
                rezervasyon.CikisTarihi = DateTime.Parse(dr["BitisTarihi"].ToString());
                rezervasyon.ToplamKisiSayisi = (int)dr["ToplamKisiSayisi"];
                rezervasyon.RezervasyonTipID = (int)dr["RezervasyonID"];
                rezervasyon.ToplamFiyat = Convert.ToDecimal(dr["ToplamFiyat"]);
                rezervasyon.IsActive = (bool)dr["IsActive"];
                dr.Close();
                return rezervasyon;
            }
            catch (Exception ex)
            {

                return rezervasyon;
            }
        }

        public int Update(Rezervasyon entity)
        {
            cmd = new SqlCommand("update Rezervasyon set UyeID=@uyeID,GirisTarihi=@girisTarihi,BitisTarihi=@bitisTarihi,ToplamKisiSayisi=@toplamKisiSayisi,RezervasyonTipID=@rezervasyonTipID,ToplamFiyat=@toplamFiyat where RezervasyonID=@rezervasyonID", con);
            cmd.Parameters.AddWithValue("@uyeID", entity.UyeID);
            cmd.Parameters.AddWithValue("@girisTarihi", entity.GirisTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", entity.CikisTarihi);
            cmd.Parameters.AddWithValue("@toplamKisiSayisi", entity.ToplamKisiSayisi);
            cmd.Parameters.AddWithValue("@rezervasyonTipID", entity.RezervasyonTipID);
            cmd.Parameters.AddWithValue("@rezervasyonID", entity.RezervasyonID);
            cmd.Parameters.AddWithValue("@toplamFiyat", entity.ToplamFiyat);
            return ExecuteCommand();
        }


        /// <summary>
        /// İptal İşleminde Oluşturulan Rezervasyonun Durumu Pasif Olarak Güncellenir.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int UpdateStatus(int ID)
        {
            cmd = new SqlCommand("update Rezervasyon set IsActive = 0 where RezervasyonID=@rezervasyonID", con);
            cmd.Parameters.AddWithValue("@rezervasyonID", ID);
            return ExecuteCommand();
        }
    }
}
