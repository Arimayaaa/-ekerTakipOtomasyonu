using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ŞEKERTAKİPOTOMASYONU
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Form açılırken bağlantı test edilsin (zorunlu değil)
            // veritabaniBag.TestConnection();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAd = txtKullaniciAd.Text.Trim();
            string kullaniciSifre = txtkullaniciSifre.Text.Trim();

            if (string.IsNullOrEmpty(kullaniciAd) || string.IsNullOrEmpty(kullaniciSifre))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifrenizi giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kullanıcıyı doğrula
            bool dogruMu = veritabaniBag.KullaniciGirisi(kullaniciAd, kullaniciSifre);

            if (dogruMu)
            {
                MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Yeni formu aç
                AnaSayfa anaForm = new AnaSayfa();
                anaForm.Show();
                this.Hide(); // Giriş formunu gizle
            }
            else
            {
                MessageBox.Show("Giriş bilgilerinizi kontrol ediniz.", "Hatalı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
