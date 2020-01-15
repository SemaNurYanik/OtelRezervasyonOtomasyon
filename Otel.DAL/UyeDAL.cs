using Otel.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otel.DAL
{
    public class UyeDAL : BaseConnection, ICrud<Uye>
    {
        public UyeDAL()
        {

        }

        public int Add(Uye entity)
        {
            cmd = new SqlCommand("insert into Uye(Email,Sifre,IsAdmin) values(@email,@sifre,0)", con);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@sifre", entity.Sifre);
            return ExecuteCommand();

        }
        
        public List<Uye> GetAll()
        {
            cmd = new SqlCommand("select * from Uye", con);
            List<Uye> uyeler = new List<Uye>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    uyeler.Add(new Uye()
                    {
                        UyeID = (int)dr["UyeID"],
                        Email = dr["Email"].ToString(),
                        Sifre = dr["Sifre"].ToString(),
                        AdminMi = (bool)dr["IsAdmin"]
                    });
                }
                dr.Close();
                return uyeler;
            }
            catch (Exception ex)
            {

                return uyeler;
            }
        }

        public Uye GetByID(int ID)
        {
            cmd = new SqlCommand("select * from Uye where UyeID = @uyeID", con);
            cmd.Parameters.AddWithValue("@uyeID", ID);
            Uye uye = new Uye();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();

                uye.UyeID = (int)dr["UyeID"];
                uye.Email = dr["Email"].ToString();
                uye.Sifre = dr["Sifre"].ToString();
                uye.AdminMi = (bool)dr["IsAdmin"];
                dr.Close();
                return uye;

            }
            catch (Exception ex)
            {

                return uye;
            }
        }

        public int Update(Uye entity)
        {
            cmd = new SqlCommand("update Uye set Email=@email,Sifre=@sifre where UyeID=@uyeID", con);
            cmd.Parameters.AddWithValue("@email", entity.Email);
            cmd.Parameters.AddWithValue("@sifre", entity.Sifre);
            cmd.Parameters.AddWithValue("@uyeID", entity.UyeID);
            return ExecuteCommand();
        }
        public bool UyeMi(string email, string sifre)
        {
            cmd = new SqlCommand("select count(*) from Uye where Email=@email and Sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            con.Open();
            int sonuc = (int)cmd.ExecuteScalar();
            con.Close();
            if (sonuc == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public Uye UyeGetir(string email, string sifre)
        {
            cmd = new SqlCommand("select * from Uye where Email=@email and Sifre=@sifre", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            Uye uye = null;
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                dr.Read();
                uye = new Uye()
                {
                    UyeID = (int)dr["UyeID"],
                    Email = dr["Email"].ToString(),
                    Sifre = dr["Sifre"].ToString(),
                    AdminMi = (bool)dr["IsAdmin"]

                };
                dr.Close();
                return uye;
            }
            catch (Exception ex)
            {

                return uye;
            }
        }
        public bool AdminMi(string email, string sifre)
        {
            cmd = new SqlCommand("select count(*) from Uye where Email=@email and Sifre=@sifre and IsAdmin=1", con);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@sifre", sifre);
            con.Open();
            int sonuc = (int)cmd.ExecuteScalar();
            con.Close();
            if (sonuc == 1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        /// <summary>
        /// Giriş Yapan Kullanıcının Rezervasyon Bilgilerini Getirir.
        /// 
        /// </summary>
        /// <param name="uyeID"></param>
        /// <returns></returns>
        public List<UyeRezervasyonlari> UyeRezervasyonGetir(int uyeID)
        {
            cmd = new SqlCommand("select r.RezervasyonID,GirisTarihi,BitisTarihi,ToplamKisiSayisi,rt.Ad from Rezervasyon as r join RezervasyonTip as rt on rt.RezervasyonTipID = r.RezervasyonTipID where UyeID=@uyeID and r.IsActive = 1", con);
            cmd.Parameters.AddWithValue("@uyeID", uyeID);
            List<UyeRezervasyonlari> uyeRezervasyonlari = new List<UyeRezervasyonlari>();
            try
            {
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    uyeRezervasyonlari.Add(new UyeRezervasyonlari()
                    {
                        RezervasyonID = (int)dr["RezervasyonID"],                        
                        GirisTarihi = DateTime.Parse(dr["GirisTarihi"].ToString()),
                        CikisTarihi = DateTime.Parse(dr["BitisTarihi"].ToString()),
                        ToplamKisiSayisi = (int)dr["ToplamKisiSayisi"],
                        RezervasyonTipi = dr["Ad"].ToString()
                    });
                }
                dr.Close();
                return uyeRezervasyonlari;
            }
            catch (Exception ex)
            {

                return uyeRezervasyonlari;
            }
        }
    }
}
