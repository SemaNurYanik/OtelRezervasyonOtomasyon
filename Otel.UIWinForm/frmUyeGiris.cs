using MaterialSkin;
using MaterialSkin.Controls;
using Otel.BLL;
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
    public partial class frmUyeGiris : MaterialForm
    {
        UyeBLL _uyeBLL;
        public frmUyeGiris()
        {
            InitializeComponent();


            MaterialSkinManager skinManager = MaterialSkinManager.Instance;
            skinManager.AddFormToManage(this);
            skinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            skinManager.ColorScheme = new ColorScheme(Primary.BlueGrey700, Primary.BlueGrey900, Primary.Blue500, Accent.Orange700, TextShade.WHITE);

            _uyeBLL = new UyeBLL();
        }

        private void materialRaisedButton1_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string sifre = txtSifre.Text;

            bool isLogin = _uyeBLL.UyeMi(email, sifre);
          
            if (isLogin)
            {
                this.Hide();
                frmRezervasyon frm = new frmRezervasyon(email,sifre);
                frm.Show();               
            }
            else
            {
                MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmUyeKayit frm = new frmUyeKayit();
            frm.ShowDialog();
        }
    }
}
