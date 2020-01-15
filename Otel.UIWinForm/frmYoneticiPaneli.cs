using MaterialSkin;
using MaterialSkin.Controls;
using Otel.BLL;
using Otel.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Otel.UIWinForm
{
    public partial class frmYoneticiPaneli : MaterialForm
    {
        OdaBLL _odaBLL;
        Oda _oda;
        MusteriBLL _musteriBLL;
        Musteri _musteri;
        UyeBLL _uyeBLL;
        Uye _uye;
        RezervasyonBLL _rezervasyonBLL;
        Rezervasyon _rezervasyon;
        RezervasyonTipBLL _rezervasyonTipBLL;

        public frmYoneticiPaneli()
        {
            _rezervasyonTipBLL = new RezervasyonTipBLL();
            _odaBLL = new OdaBLL();
            _musteriBLL = new MusteriBLL();
            _uyeBLL = new UyeBLL();
            _rezervasyonBLL = new RezervasyonBLL();

            InitializeComponent();

            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);
        }

        /// <summary>
        /// Oda Bilgilerini Listeler
        /// </summary>
        private void FrmOda_ListviewDoldur()
        {
            lstOda.Items.Clear();
            List<Oda> oda = _odaBLL.GetAll();
            ListViewItem lvi;
            foreach (var item in oda)
            {
                string[] bilgiler = new string[]
                {
                item.OdaID.ToString(),
                item.KisiSayisi.ToString(),
                item.Fiyat.ToString(),
                item.Durum.ToString(),
                item.HaftaSonuSayisi.ToString(),
                item.HaftaSonuOranı.ToString(),
                item.MinKisiSayisi.ToString(),
                item.MaxKisiSayisi.ToString(),

                };
                lvi = new ListViewItem(bilgiler);
                lstOda.Items.Add(lvi);
                lvi.Tag = item;
            }
        }

        /// <summary>
        /// Kaydedilen Müşterileri Listeler
        /// </summary>
        private void FrmMusteri_ListviewDoldur()
        {
            lstMusteri.Items.Clear();
            List<Musteri> musteri = _musteriBLL.GetAll();
            ListViewItem lvi;
            foreach (var item in musteri)
            {
                string[] bilgiler = new string[]
                {
                item.MusteriID.ToString(),
                item.Ad.ToString(),
                item.Soyad.ToString(),
                item.TCKN.ToString(),
                item.Telefon.ToString(),
                item.Email.ToString()
                };
                lvi = new ListViewItem(bilgiler);
                lstMusteri.Items.Add(lvi);
            }

        }

        /// <summary>
        /// Üyeleri Listeler
        /// </summary>
        private void FrmUye_ListviewDoldur()
        {
            lstUye.Items.Clear();
            List<Uye> uye = _uyeBLL.GetAll();
            ListViewItem lvi;
            foreach (var item in uye)
            {
                string[] bilgiler = new string[]
                {
                    item.UyeID.ToString(),
                    item.Email.ToString(),
                    item.Sifre.ToString(),
                    item.AdminMi.ToString()

                };
                lvi = new ListViewItem(bilgiler);
                lstUye.Items.Add(lvi);
            }

        }

        /// <summary>
        /// Yönetim Panelinde Yapılan Rezervasyonları Listeler
        /// </summary>
        private void FrmRezervasyon_ListviewDoldur()
        {
            lstRezervasyon.Items.Clear();
            List<Rezervasyon> rezervasyon = _rezervasyonBLL.GetAll();
            ListViewItem lvi;
            foreach (var item in rezervasyon)
            {
                string[] bilgiler = new string[]
                {
                    item.RezervasyonID.ToString(),
                    item.GirisTarihi.ToString(),
                    item.CikisTarihi.ToString(),
                    item.RezervasyonTipID.ToString()

                };
                lvi = new ListViewItem(bilgiler);
                lvi.Tag = item;
                lstRezervasyon.Items.Add(lvi);
            }

        }
        /// <summary>
        /// Rezervasyon Tipine Göre Filtreleme Yapmak İçin Combobox Doldurulur
        /// </summary>
        void comboboxDoldur()
        {
            //Filtreleme Yapmadan Listelenmesini Sağlar
            RezervasyonTip bos = new RezervasyonTip();
            bos.RezervasyonTipID = 0;
            bos.RezervasyonTipAd = "Seçim Yok";

            List<RezervasyonTip> _rTList = _rezervasyonTipBLL.GetAll();
            _rTList.Insert(0, bos);
            comboBox1.ValueMember = "RezervasyonTipID";
            comboBox1.DisplayMember = "RezervasyonTipAd";
            comboBox1.DataSource = _rTList;
           
        }

        /// <summary>
        /// Seçilen Rezervasyonunun Müşterilerini Listeler
        /// </summary>
        private void FrmRezervasyonDetay_ListviewDoldur()
        {
            lstRezDet.Items.Clear();
            List<Musteri> musteri = _musteriBLL.GetByRezervasyonID(RezervasyonIDGetir());
            ListViewItem lvi;
            foreach (var item in musteri)
            {
                string[] bilgiler = new string[]
                {
                    item.MusteriID.ToString(),
                    item.Ad.ToString(),
                    item.Soyad,
                    item.TCKN,
                    item.Telefon,
                    item.Email

                };
                lvi = new ListViewItem(bilgiler);
                lvi.Tag = item;
                lstRezDet.Items.Add(lvi);
            }

        }    

        /// <summary>
        /// Odayı Boş Konuma Getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aktifEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _oda = new Oda();
            _oda.Durum = true;
            int id = OdaIDGetir();
            _oda.OdaID = Convert.ToInt32(id);
            _odaBLL.AktifOda(_oda);
            FrmOda_ListviewDoldur();
        }

        /// <summary>
        /// Odayı Dolu Konuma Getirir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pasifEtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _oda = new Oda();
            _oda.Durum = false;
            int id = OdaIDGetir();
            _oda.OdaID = Convert.ToInt32(id);
            _odaBLL.PasifOda(_oda);
            FrmOda_ListviewDoldur();
        }


        /// <summary>
        /// Listeden Seçilen Odanın ID'sini Getirir
        /// </summary>
        /// <returns></returns>
        int OdaIDGetir()
        {

            ListViewItem lvi = lstOda.FocusedItem;
            Oda oda = (Oda)lvi.Tag;

            oda = (Oda)lstOda.FocusedItem.Tag;
            return oda.OdaID;
        }

        /// <summary>
        /// Odaların Bilgilerini Günceller
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            _oda = new Oda();
            _oda.KisiSayisi = 0;
            _oda.Fiyat = Convert.ToDecimal(txtFiyat.Text);
            _oda.HaftaSonuOranı = Convert.ToInt32(txtHaftaSonuO.Text);
            _oda.MinKisiSayisi = Convert.ToInt32(txtMin.Text);
            _oda.MaxKisiSayisi = Convert.ToInt32(txtMax.Text);
            _odaBLL.Update(_oda);
            MessageBox.Show("Kayıt başarıyla güncellendi.");
            FrmOda_ListviewDoldur();
        }    

        int RezervasyonIDGetir()
        {
            ListViewItem lvi = lstRezervasyon.FocusedItem;
            Rezervasyon rezervasyon = (Rezervasyon)lvi.Tag;
            return rezervasyon.RezervasyonID;
        }

        decimal RezervasyonToplamFiyat()
        {
            ListViewItem lvi = lstRezervasyon.FocusedItem;
            Rezervasyon rezervasyon = (Rezervasyon)lvi.Tag;
            return rezervasyon.ToplamFiyat;
        }

        int OdaBilgileriniDoldur()
        {
            List<Oda> oda = _odaBLL.GetByRezarvasyonID(RezervasyonIDGetir());
            int odaSayisi = _odaBLL.OdaSayisiniGetir(RezervasyonIDGetir());
            int odaKisiSayisi = 0;
            flpOdaBilgisi.Controls.Clear();
            foreach (var item in oda)
            {
                Label lblOda = new Label();
                lblOda.Size = new Size(300, lblOda.Height);
                odaKisiSayisi = item.KisiSayisi;
                if (item.KisiSayisi == 3)
                {
                    lblOda.Text = $"Oda {item.OdaID} : {item.KisiSayisi} Kişilik (1 Yatak Eklendi)";
                }
                else if (item.KisiSayisi == 1)
                {
                    lblOda.Text = $"Oda {item.OdaID} : {item.KisiSayisi} Kişilik (1 Yatak Çıkarıldı)";
                }
                else
                {
                    lblOda.Text = $"Oda {item.OdaID} : {item.KisiSayisi} Kişilik";
                }

                flpOdaBilgisi.Controls.Add(lblOda);
            }
            return odaSayisi;
        }

        /// <summary>
        /// Seçilen Rezervasyonun Oda ve Fiyat Bilgilerini Doldurur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lstRezervasyon_MouseClick(object sender, MouseEventArgs e)
        {
            FrmRezervasyonDetay_ListviewDoldur();
            lbloda.Text = OdaBilgileriniDoldur().ToString();
            lblfiyat.Text = RezervasyonToplamFiyat().ToString("#.##");
        }


        /// <summary>
        /// Standart Kurallarla Oda Oluşturur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void materialRaisedButton2_Click(object sender, EventArgs e)
        {
            
              materialRaisedButton2.Enabled = true;
                if (txtOdaEkle.Text != string.Empty && txtOdaEkle.Text != null)
                {
                    int sayac = Convert.ToInt32(txtOdaEkle.Text);
                    _oda = new Oda();
                    for (int i = 0; i < sayac; i++)
                    {
                        _oda.RezervasyonID = 0;
                        _oda.KisiSayisi = 0;
                        _oda.HaftaSonuOranı = 30;
                        _oda.HaftaSonuSayisi = 0;
                        _oda.MaxKisiSayisi = 20;
                        _oda.MinKisiSayisi = 30;
                        _oda.Fiyat = 100;
                        _oda.Durum = true;
                        _odaBLL.Add(_oda);
                    }
                    FrmOda_ListviewDoldur();
                    MessageBox.Show("Odalar Başarıyla Eklendi", "BAŞARILI !!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    materialRaisedButton2.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Lütfen bir değer giriniz.", "HATA !!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            
           
        }

       
        /// <summary>
        /// Seçilen Tipe Göre Rezervasyon Listeler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstRezervasyon.Items.Clear();
            if ((int)comboBox1.SelectedValue == 0)
            {
                List<Rezervasyon> rezervasyonAll = _rezervasyonBLL.GetAll();
                ListViewItem lviAll;
                foreach (var item in rezervasyonAll)
                {
                    string[] bilgiler = new string[]
                    {
                   item.RezervasyonID.ToString(),
                   item.GirisTarihi.ToString(),
                   item.CikisTarihi.ToString(),
                   item.RezervasyonTipID.ToString()

                    };
                    lviAll = new ListViewItem(bilgiler);
                    lviAll.Tag = item;
                    lstRezervasyon.Items.Add(lviAll);
                }
            }
            else
            {
                List<Rezervasyon> rezervasyon = _rezervasyonBLL.GetAllRezervasyonTipID((int)comboBox1.SelectedValue);
                ListViewItem lvi;
                foreach (var item in rezervasyon)
                {
                    string[] bilgiler = new string[]
                    {
                   item.RezervasyonID.ToString(),
                   item.GirisTarihi.ToString(),
                   item.CikisTarihi.ToString(),
                   item.RezervasyonTipID.ToString()

                    };
                    lvi = new ListViewItem(bilgiler);
                    lvi.Tag = item;
                    lstRezervasyon.Items.Add(lvi);
                }
            }
           
        }

        private void frmYoneticiPaneli_Load_1(object sender, EventArgs e)
        {
            FrmOda_ListviewDoldur();
            FrmMusteri_ListviewDoldur();
            FrmUye_ListviewDoldur();
            FrmRezervasyon_ListviewDoldur();
            comboboxDoldur();


            //Eğer daha önceden oda eklenmişse bu alanı bir daha kullandırmamak için kaldırıyoruz
            int odaSayisi = _odaBLL.GetAll().Count;
            if (odaSayisi !=0)
            {
                groupBox3.Visible = false;
            }

        }

       
    }
}
