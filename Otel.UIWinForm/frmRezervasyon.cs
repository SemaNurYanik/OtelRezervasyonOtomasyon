using MaterialSkin;
using MaterialSkin.Controls;
using Otel.BLL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel.UIWinForm
{
    public partial class frmRezervasyon : MaterialForm
    {
        UyeBLL _uyeBLL;
        Uye girisYapan;
        MusteriRezervasyonBLL _musteriRezervasyonBLL;
        MusteriBLL _musteriBLL;
        RezervasyonBLL _rezervasyonBLL;
        OdaBLL _odaBLL;
      
        string _email,_sifre;
        string durumAciklama = String.Empty;
        int girisKalanGun = 0;       
        public frmRezervasyon(string email,string sifre)
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);

            _uyeBLL = new UyeBLL();
            _musteriRezervasyonBLL = new MusteriRezervasyonBLL();
            _musteriBLL = new MusteriBLL();
            _rezervasyonBLL = new RezervasyonBLL();
            _odaBLL = new OdaBLL();
            
            _email = email;
            _sifre = sifre;
        }

        private void frmRezervasyon_Load(object sender, EventArgs e)
        {
            girisYapan = _uyeBLL.UyeGetir(_email, _sifre); //Giriş Yapan Üyenin Bilgilerini Getirir.

            lblEmail.Text = girisYapan.Email;

            //Kullanıcı Admin ise Yönetim Paneli Butonu Aktifleşir
            if (girisYapan.AdminMi)
            {
                btnYonetici.Visible = true;
            }
            else
            {
                btnYonetici.Visible = false;

            }
            //Giriş Yapan Kullanıcının Tüm Rezervasyonlarını Getirir.
            RezervasyonListeDoldur();
        }

        private void btnYeniRezervasyon_Click(object sender, EventArgs e)
        {
            frmYeniRezervasyon frm = new frmYeniRezervasyon(girisYapan.UyeID);
            frm.UpdatedList += RezervasyonListeDoldur;           
            frm.ShowDialog();
        }

        private void btnYonetici_Click(object sender, EventArgs e)
        {
            frmYoneticiPaneli frm = new frmYoneticiPaneli();
            frm.ShowDialog();
           
        }

        void RezervasyonListeDoldur()
        {
            lvUyeRezervasyon.Items.Clear();
            List<UyeRezervasyonlari> uyeRezervasyonlari = _uyeBLL.UyeRezervasyonGetir(girisYapan.UyeID);
            
            foreach (var item in uyeRezervasyonlari)
            {
                girisKalanGun = item.DurumBilgisiGuncelle(); //Rezervasyon Giriş Tarihine Kalan Gün Hesaplanır.

                string[] bilgiler = new string[]
                {
                    item.RezervasyonID.ToString(),                  
                    item.GirisTarihi.ToShortDateString(),
                    item.CikisTarihi.ToShortDateString(),
                    item.ToplamKisiSayisi.ToString(),
                    item.RezervasyonTipi,
                    item.DurumBilgisi                    
                };
                ListViewItem lvi = new ListViewItem(bilgiler);
                lvi.Tag = item;
                lvUyeRezervasyon.Items.Add(lvi);
            }
        }
        private void iptalEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (girisKalanGun >= 10)
            {
                List<MusteriRezervasyon> musteriRezervasyon = _musteriRezervasyonBLL.GetByRezervasyonID(RezervasyonIDGetir());
                foreach (var item in musteriRezervasyon)
                {
                    int musteriID = item.MusteriID;
                    int rezervasyonID = item.RezervasyonID;
                    int odaID = item.OdaID;

                    _musteriBLL.UpdateStatus(musteriID);
                    _rezervasyonBLL.UpdateStatus(rezervasyonID);
                    _odaBLL.PasifOda(odaID);
                    RezervasyonListeDoldur();

                }
            }
            else
            {
                MessageBox.Show("Giriş Tarihine En Az 10 Kala İptal İşlemi Yapılabilir.");
            }
        }

        /// <summary>
        /// Listeden Seçilen Kaydın Rezervasyon ID Bilgisini Getirir.
        /// </summary>
        /// <returns></returns>
        int RezervasyonIDGetir()
        {
            ListViewItem lvi = lvUyeRezervasyon.FocusedItem;
            UyeRezervasyonlari rezervasyon = (UyeRezervasyonlari)lvi.Tag;
            return rezervasyon.RezervasyonID;
        }
    }
}
