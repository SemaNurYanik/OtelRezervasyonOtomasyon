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
    public partial class frmYeniRezervasyon : MaterialForm
    {
        public event UpdateList UpdatedList;

        RezervasyonBLL _rezervasyonBLL;
        RezervasyonTipBLL _rezervasyonTipBLL;
        OdaBLL _odaBLL;

        public List<Musteri> musteriler = new List<Musteri>();
        public List<Rezervasyon> rezervasyonlar = new List<Rezervasyon>();

        int kisiSayi = 0;
        public int hesaplananOda = 0;
        int _uyeID = 0;
        public frmYeniRezervasyon(int uyeID)
        {
            InitializeComponent();

            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);

            _rezervasyonBLL = new RezervasyonBLL();
            _rezervasyonTipBLL = new RezervasyonTipBLL();
            _odaBLL = new OdaBLL();
            gbMusteri.Visible = false;
            _uyeID = uyeID;
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            btnOnay.Visible = true;
            nudKisiSayisi.Enabled = false;


            if (nudKisiSayisi.Value != 0)
            {
                btnMusteriIptal.Visible = true;

            }

            kisiSayi = Convert.ToInt32(nudKisiSayisi.Value); //Kaydedilecek Müşteri Sayısı            

            #region Kişi Sayısına Göre Oda Hesaplama
            if (kisiSayi % 3 != 0)
            {
                hesaplananOda = (kisiSayi / 3) + 1;
            }
            else
            {
                hesaplananOda = kisiSayi / 3;
            } 
            #endregion

            int bosOdaSayisi = _odaBLL.BosOdaSayisi().Count; //Oda Tablosunda Durumu Aktif Olanları Getirir.

            //Eğer yeteri kadar oda varsa belirtilen kişi sayısı kadar müşteri kayıt alanları açılır.
            if (hesaplananOda > bosOdaSayisi)
            {
                MessageBox.Show("Yeterli Oda Bulunmamaktadır");
            }
            else
            {
                GroupBox groupBox;

                for (int i = 0; i < kisiSayi; i++)
                {
                    groupBox = new GroupBox();
                    groupBox.AutoSize = true;
                    groupBox.BackColor = Color.White;
                    groupBox.Text = $"{i + 1}. Müşteri Bilgileri";

                    foreach (var item in gbMusteri.Controls)
                    {
                        if (item is Label)
                        {
                            Label lbl = new Label();
                            Label lblClone = (Label)item;
                            lbl.AutoSize = lblClone.AutoSize;
                            lbl.Location = lblClone.Location;
                            lbl.Name = lblClone.Name;
                            lbl.Size = lblClone.Size;
                            lbl.TabIndex = lblClone.TabIndex;
                            lbl.Text = lblClone.Text;                            
                            groupBox.Controls.Add(lbl);
                        }
                        if (item is MaterialSingleLineTextField)
                        {
                            MaterialSingleLineTextField txt = new MaterialSingleLineTextField();
                            MaterialSingleLineTextField txtClone = (MaterialSingleLineTextField)item;
                            txt.Depth = txtClone.Depth;
                            txt.Hint = txtClone.Hint;
                            txt.Location = txtClone.Location;
                            txt.MouseState = txtClone.MouseState;
                            txt.Name = txtClone.Name;
                            txt.PasswordChar = txtClone.PasswordChar;
                            txt.SelectedText = txtClone.SelectedText;
                            txt.SelectionLength = txtClone.SelectionLength;
                            txt.SelectionStart = txtClone.SelectionStart;
                            txt.Size = txtClone.Size;
                            txt.TabIndex = txtClone.TabIndex;
                            txt.UseSystemPasswordChar = txtClone.UseSystemPasswordChar;
                            groupBox.Controls.Add(txt);

                            if (txt.Name == "txtMusteriTc" || txt.Name == "txtMusteriTel")
                            {
                                txt.KeyPress += txt_KeyPress;

                            }
                            else if (txt.Name == "txtMusteriEmail")
                            {

                            }
                            else
                            {
                                txt.KeyPress += txtharf_KeyPress;
                            }

                        }
                        if (item is MaterialRaisedButton)
                        {
                            MaterialRaisedButton btn = new MaterialRaisedButton();
                            MaterialRaisedButton btnClone = (MaterialRaisedButton)item;
                            btn.Depth = btnClone.Depth;
                            btn.Location = btnClone.Location;
                            btn.MouseState = btnClone.MouseState;
                            btn.Name = btnClone.Name;
                            btn.Primary = btnClone.Primary;
                            btn.Size = btnClone.Size;
                            btn.TabIndex = btnClone.TabIndex;
                            btn.Text = btnClone.Text;
                            btn.UseVisualStyleBackColor = btnClone.UseVisualStyleBackColor;
                            if (btn.Name == "btnMusteriEkle")
                            {
                                btn.Click += MusteriOnayListesiDoldur;
                            }
                            if (btn.Name == "btnMusteriSil")
                            {
                                btn.Visible = false;
                            }

                            groupBox.Controls.Add(btn);
                        }
                      
                    }
                    flpMusteri.Controls.Remove(gbMusteri);
                    flpMusteri.Controls.Add(groupBox);

                }
            }

            Rezervasyon rezervasyon = new Rezervasyon();
            rezervasyon.GirisTarihi = dtGiris.Value;
            rezervasyon.CikisTarihi = dtBitis.Value;
            rezervasyon.ToplamKisiSayisi = kisiSayi;
            rezervasyon.RezervasyonTipID = (int)cmbRezervasyonTip.SelectedValue;
            rezervasyonlar.Add(rezervasyon);

            materialRaisedButton1.BackColor = Color.Gray;
            materialRaisedButton1.Enabled = false;
        }

        /// <summary>
        /// Alanlara Sadece Harf Girilmesini Sağlar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtharf_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                && !char.IsSeparator(e.KeyChar);
        }

        /// <summary>
        /// Alanlara Sadece Sayı Girilmesini Sağlar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        /// <summary>
        /// Rezervasyon Onay Bilgilerini Doldurur.
        /// Eğer Boş Alanlar Varsa Kullanıcı Onay Sayfasına Gidemez
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MusteriOnayListesiDoldur(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Control control = btn.Parent;          
            Musteri musteri = new Musteri();
          
            foreach (Control item in control.Controls)
            {
              
                if (item.Name == "txtMusteriAd")
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurun.");
                        return;
                    }
                    musteri.Ad = item.Text;
                }
                if (item.Name == "txtMusteriSoyad")
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurun. ");
                        return;
                    }
                    musteri.Soyad = item.Text;
                }

                if (item.Name == "txtMusteriTc")
                {
                    musteri.TCKN = item.Text;
                    if (item.Text.Length != 11)
                    {
                        MessageBox.Show("Tc Kimlik Numarası 11 Haneli Olmalıdır.");
                        return;
                    }
                    foreach (var item2 in musteriler)
                    {
                        if (item2.TCKN == musteri.TCKN)
                        {
                            MessageBox.Show("Bu T.C. numarası var.");
                            return;
                        }
                    }

                }
                if (item.Name == "txtMusteriEmail")
                {
                    if (string.IsNullOrEmpty(item.Text))
                    {
                        MessageBox.Show("Lütfen gerekli alanları doldurun.");
                        return;
                    }
                    musteri.Email = item.Text;
                }
                if (item.Name == "txtMusteriTel")
                {
                    musteri.Telefon = item.Text;
                }
                if (item.Name == "pictureBox1")
                {
                    item.Enabled = true;
                }
               

            }

            musteriler.Add(musteri);
            MessageBox.Show($"Ad : {musteri.Ad}\nSoyad : {musteri.Soyad}\nTCNo : {musteri.TCKN}\nEmail : {musteri.Email}\nTelefon : {musteri.Telefon}");
            btn.Enabled = false;

        }        

        private void frmYeniRezervasyon_Load(object sender, EventArgs e)
        {
            List<RezervasyonTip> rezervasyonTipleri = _rezervasyonTipBLL.GetAll();
            foreach (var item in rezervasyonTipleri)
            {
                cmbRezervasyonTip.DataSource = rezervasyonTipleri;
                cmbRezervasyonTip.DisplayMember = "RezervasyonTipAd";
                cmbRezervasyonTip.ValueMember = "RezervasyonTipID";
            }

            dtGiris.MinDate = DateTime.Now; //Kullanıcı Geçmiş Tarih Seçmemesi için Tarih o gün neyse ona ayarlanır. 
            dtBitis.MinDate = dtGiris.Value.AddDays(1); //Çıkış tarihi giriş tarihi ile aynı olamayacağından bir gün sonrasından başlar.
            btnOnay.Visible = false;

        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            if (musteriler.Count == 0)
            {
                MessageBox.Show("Müşteri Eklemediniz","HATA !!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            else
            {
                dtGiris.Value = DateTime.Now;
                dtBitis.Value = DateTime.Now.AddDays(1);
                nudKisiSayisi.Value = 1;
                cmbRezervasyonTip.SelectedIndex = -1;
                flpMusteri.Controls.Clear();
                frmYeniRezervasyonOnay frm = new frmYeniRezervasyonOnay(musteriler, rezervasyonlar, hesaplananOda, _uyeID);
                frm.ShowDialog();
                musteriler.Clear();
                rezervasyonlar.Clear();
                hesaplananOda = 0;
                this.Close();
            }
          
        }

        private void dtGiris_ValueChanged(object sender, EventArgs e)
        {
            //Giriş Tarihi ne seçilmişse Çıkış tarihinin 1 gün sonrasına ayarlanmasını sağlar.
            dtBitis.MinDate = dtGiris.Value.AddDays(1);
        }

        private void frmYeniRezervasyon_FormClosed(object sender, FormClosedEventArgs e)
        {
            UpdatedList();
        }

        private void BtnMusteriIptal_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
