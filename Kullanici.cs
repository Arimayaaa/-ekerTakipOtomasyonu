using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ŞEKERTAKİPOTOMASYONU
{
    public partial class Kullanici : Form
    {
        public Kullanici()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Kullanici_Load(object sender, EventArgs e)
        {
            KullaniciListele();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            // 1️⃣ Tüm alanların doldurulup doldurulmadığını kontrol et
            if (string.IsNullOrWhiteSpace(txtBoxAd.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKullaniciAd.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKullaniciSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            string querykullaniciAd = $@"SELECT COUNT(*) FROM Kullanicilar WHERE KullaniciAd = '{txtBoxKullaniciAd.Text.Trim()}'";

            DataTable dtKontrol = veritabaniBag.SorguCalistir(querykullaniciAd);

            if (dtKontrol != null && dtKontrol.Rows.Count > 0)
            {
                int mevcut = Convert.ToInt32(dtKontrol.Rows[0][0]);

                if (mevcut > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
           
                string tarihStr = DateTime.Now.ToString("yyyy-MM-dd");

                // 3️⃣ Ekleme işlemi (tarih ile birlikte)
                string query = $@"INSERT INTO Kullanicilar (Ad, Soyad, kullaniciAd, kullaniciSifre, GuncellemeTarihi) 
                     VALUES ('{txtBoxAd.Text.Trim()}', '{txtBoxSoyad.Text.Trim()}', '{txtBoxKullaniciAd.Text.Trim()}', '{txtBoxKullaniciSifre.Text.Trim()}', '{tarihStr}')";

                veritabaniBag.SorguCalistir(query);


                MessageBox.Show("Kullanıcı başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // 4️⃣ DataGridView’i yenile
                KullaniciListele();
                temizle();
            
           

        }


        public void temizle()
        {

            // 5️⃣ TextBox’ları temizle
            txtBoxAd.Clear();
            txtBoxSoyad.Clear();
            txtBoxKullaniciAd.Clear();
            txtBoxKullaniciSifre.Clear();
        }


        private void KullaniciListele()
        {
            try
            {
                string query = "SELECT id as ID, Ad, Soyad, kullaniciAd as [Kullanıcı Ad], KullaniciSifre as Şifre FROM Kullanicilar";
                DataTable dt = veritabaniBag.SorguCalistir(query);
                if (dt != null)
                {
                    KullanicilarGrid.DataSource = dt;
                    KullanicilarGrid.Columns["ID"].Visible = false;
                    // Şifre kolonunu **** ile göster
                    KullanicilarGrid.CellFormatting += (s, e) =>
                    {
                        if (KullanicilarGrid.Columns[e.ColumnIndex].Name == "Şifre" && e.Value != null)
                        {
                            e.Value = new string('*', 15);
                            e.FormattingApplied = true;
                        }
                    };
                }
                else
                {
                    MessageBox.Show("Veri çekilemedi.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        private void KullanicilarGrid_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (KullanicilarGrid.CurrentRow != null)
            {
                txtBoxKullaniciAd.Text = KullanicilarGrid.CurrentRow.Cells["Kullanıcı Ad"].Value?.ToString().Trim();
                txtBoxKullaniciSifre.Text = KullanicilarGrid.CurrentRow.Cells["Şifre"].Value?.ToString().Trim();
                txtBoxAd.Text = KullanicilarGrid.CurrentRow.Cells["Ad"].Value?.ToString().Trim();
                txtBoxSoyad.Text = KullanicilarGrid.CurrentRow.Cells["Soyad"].Value?.ToString().Trim();
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1️⃣ DataGridView'de seçili satır var mı kontrol et
            if (KullanicilarGrid.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string kullaniciAd= KullanicilarGrid.CurrentRow.Cells["ad"].Value.ToString().Trim() ?? "Belirsiz";

           

            // 2️⃣ Seçili kullanıcının ID'sini al
            int kullaniciId;
            if (!int.TryParse(KullanicilarGrid.CurrentRow.Cells["id"].Value.ToString(), out kullaniciId))
            {
                MessageBox.Show("Geçerli bir kullanıcı ID'si alınamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3️⃣ Silme onayı
            DialogResult onay = MessageBox.Show("Seçili kullanıcıyı silmek istediğinize emin misiniz?",
                                                "Silme Onayı",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (onay != DialogResult.Yes)
                return;
           
          
            string query = $@"DELETE FROM Kullanicilar WHERE id = {kullaniciId}";
            //string query = "DELETE FROM Kullanicilar WHERE id = " + kullaniciId;
            veritabaniBag.SorguCalistir(query);
            MessageBox.Show("Kullanıcı Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KullaniciListele();

        }
        private void btnCiftciIslemleri_Click(object sender, EventArgs e)
        {
            Form2 ciftciForm = new Form2();
            ciftciForm.Show(); // veya ShowDialog() ile modal açabilirsiniz
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1️⃣ Zorunlu alan kontrolü
            if (string.IsNullOrWhiteSpace(txtBoxAd.Text) ||
                string.IsNullOrWhiteSpace(txtBoxSoyad.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKullaniciAd.Text) ||
                string.IsNullOrWhiteSpace(txtBoxKullaniciSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Güncellenecek kullanıcı seçili mi kontrol et
            if (KullanicilarGrid.CurrentRow == null)
            {
                MessageBox.Show("Güncellemek için bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ Seçili kullanıcının ID'sini al
            int kullaniciId;
            if (!int.TryParse(KullanicilarGrid.CurrentRow.Cells["id"].Value.ToString(), out kullaniciId))
            {
                MessageBox.Show("Geçerli bir kullanıcı ID'si alınamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

          

            // 5️⃣ Güncelleme sorgusu ve parametrelerin hazırlanması
            string tarihStr = DateTime.Now.ToString("yyyy-MM-dd");

            string queryGuncelle = $@"
                    UPDATE Kullanicilar 
                    SET Ad = '{txtBoxAd.Text.Trim()}', 
                        Soyad = '{txtBoxSoyad.Text.Trim()}', 
                        kullaniciAd = '{txtBoxKullaniciAd.Text.Trim()}', 
                        kullaniciSifre = '{txtBoxKullaniciSifre.Text.Trim()}', 
                        GuncellemeTarihi = '{tarihStr}'
                    WHERE id = {kullaniciId}";

            // 6️⃣ Sorguyu çalıştır ve sonucu kontrol et            
            int sonuc = veritabaniBag.SorguCalistirNonQuery(queryGuncelle);

            if (sonuc > 0)
            {
                MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KullaniciListele();
                temizle();
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
    }

