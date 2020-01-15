namespace Otel.UIWinForm
{
    partial class frmYeniRezervasyon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnMusteriIptal = new MaterialSkin.Controls.MaterialRaisedButton();
            this.cmbRezervasyonTip = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.nudKisiSayisi = new System.Windows.Forms.NumericUpDown();
            this.dtBitis = new System.Windows.Forms.DateTimePicker();
            this.dtGiris = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.materialRaisedButton1 = new MaterialSkin.Controls.MaterialRaisedButton();
            this.flpMusteri = new System.Windows.Forms.FlowLayoutPanel();
            this.gbMusteri = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnMusteriSil = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnMusteriEkle = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label11 = new System.Windows.Forms.Label();
            this.txtMusteriTel = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtMusteriTc = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMusteriEmail = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMusteriAd = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.txtMusteriSoyad = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.materialSingleLineTextField1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.materialSingleLineTextField2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.btnOnay = new MaterialSkin.Controls.MaterialRaisedButton();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKisiSayisi)).BeginInit();
            this.flpMusteri.SuspendLayout();
            this.gbMusteri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.btnMusteriIptal);
            this.groupBox2.Controls.Add(this.cmbRezervasyonTip);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.nudKisiSayisi);
            this.groupBox2.Controls.Add(this.dtBitis);
            this.groupBox2.Controls.Add(this.dtGiris);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.materialRaisedButton1);
            this.groupBox2.Location = new System.Drawing.Point(12, 85);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(1155, 218);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Yeni Rezervasyon";
            // 
            // btnMusteriIptal
            // 
            this.btnMusteriIptal.Depth = 0;
            this.btnMusteriIptal.Location = new System.Drawing.Point(929, 167);
            this.btnMusteriIptal.Margin = new System.Windows.Forms.Padding(4);
            this.btnMusteriIptal.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMusteriIptal.Name = "btnMusteriIptal";
            this.btnMusteriIptal.Primary = true;
            this.btnMusteriIptal.Size = new System.Drawing.Size(105, 34);
            this.btnMusteriIptal.TabIndex = 12;
            this.btnMusteriIptal.Text = "Iptal";
            this.btnMusteriIptal.UseVisualStyleBackColor = true;
            this.btnMusteriIptal.Visible = false;
            this.btnMusteriIptal.Click += new System.EventHandler(this.BtnMusteriIptal_Click);
            // 
            // cmbRezervasyonTip
            // 
            this.cmbRezervasyonTip.FormattingEnabled = true;
            this.cmbRezervasyonTip.Location = new System.Drawing.Point(739, 107);
            this.cmbRezervasyonTip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbRezervasyonTip.Name = "cmbRezervasyonTip";
            this.cmbRezervasyonTip.Size = new System.Drawing.Size(204, 24);
            this.cmbRezervasyonTip.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(563, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(148, 18);
            this.label9.TabIndex = 10;
            this.label9.Text = "Rezervasyon Tipi :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(184, 107);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 18);
            this.label8.TabIndex = 9;
            this.label8.Text = "Kişi Sayısı :";
            // 
            // nudKisiSayisi
            // 
            this.nudKisiSayisi.Location = new System.Drawing.Point(297, 107);
            this.nudKisiSayisi.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.nudKisiSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudKisiSayisi.Name = "nudKisiSayisi";
            this.nudKisiSayisi.Size = new System.Drawing.Size(73, 22);
            this.nudKisiSayisi.TabIndex = 8;
            this.nudKisiSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // dtBitis
            // 
            this.dtBitis.Location = new System.Drawing.Point(739, 38);
            this.dtBitis.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtBitis.Name = "dtBitis";
            this.dtBitis.Size = new System.Drawing.Size(204, 22);
            this.dtBitis.TabIndex = 7;
            // 
            // dtGiris
            // 
            this.dtGiris.Location = new System.Drawing.Point(297, 42);
            this.dtGiris.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dtGiris.Name = "dtGiris";
            this.dtGiris.Size = new System.Drawing.Size(200, 22);
            this.dtGiris.TabIndex = 6;
            this.dtGiris.ValueChanged += new System.EventHandler(this.dtGiris_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(607, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 18);
            this.label7.TabIndex = 5;
            this.label7.Text = "Çıkış Tarihi :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(179, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 18);
            this.label6.TabIndex = 4;
            this.label6.Text = "Giriş Tarihi :";
            // 
            // materialRaisedButton1
            // 
            this.materialRaisedButton1.Depth = 0;
            this.materialRaisedButton1.Location = new System.Drawing.Point(820, 167);
            this.materialRaisedButton1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.materialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialRaisedButton1.Name = "materialRaisedButton1";
            this.materialRaisedButton1.Primary = true;
            this.materialRaisedButton1.Size = new System.Drawing.Size(103, 34);
            this.materialRaisedButton1.TabIndex = 3;
            this.materialRaisedButton1.Text = "Ekle";
            this.materialRaisedButton1.UseVisualStyleBackColor = true;
            this.materialRaisedButton1.Click += new System.EventHandler(this.materialRaisedButton1_Click);
            // 
            // flpMusteri
            // 
            this.flpMusteri.AutoScroll = true;
            this.flpMusteri.Controls.Add(this.gbMusteri);
            this.flpMusteri.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpMusteri.Location = new System.Drawing.Point(12, 309);
            this.flpMusteri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flpMusteri.Name = "flpMusteri";
            this.flpMusteri.Size = new System.Drawing.Size(1155, 438);
            this.flpMusteri.TabIndex = 3;
            this.flpMusteri.WrapContents = false;
            // 
            // gbMusteri
            // 
            this.gbMusteri.BackColor = System.Drawing.Color.White;
            this.gbMusteri.Controls.Add(this.pictureBox1);
            this.gbMusteri.Controls.Add(this.btnMusteriSil);
            this.gbMusteri.Controls.Add(this.btnMusteriEkle);
            this.gbMusteri.Controls.Add(this.label11);
            this.gbMusteri.Controls.Add(this.txtMusteriTel);
            this.gbMusteri.Controls.Add(this.label5);
            this.gbMusteri.Controls.Add(this.label10);
            this.gbMusteri.Controls.Add(this.txtMusteriTc);
            this.gbMusteri.Controls.Add(this.txtMusteriEmail);
            this.gbMusteri.Controls.Add(this.label1);
            this.gbMusteri.Controls.Add(this.label2);
            this.gbMusteri.Controls.Add(this.txtMusteriAd);
            this.gbMusteri.Controls.Add(this.txtMusteriSoyad);
            this.gbMusteri.Location = new System.Drawing.Point(3, 2);
            this.gbMusteri.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMusteri.Name = "gbMusteri";
            this.gbMusteri.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbMusteri.Size = new System.Drawing.Size(1148, 139);
            this.gbMusteri.TabIndex = 4;
            this.gbMusteri.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.pictureBox1.Image = global::Otel.UIWinForm.Properties.Resources.btnEdit1;
            this.pictureBox1.Location = new System.Drawing.Point(995, 95);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnMusteriSil
            // 
            this.btnMusteriSil.Depth = 0;
            this.btnMusteriSil.Location = new System.Drawing.Point(1069, 95);
            this.btnMusteriSil.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMusteriSil.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMusteriSil.Name = "btnMusteriSil";
            this.btnMusteriSil.Primary = true;
            this.btnMusteriSil.Size = new System.Drawing.Size(29, 26);
            this.btnMusteriSil.TabIndex = 12;
            this.btnMusteriSil.Text = "-";
            this.btnMusteriSil.UseVisualStyleBackColor = true;
            this.btnMusteriSil.Visible = false;
            // 
            // btnMusteriEkle
            // 
            this.btnMusteriEkle.Depth = 0;
            this.btnMusteriEkle.Location = new System.Drawing.Point(1032, 95);
            this.btnMusteriEkle.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnMusteriEkle.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnMusteriEkle.Name = "btnMusteriEkle";
            this.btnMusteriEkle.Primary = true;
            this.btnMusteriEkle.Size = new System.Drawing.Size(29, 26);
            this.btnMusteriEkle.TabIndex = 11;
            this.btnMusteriEkle.Text = "+";
            this.btnMusteriEkle.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(904, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 17);
            this.label11.TabIndex = 9;
            this.label11.Text = "Tel :";
            // 
            // txtMusteriTel
            // 
            this.txtMusteriTel.Depth = 0;
            this.txtMusteriTel.Hint = "";
            this.txtMusteriTel.Location = new System.Drawing.Point(955, 38);
            this.txtMusteriTel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriTel.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMusteriTel.Name = "txtMusteriTel";
            this.txtMusteriTel.PasswordChar = '\0';
            this.txtMusteriTel.SelectedText = "";
            this.txtMusteriTel.SelectionLength = 0;
            this.txtMusteriTel.SelectionStart = 0;
            this.txtMusteriTel.Size = new System.Drawing.Size(147, 28);
            this.txtMusteriTel.TabIndex = 10;
            this.txtMusteriTel.UseSystemPasswordChar = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(401, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "TCNo:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(621, 49);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 17);
            this.label10.TabIndex = 6;
            this.label10.Text = "Email :";
            // 
            // txtMusteriTc
            // 
            this.txtMusteriTc.Depth = 0;
            this.txtMusteriTc.Hint = "";
            this.txtMusteriTc.Location = new System.Drawing.Point(456, 38);
            this.txtMusteriTc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriTc.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMusteriTc.Name = "txtMusteriTc";
            this.txtMusteriTc.PasswordChar = '\0';
            this.txtMusteriTc.SelectedText = "";
            this.txtMusteriTc.SelectionLength = 0;
            this.txtMusteriTc.SelectionStart = 0;
            this.txtMusteriTc.Size = new System.Drawing.Size(147, 28);
            this.txtMusteriTc.TabIndex = 7;
            this.txtMusteriTc.UseSystemPasswordChar = false;
            // 
            // txtMusteriEmail
            // 
            this.txtMusteriEmail.Depth = 0;
            this.txtMusteriEmail.Hint = "";
            this.txtMusteriEmail.Location = new System.Drawing.Point(684, 38);
            this.txtMusteriEmail.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMusteriEmail.Name = "txtMusteriEmail";
            this.txtMusteriEmail.PasswordChar = '\0';
            this.txtMusteriEmail.SelectedText = "";
            this.txtMusteriEmail.SelectionLength = 0;
            this.txtMusteriEmail.SelectionStart = 0;
            this.txtMusteriEmail.Size = new System.Drawing.Size(213, 28);
            this.txtMusteriEmail.TabIndex = 8;
            this.txtMusteriEmail.UseSystemPasswordChar = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ad :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(204, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Soyad :";
            // 
            // txtMusteriAd
            // 
            this.txtMusteriAd.Depth = 0;
            this.txtMusteriAd.Hint = "";
            this.txtMusteriAd.Location = new System.Drawing.Point(67, 38);
            this.txtMusteriAd.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriAd.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMusteriAd.Name = "txtMusteriAd";
            this.txtMusteriAd.PasswordChar = '\0';
            this.txtMusteriAd.SelectedText = "";
            this.txtMusteriAd.SelectionLength = 0;
            this.txtMusteriAd.SelectionStart = 0;
            this.txtMusteriAd.Size = new System.Drawing.Size(131, 28);
            this.txtMusteriAd.TabIndex = 3;
            this.txtMusteriAd.UseSystemPasswordChar = false;
            // 
            // txtMusteriSoyad
            // 
            this.txtMusteriSoyad.Depth = 0;
            this.txtMusteriSoyad.Hint = "";
            this.txtMusteriSoyad.Location = new System.Drawing.Point(269, 38);
            this.txtMusteriSoyad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtMusteriSoyad.MouseState = MaterialSkin.MouseState.HOVER;
            this.txtMusteriSoyad.Name = "txtMusteriSoyad";
            this.txtMusteriSoyad.PasswordChar = '\0';
            this.txtMusteriSoyad.SelectedText = "";
            this.txtMusteriSoyad.SelectionLength = 0;
            this.txtMusteriSoyad.SelectionStart = 0;
            this.txtMusteriSoyad.Size = new System.Drawing.Size(116, 28);
            this.txtMusteriSoyad.TabIndex = 4;
            this.txtMusteriSoyad.UseSystemPasswordChar = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Ad :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(244, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Soyad :";
            // 
            // materialSingleLineTextField1
            // 
            this.materialSingleLineTextField1.Depth = 0;
            this.materialSingleLineTextField1.Hint = "";
            this.materialSingleLineTextField1.Location = new System.Drawing.Point(76, 38);
            this.materialSingleLineTextField1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField1.Name = "materialSingleLineTextField1";
            this.materialSingleLineTextField1.PasswordChar = '\0';
            this.materialSingleLineTextField1.SelectedText = "";
            this.materialSingleLineTextField1.SelectionLength = 0;
            this.materialSingleLineTextField1.SelectionStart = 0;
            this.materialSingleLineTextField1.Size = new System.Drawing.Size(146, 28);
            this.materialSingleLineTextField1.TabIndex = 3;
            this.materialSingleLineTextField1.UseSystemPasswordChar = false;
            // 
            // materialSingleLineTextField2
            // 
            this.materialSingleLineTextField2.Depth = 0;
            this.materialSingleLineTextField2.Hint = "";
            this.materialSingleLineTextField2.Location = new System.Drawing.Point(310, 38);
            this.materialSingleLineTextField2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialSingleLineTextField2.Name = "materialSingleLineTextField2";
            this.materialSingleLineTextField2.PasswordChar = '\0';
            this.materialSingleLineTextField2.SelectedText = "";
            this.materialSingleLineTextField2.SelectionLength = 0;
            this.materialSingleLineTextField2.SelectionStart = 0;
            this.materialSingleLineTextField2.Size = new System.Drawing.Size(146, 28);
            this.materialSingleLineTextField2.TabIndex = 4;
            this.materialSingleLineTextField2.UseSystemPasswordChar = false;
            // 
            // btnOnay
            // 
            this.btnOnay.Depth = 0;
            this.btnOnay.Location = new System.Drawing.Point(545, 772);
            this.btnOnay.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOnay.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnOnay.Name = "btnOnay";
            this.btnOnay.Primary = true;
            this.btnOnay.Size = new System.Drawing.Size(103, 34);
            this.btnOnay.TabIndex = 12;
            this.btnOnay.Text = "Onayla";
            this.btnOnay.UseVisualStyleBackColor = true;
            this.btnOnay.Click += new System.EventHandler(this.btnOnay_Click);
            // 
            // frmYeniRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 818);
            this.Controls.Add(this.btnOnay);
            this.Controls.Add(this.flpMusteri);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmYeniRezervasyon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Rezervasyon";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmYeniRezervasyon_FormClosed);
            this.Load += new System.EventHandler(this.frmYeniRezervasyon_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudKisiSayisi)).EndInit();
            this.flpMusteri.ResumeLayout(false);
            this.gbMusteri.ResumeLayout(false);
            this.gbMusteri.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbRezervasyonTip;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudKisiSayisi;
        private System.Windows.Forms.DateTimePicker dtBitis;
        private System.Windows.Forms.DateTimePicker dtGiris;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialRaisedButton materialRaisedButton1;
        private System.Windows.Forms.FlowLayoutPanel flpMusteri;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField1;
        private MaterialSkin.Controls.MaterialSingleLineTextField materialSingleLineTextField2;
        private MaterialSkin.Controls.MaterialRaisedButton btnOnay;
        private System.Windows.Forms.GroupBox gbMusteri;
        private MaterialSkin.Controls.MaterialRaisedButton btnMusteriEkle;
        private System.Windows.Forms.Label label11;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMusteriTel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMusteriTc;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMusteriEmail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMusteriAd;
        private MaterialSkin.Controls.MaterialSingleLineTextField txtMusteriSoyad;
        private MaterialSkin.Controls.MaterialRaisedButton btnMusteriSil;
        private System.Windows.Forms.PictureBox pictureBox1;
        private MaterialSkin.Controls.MaterialRaisedButton btnMusteriIptal;
    }
}