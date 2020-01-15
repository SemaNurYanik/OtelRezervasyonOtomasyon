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
    public partial class frmYeniRezervasyonOnay : MaterialForm
    {
        List<Musteri> musteriList = new List<Musteri>();
        List<Rezervasyon> rezervasyonList = new List<Rezervasyon>();

        RezervasyonTipBLL _rezervasyonTipBLL;
        OdaBLL _odaBLL;
        MusteriBLL _musteriBLL;
        RezervasyonBLL _rezervasyonBLL;
        MusteriRezervasyonBLL _musteriRezervasyonBLL;

        int hesaplananOdaSayisi = 0;
        decimal toplamRezervasyonFiyati = 0;
        int haftasonuSayisi = 0;
        int _uyeID;
        public frmYeniRezervasyonOnay(List<Musteri> musteriler, List<Rezervasyon> rezervasyonlar, int hesaplananOda,int uyeID)
        {
            InitializeComponent();
            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);

            hesaplananOdaSayisi = hesaplananOda;
            _uyeID = uyeID;

            musteriList = musteriler;
            rezervasyonList = rezervasyonlar;

            _rezervasyonTipBLL = new RezervasyonTipBLL();
            _odaBLL = new OdaBLL();
            _musteriBLL = new MusteriBLL();
            _rezervasyonBLL = new RezervasyonBLL();
            _musteriRezervasyonBLL = new MusteriRezervasyonBLL();
        }

        private void frmYeniRezervasyonOnay_Load(object sender, EventArgs e)
        {       
            //Müşteri Listesini Doldurur (Rezervasyon Bilgileriyle Birlikte)
            foreach (var item in musteriList)
            {
                foreach (var item1 in rezervasyonList)
                {
                    string rezervasyonTipAdi = _rezervasyonTipBLL.GetByID(item1.RezervasyonTipID).RezervasyonTipAd;
                    string[] bilgiler = new string[]
                    {
                        item1.GirisTarihi.ToShortDateString(),
                        item1.CikisTarihi.ToShortDateString(),
                        rezervasyonTipAdi,
                        item.Ad,
                        item.Soyad,
                        item.TCKN,
                        item.Email,
                        item.Telefon
                    };

                    ListViewItem lvi = new ListViewItem(bilgiler);
                    lvi.Tag = item;
                    lvMusteriOnay.Items.Add(lvi);
                }

            }

            //Kişi sayısına göre kaç oda gerekli onun sayısını getirir
            lblOdaSayisi.Text = hesaplananOdaSayisi.ToString();

            
            int rezervastonTipID = rezervasyonList[0].RezervasyonTipID; //List içinden ID alıyoruz.
            string rezervasyonTipAd = lvMusteriOnay.Items[0].SubItems[2].Text; //listview içinden rezervasyon tip adını alıyoruz.
            string rezervasyonTipAciklama= _rezervasyonTipBLL.GetByID(rezervastonTipID).RezervasyonTipAciklama; //rezervasyon tip ID'ye göre açıklamasını alıyoruz.

            int kisiSayisi = lvMusteriOnay.Items.Count; //Rezervasyonda kaç müşteri var onu buluyoruz.
            int odadakiKisiSayisi = 0; //Oda başına kaç kişi kalacak onu hesaplayacağız daha sonra.

            //listview'den tarih bilgilerini alıyoruz.
            DateTime girisTarihi =DateTime.Parse(lvMusteriOnay.Items[0].SubItems[0].Text);
            DateTime cikisTarihi = DateTime.Parse(lvMusteriOnay.Items[0].SubItems[1].Text);
            // Tarih aralığında kaç haftasonu varsa o kadar %30 ilave edilecek
         

            //İki tarih arasında 1 gün artırarak o gün cumartesi mi diye sayacak varsa haftasonuSayisi'ni 1 artıracak
            for (DateTime i = girisTarihi; i < cikisTarihi; i=i.AddDays(1))
            {
                if (i.DayOfWeek == DayOfWeek.Saturday || i.DayOfWeek == DayOfWeek.Sunday)
                {
                    haftasonuSayisi++;
                }
            }

            
            //Kaç odam rezervasyona müsait onun bilgilerini getiriyoruz.
            List<Oda> hesaplananOdaList = _odaBLL.BosOdaGetir(hesaplananOdaSayisi);

            foreach (var item in hesaplananOdaList)
            {
                //Oda başına kaç kişi kalacak onu hesaplıyoruz. Her odada max 3 kişi kalacak şekilde kişi sayısını odalara dağıtıyoruz.
               
                    if (kisiSayisi >= 3 && kisiSayisi % 3 >= 0)
                    {
                        odadakiKisiSayisi = 3;
                    }
                    else
                    {
                        odadakiKisiSayisi = kisiSayisi % 3;
                    }

                    kisiSayisi -= odadakiKisiSayisi;
                

                #region Oda Fiyatı Hesaplaması

                decimal sbtFiyat = _odaBLL.GetByID(item.OdaID).Fiyat; //Odaların işlemsiz fiyat hali
                int ucKisiKalmaOrani = _odaBLL.GetByID(item.OdaID).MaxKisiSayisi; // %20 ilave olacak fiyata
                int birKisiKalmaOrani = _odaBLL.GetByID(item.OdaID).MinKisiSayisi; // %30 fiyattan düşülecek
                int haftasonuKalmaOrani = _odaBLL.GetByID(item.OdaID).HaftaSonuOranı; // %30 ilave olacak
                
                if (odadakiKisiSayisi == 3)
                {
                    if (haftasonuSayisi != 0)
                    {
                        // İlave yatak olduğu için %20 eklendi, haftasonu olduğundan haftasonu sayısı kadar %30 ilave edildi
                        sbtFiyat = sbtFiyat + (0.2m * sbtFiyat) + (0.3m * haftasonuSayisi * sbtFiyat);
                    }
                    else
                    {
                        //Haftasonu yok sadece ilave yatak olduğundan %20 ilave edildi
                        sbtFiyat = sbtFiyat + (0.2m * sbtFiyat);
                    }
                }
                else if (odadakiKisiSayisi == 1)
                {
                    if (haftasonuSayisi != 0)
                    {
                        // 1 Yatak çıkarıldığından %30 fiyattan düşülecek, haftasonu olduğundan haftasonu kadar %30 eklenecek
                        sbtFiyat = sbtFiyat - (0.3m * sbtFiyat) + (0.3m * haftasonuSayisi * sbtFiyat);
                    }
                    else
                    {
                        //Haftasonu olmadığından sadece fiyattan %30 düşülecek
                        sbtFiyat = sbtFiyat - (0.3m * sbtFiyat);
                    }
                }
                else
                {
                    //Odada 2 Kişi kalıyor demektir. Yani sabit fiyat değişmeyecek
                    if (haftasonuSayisi !=0)
                    {
                        //Haftasonu varsa haftasonu sayısı kadar fiyata %30 eklenecek
                        sbtFiyat = sbtFiyat + (0.3m * sbtFiyat * haftasonuSayisi);
                    }
                    
                }
                #endregion

                string[] bilgiler = new string[]
                {
                    item.OdaID.ToString(),
                    odadakiKisiSayisi.ToString(),
                    rezervasyonTipAd,
                    rezervasyonTipAciklama,
                    sbtFiyat.ToString()
                };
                ListViewItem lvi = new ListViewItem(bilgiler);
                lvi.Tag = item;
                lvOdaBilgisi.Items.Add(lvi);
            }
        
            for (int i = 0; i < lvOdaBilgisi.Items.Count; i++)
            {
                toplamRezervasyonFiyati += Convert.ToDecimal(lvOdaBilgisi.Items[i].SubItems[4].Text);
            }
            lblToplamFiyat.Text = toplamRezervasyonFiyati.ToString("#.##");
        }
       
        private void btnOnayIptal_Click(object sender, EventArgs e)
        {
            lvMusteriOnay.Items.Clear();
            this.Close();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
         
            //Rezervasyon tablosuna ekleme yapılacak
            Rezervasyon yeniRezervasyon = new Rezervasyon();
            int rezervasyonID = 0;
            int musteriID = 0;
            foreach (var item in rezervasyonList)
            {
                yeniRezervasyon.GirisTarihi = item.GirisTarihi;
                yeniRezervasyon.CikisTarihi = item.CikisTarihi;
                yeniRezervasyon.ToplamKisiSayisi = item.ToplamKisiSayisi;
                yeniRezervasyon.RezervasyonTipID = item.RezervasyonTipID;
                yeniRezervasyon.ToplamFiyat = toplamRezervasyonFiyati;
                yeniRezervasyon.UyeID = _uyeID; 
                rezervasyonID = _rezervasyonBLL.Add(yeniRezervasyon);
                
            }

            //Verilen odaların durumları false yapılacak
            Oda tutulanOda = new Oda();
            for (int i = 0; i < lvOdaBilgisi.Items.Count; i++)
            {
                tutulanOda.OdaID = Convert.ToInt32(lvOdaBilgisi.Items[i].SubItems[0].Text);
                tutulanOda.KisiSayisi = Convert.ToInt32(lvOdaBilgisi.Items[i].SubItems[1].Text);
                tutulanOda.HaftaSonuSayisi = haftasonuSayisi;
                tutulanOda.RezervasyonID = rezervasyonID;
                tutulanOda.Durum = false;
                _odaBLL.TutulanOdaGuncelle(tutulanOda);
            }
            //Müşteri bilgileri müşteri tablosuna eklenecek
            Musteri yeniMusteri = new Musteri();
            List<int> musteriIDs = new List<int>();
            for (int i = 0; i < lvOdaBilgisi.Items.Count; i++)
            {
             
                int odadakiKisiSayisi = Convert.ToInt32(lvOdaBilgisi.Items[i].SubItems[1].Text);
                for (int j = 0; j < odadakiKisiSayisi; j++)
                {
                    yeniMusteri.Ad = lvMusteriOnay.Items[j].SubItems[3].Text;
                    yeniMusteri.Soyad = lvMusteriOnay.Items[j].SubItems[4].Text;
                    yeniMusteri.TCKN = lvMusteriOnay.Items[j].SubItems[5].Text;
                    yeniMusteri.Email = lvMusteriOnay.Items[j].SubItems[6].Text;
                    yeniMusteri.Telefon = lvMusteriOnay.Items[j].SubItems[7].Text;
                    yeniMusteri.RezervasyonID = rezervasyonID;
                    yeniMusteri.OdaID = Convert.ToInt32(lvOdaBilgisi.Items[i].SubItems[0].Text);
                    musteriID = _musteriBLL.Add(yeniMusteri);
                    musteriIDs.Add(musteriID);
                }
                
            }
            //İlişki tablosu doldurulacak
            MusteriRezervasyon musteriRezervasyon = new MusteriRezervasyon();            
                foreach (var item in musteriIDs)
                {
                    Musteri musteri = _musteriBLL.GetByID(item);
                    musteriRezervasyon.MusteriID = musteri.MusteriID;
                    musteriRezervasyon.OdaID = musteri.OdaID;
                    musteriRezervasyon.RezervasyonID = musteri.RezervasyonID;
                    _musteriRezervasyonBLL.Add(musteriRezervasyon);
                }   

            MessageBox.Show("Rezervasyon Kaydedildi");
            this.Close();
            
        }

       
    }
}
