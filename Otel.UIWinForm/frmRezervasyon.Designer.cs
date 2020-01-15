namespace Otel.UIWinForm
{
    partial class frmRezervasyon
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
            this.components = new System.ComponentModel.Container();
            this.lvUyeRezervasyon = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.iptalEtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.materialLabel1 = new MaterialSkin.Controls.MaterialLabel();
            this.lblEmail = new MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new MaterialSkin.Controls.MaterialLabel();
            this.btnYeniRezervasyon = new MaterialSkin.Controls.MaterialRaisedButton();
            this.btnYonetici = new MaterialSkin.Controls.MaterialRaisedButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvUyeRezervasyon
            // 
            this.lvUyeRezervasyon.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvUyeRezervasyon.ContextMenuStrip = this.contextMenuStrip1;
            this.lvUyeRezervasyon.Font = new System.Drawing.Font("News Cycle", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lvUyeRezervasyon.FullRowSelect = true;
            this.lvUyeRezervasyon.GridLines = true;
            this.lvUyeRezervasyon.Location = new System.Drawing.Point(43, 259);
            this.lvUyeRezervasyon.Name = "lvUyeRezervasyon";
            this.lvUyeRezervasyon.Size = new System.Drawing.Size(1032, 329);
            this.lvUyeRezervasyon.TabIndex = 3;
            this.lvUyeRezervasyon.UseCompatibleStateImageBehavior = false;
            this.lvUyeRezervasyon.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rezervasyon No";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 130;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Giriş Tarihi";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 120;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Çıkış Tarihi";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Kişi Sayısı";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 90;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Oda Tipi";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Durum";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 190;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iptalEtToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(126, 28);
            // 
            // iptalEtToolStripMenuItem
            // 
            this.iptalEtToolStripMenuItem.Name = "iptalEtToolStripMenuItem";
            this.iptalEtToolStripMenuItem.Size = new System.Drawing.Size(125, 24);
            this.iptalEtToolStripMenuItem.Text = "İptal Et";
            this.iptalEtToolStripMenuItem.Click += new System.EventHandler(this.iptalEtToolStripMenuItem_Click);
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(45, 96);
            this.materialLabel1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(116, 24);
            this.materialLabel1.TabIndex = 0;
            this.materialLabel1.Text = "Hoşgeldiniz ";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Depth = 0;
            this.lblEmail.Font = new System.Drawing.Font("Roboto", 11F);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEmail.Location = new System.Drawing.Point(161, 96);
            this.lblEmail.MouseState = MaterialSkin.MouseState.HOVER;
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(0, 24);
            this.lblEmail.TabIndex = 1;
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(458, 203);
            this.materialLabel2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(199, 24);
            this.materialLabel2.TabIndex = 2;
            this.materialLabel2.Text = "REZERVASYONARINIZ";
            // 
            // btnYeniRezervasyon
            // 
            this.btnYeniRezervasyon.Depth = 0;
            this.btnYeniRezervasyon.Font = new System.Drawing.Font("Adobe Gothic Std B", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnYeniRezervasyon.Location = new System.Drawing.Point(875, 615);
            this.btnYeniRezervasyon.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYeniRezervasyon.Name = "btnYeniRezervasyon";
            this.btnYeniRezervasyon.Primary = true;
            this.btnYeniRezervasyon.Size = new System.Drawing.Size(200, 43);
            this.btnYeniRezervasyon.TabIndex = 4;
            this.btnYeniRezervasyon.Text = "Yeni Rezervasyon";
            this.btnYeniRezervasyon.UseVisualStyleBackColor = true;
            this.btnYeniRezervasyon.Click += new System.EventHandler(this.btnYeniRezervasyon_Click);
            // 
            // btnYonetici
            // 
            this.btnYonetici.Depth = 0;
            this.btnYonetici.Font = new System.Drawing.Font("Adobe Gothic Std B", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.btnYonetici.Location = new System.Drawing.Point(875, 98);
            this.btnYonetici.MouseState = MaterialSkin.MouseState.HOVER;
            this.btnYonetici.Name = "btnYonetici";
            this.btnYonetici.Primary = true;
            this.btnYonetici.Size = new System.Drawing.Size(200, 43);
            this.btnYonetici.TabIndex = 5;
            this.btnYonetici.Text = "Yönetici Paneli";
            this.btnYonetici.UseVisualStyleBackColor = true;
            this.btnYonetici.Visible = false;
            this.btnYonetici.Click += new System.EventHandler(this.btnYonetici_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkGray;
            this.label1.Location = new System.Drawing.Point(40, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 10);
            this.label1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Location = new System.Drawing.Point(697, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(378, 10);
            this.label2.TabIndex = 7;
            // 
            // frmRezervasyon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1135, 694);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnYonetici);
            this.Controls.Add(this.btnYeniRezervasyon);
            this.Controls.Add(this.lvUyeRezervasyon);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.materialLabel1);
            this.Name = "frmRezervasyon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anasayfa";
            this.Load += new System.EventHandler(this.frmRezervasyon_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialLabel materialLabel1;
        private MaterialSkin.Controls.MaterialLabel lblEmail;
        private MaterialSkin.Controls.MaterialLabel materialLabel2;
        private MaterialSkin.Controls.MaterialRaisedButton btnYeniRezervasyon;
        private MaterialSkin.Controls.MaterialRaisedButton btnYonetici;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lvUyeRezervasyon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem iptalEtToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}