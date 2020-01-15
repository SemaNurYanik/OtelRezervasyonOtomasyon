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
    public partial class frmUyeKayit : MaterialForm
    {
        UyeBLL _uyeBLL;
        Uye _uye;
        public frmUyeKayit()
        {
            InitializeComponent();

            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);

            _uyeBLL = new UyeBLL();
        }

        private void frmUyeKayit_Load(object sender, EventArgs e)
        {
            string[] mailCesitleri = { "hotmail.com", "gmail.com", "yandex.com" };
            cmbEmail.DataSource = mailCesitleri;
        }

        private void btnUyeOl_Click(object sender, EventArgs e)
        {
            _uye = new Uye();
            try
            {
                if (!string.IsNullOrEmpty(txtEmail.Text))
                {
                    _uye.Email = txtEmail.Text + "@" + cmbEmail.SelectedItem;
                    _uye.Sifre = txtSifre.Text;
                    _uyeBLL.Add(_uye);
                    MessageBox.Show("Artık Giriş Yapabilirsiniz");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Email Alanı Boş Geçilemez");
                }
               
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

        }
    }
}
