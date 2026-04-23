namespace ŞEKERTAKİPOTOMASYONU
{
    partial class Kullanici
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kullanici));
            this.lblKullaniciAd = new System.Windows.Forms.Label();
            this.lblKullaniciSifre = new System.Windows.Forms.Label();
            this.txtBoxKullaniciSifre = new System.Windows.Forms.TextBox();
            this.txtBoxKullaniciAd = new System.Windows.Forms.TextBox();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnGuncelle = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBoxAd = new System.Windows.Forms.RichTextBox();
            this.txtBoxSoyad = new System.Windows.Forms.TextBox();
            this.lblSoyad = new System.Windows.Forms.Label();
            this.lblAd = new System.Windows.Forms.Label();
            this.KullanicilarGrid = new System.Windows.Forms.DataGridView();
            this.btnTemizle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KullanicilarGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblKullaniciAd
            // 
            this.lblKullaniciAd.AutoSize = true;
            this.lblKullaniciAd.BackColor = System.Drawing.Color.Transparent;
            this.lblKullaniciAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciAd.ForeColor = System.Drawing.SystemColors.Control;
            this.lblKullaniciAd.Location = new System.Drawing.Point(30, 139);
            this.lblKullaniciAd.Name = "lblKullaniciAd";
            this.lblKullaniciAd.Size = new System.Drawing.Size(115, 20);
            this.lblKullaniciAd.TabIndex = 0;
            this.lblKullaniciAd.Text = "Kullanıcı Ad:";
            this.lblKullaniciAd.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblKullaniciSifre
            // 
            this.lblKullaniciSifre.AutoSize = true;
            this.lblKullaniciSifre.BackColor = System.Drawing.Color.Transparent;
            this.lblKullaniciSifre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblKullaniciSifre.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblKullaniciSifre.Location = new System.Drawing.Point(5, 171);
            this.lblKullaniciSifre.Name = "lblKullaniciSifre";
            this.lblKullaniciSifre.Size = new System.Drawing.Size(139, 20);
            this.lblKullaniciSifre.TabIndex = 1;
            this.lblKullaniciSifre.Text = "Kullanıcı Şiffre:";
            // 
            // txtBoxKullaniciSifre
            // 
            this.txtBoxKullaniciSifre.Location = new System.Drawing.Point(162, 171);
            this.txtBoxKullaniciSifre.Name = "txtBoxKullaniciSifre";
            this.txtBoxKullaniciSifre.PasswordChar = '*';
            this.txtBoxKullaniciSifre.Size = new System.Drawing.Size(158, 22);
            this.txtBoxKullaniciSifre.TabIndex = 2;
            // 
            // txtBoxKullaniciAd
            // 
            this.txtBoxKullaniciAd.Location = new System.Drawing.Point(164, 139);
            this.txtBoxKullaniciAd.Name = "txtBoxKullaniciAd";
            this.txtBoxKullaniciAd.Size = new System.Drawing.Size(156, 22);
            this.txtBoxKullaniciAd.TabIndex = 3;
            // 
            // btnEkle
            // 
            this.btnEkle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEkle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnEkle.Location = new System.Drawing.Point(9, 220);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(92, 44);
            this.btnEkle.TabIndex = 4;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.UseVisualStyleBackColor = false;
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnSil
            // 
            this.btnSil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSil.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSil.Location = new System.Drawing.Point(9, 284);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(92, 44);
            this.btnSil.TabIndex = 5;
            this.btnSil.Text = "Sil";
            this.btnSil.UseVisualStyleBackColor = false;
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnGuncelle
            // 
            this.btnGuncelle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuncelle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGuncelle.Location = new System.Drawing.Point(231, 220);
            this.btnGuncelle.Name = "btnGuncelle";
            this.btnGuncelle.Size = new System.Drawing.Size(89, 44);
            this.btnGuncelle.TabIndex = 6;
            this.btnGuncelle.Text = "Güncelle";
            this.btnGuncelle.UseVisualStyleBackColor = false;
            this.btnGuncelle.Click += new System.EventHandler(this.btnGuncelle_Click);
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "indir (4).jpeg");
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btnTemizle);
            this.groupBox1.Controls.Add(this.txtBoxAd);
            this.groupBox1.Controls.Add(this.txtBoxSoyad);
            this.groupBox1.Controls.Add(this.lblSoyad);
            this.groupBox1.Controls.Add(this.lblAd);
            this.groupBox1.Controls.Add(this.btnGuncelle);
            this.groupBox1.Controls.Add(this.lblKullaniciSifre);
            this.groupBox1.Controls.Add(this.txtBoxKullaniciSifre);
            this.groupBox1.Controls.Add(this.lblKullaniciAd);
            this.groupBox1.Controls.Add(this.txtBoxKullaniciAd);
            this.groupBox1.Controls.Add(this.btnEkle);
            this.groupBox1.Controls.Add(this.btnSil);
            this.groupBox1.Location = new System.Drawing.Point(12, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(359, 362);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Kullanıcı";
            // 
            // txtBoxAd
            // 
            this.txtBoxAd.Location = new System.Drawing.Point(164, 70);
            this.txtBoxAd.Name = "txtBoxAd";
            this.txtBoxAd.Size = new System.Drawing.Size(156, 27);
            this.txtBoxAd.TabIndex = 10;
            this.txtBoxAd.Text = "";
            // 
            // txtBoxSoyad
            // 
            this.txtBoxSoyad.Location = new System.Drawing.Point(164, 103);
            this.txtBoxSoyad.Name = "txtBoxSoyad";
            this.txtBoxSoyad.Size = new System.Drawing.Size(156, 22);
            this.txtBoxSoyad.TabIndex = 9;
            // 
            // lblSoyad
            // 
            this.lblSoyad.AutoSize = true;
            this.lblSoyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblSoyad.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblSoyad.Location = new System.Drawing.Point(79, 103);
            this.lblSoyad.Name = "lblSoyad";
            this.lblSoyad.Size = new System.Drawing.Size(66, 20);
            this.lblSoyad.TabIndex = 8;
            this.lblSoyad.Text = "Soyad:";
            // 
            // lblAd
            // 
            this.lblAd.AutoSize = true;
            this.lblAd.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAd.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblAd.Location = new System.Drawing.Point(107, 70);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(37, 20);
            this.lblAd.TabIndex = 7;
            this.lblAd.Text = "Ad:";
            // 
            // KullanicilarGrid
            // 
            this.KullanicilarGrid.BackgroundColor = System.Drawing.Color.Linen;
            this.KullanicilarGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.KullanicilarGrid.Location = new System.Drawing.Point(397, 15);
            this.KullanicilarGrid.Name = "KullanicilarGrid";
            this.KullanicilarGrid.RowHeadersWidth = 51;
            this.KullanicilarGrid.RowTemplate.Height = 24;
            this.KullanicilarGrid.Size = new System.Drawing.Size(747, 362);
            this.KullanicilarGrid.TabIndex = 8;
            this.KullanicilarGrid.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.KullanicilarGrid_MouseDoubleClick);
            // 
            // btnTemizle
            // 
            this.btnTemizle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnTemizle.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnTemizle.Location = new System.Drawing.Point(231, 284);
            this.btnTemizle.Name = "btnTemizle";
            this.btnTemizle.Size = new System.Drawing.Size(89, 44);
            this.btnTemizle.TabIndex = 11;
            this.btnTemizle.Text = "Temizle";
            this.btnTemizle.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTemizle.UseVisualStyleBackColor = false;
            this.btnTemizle.Click += new System.EventHandler(this.btnTemizle_Click);
            // 
            // Kullanici
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1170, 653);
            this.Controls.Add(this.KullanicilarGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "Kullanici";
            this.Text = "Kullanici";
            this.Load += new System.EventHandler(this.Kullanici_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.KullanicilarGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblKullaniciAd;
        private System.Windows.Forms.Label lblKullaniciSifre;
        private System.Windows.Forms.TextBox txtBoxKullaniciSifre;
        private System.Windows.Forms.TextBox txtBoxKullaniciAd;
        private System.Windows.Forms.Button btnEkle;
        private System.Windows.Forms.Button btnSil;
        private System.Windows.Forms.Button btnGuncelle;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView KullanicilarGrid;
        private System.Windows.Forms.Label lblAd;
        private System.Windows.Forms.RichTextBox txtBoxAd;
        private System.Windows.Forms.TextBox txtBoxSoyad;
        private System.Windows.Forms.Label lblSoyad;
        private System.Windows.Forms.Button btnTemizle;
    }
}