using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ŞEKERTAKİPOTOMASYONU
{
    public partial class Form2 : Form
    {
        

        public Form2()
        {
            InitializeComponent();

            
        }
        public int fabrikaId, bolgeId;
        // Form yüklendiğinde çalışacak (Designer'da bağlı)
        private void Form2_Load_1(object sender, EventArgs e)
        {
            // İstersen buraya form açılışında yapılacak işlemleri ekle
        }

        // Form tıklandığında çalışacak (Designer'da bağlı, boş bırakabilirsin)
        private void btnCiftciIslemleri_Click(object sender, EventArgs e)
        {
            // İstersen buraya tıklama işlemi ekle
        }

        // Fabrikalar combobox açılınca fabrikaları veritabanından çekip listele
        private void cmbFabrikalarDoldur()
        {
            try
            {
                cmbFabrikalar.Items.Clear();

                string query = "SELECT FabrikaID, FabrikaAdi FROM Fabrikalar ORDER BY FabrikaAdi";

                DataTable dt = veritabaniBag.SorguCalistir(query);  // DataTable döndürüyor

                if (dt != null)
                {
                    cmbFabrikalar.DataSource = dt;
                    cmbFabrikalar.DisplayMember = "FabrikaAdi";   // ComboBox'ta gözükecek alan
                    cmbFabrikalar.ValueMember = "FabrikaID";      // Seçildiğinde değeri alacağımız alan
                }
                cmbFabrikalar.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Fabrikalar getirilirken hata: " + ex.Message);
            }
        }


        private void cmbBolgeDoldur()
        {
            if (cmbFabrikalar.SelectedValue == null) return;

            int fabrikaID = Convert.ToInt32(cmbFabrikalar.SelectedValue);

            try
            {
                string query = $"SELECT BolgeID, BolgeAdi FROM Bolgeler WHERE FabrikaID = {fabrikaID} ORDER BY BolgeAdi";

                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null)
                {
                    cmbBolgeAdi.DataSource = dt;
                    cmbBolgeAdi.DisplayMember = "BolgeAdi"; // ComboBox'ta görünecek alan
                    cmbBolgeAdi.ValueMember = "BolgeID";    // Seçildiğinde değeri alacağımız alan
                }

                if (cmbBolgeAdi.Items.Count > 0)
                    cmbBolgeAdi.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölgeler getirilirken hata: " + ex.Message);
            }
        }

        // Fabrika seçildiğinde bölgeleri çekip alt comboboxa doldur
        private void comboBoxFabrika_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFabrikalar.SelectedValue == null) return;

            int fabrikaID = Convert.ToInt32(cmbFabrikalar.SelectedValue);

            try
            {
                string query = $"SELECT BolgeID, BolgeAdi FROM Bolgeler WHERE FabrikaID = {fabrikaID} ORDER BY BolgeAdi";
                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null)
                {
                    cmbBolgeAdi.DataSource = dt;
                    cmbBolgeAdi.DisplayMember = "BolgeAdi";
                    cmbBolgeAdi.ValueMember = "BolgeID";

                    if (cmbBolgeAdi.Items.Count > 0)
                        cmbBolgeAdi.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölgeler getirilirken hata: " + ex.Message);
            }
        }


        // ComboBox içinde hem gösterilen metin hem de değer tutan sınıf
        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(textBox6.Text) || string.IsNullOrWhiteSpace(textBox5.Text))
            {
                MessageBox.Show("Lütfen tüm bilgileri doldurun.");
                return;
            }

            if (cmbFabrikalar.SelectedItem == null || cmbBolgeAdi.SelectedItem == null)
            {
                MessageBox.Show("Lütfen fabrika ve bölge seçin.");
                return;
            }

            string ureticiAdi = textBox2.Text.Trim();
            string ureticiTel = textBox6.Text.Trim();
            string ureticiTC = textBox5.Text.Trim();

            int fabrikaDeger = Convert.ToInt32(cmbFabrikalar.SelectedValue?.ToString().Trim());
            int bolgeDeger = Convert.ToInt32(cmbBolgeAdi.SelectedValue?.ToString().Trim());

          

            string query = $@"INSERT INTO Ureticiler (UreticiAdi, UreticiTel, UreticiTC, FabrikaID, BolgeID) 
                           VALUES ('{ureticiAdi}', '{ureticiTel}', '{ureticiTC}', {fabrikaDeger}, {bolgeDeger})";

            veritabaniBag.SorguCalistir(query);
            MessageBox.Show("Üretici başarıyla eklendi.");
            ureticiListele();
            temizle();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Fabrikalar combobox açılırken fabrikaları doldurmak için event bağlama
            cmbFabrikalarDoldur();
            cmbBolgeDoldur();
            cmbFabrikalar.SelectedIndexChanged += comboBoxFabrika_SelectedIndexChanged;

            ureticiListele();
        }
        private void ureticiListele()
        {
            try
            {
                string query = "SELECT u.UreticiID as ID, u.UreticiAdi as Ad, f.FabrikaAdi as [Fabrika Adı]," +
                    " u.FabrikaID, u.BolgeID, b.BolgeAdi as [Bölge Adı], u.UreticiTC as TC," +
                    " u.UreticiTel as Telefon FROM Ureticiler u " +
                    "inner join Fabrikalar f on u.FabrikaID = f.FabrikaID " +
                    "inner join Bolgeler b on u.BolgeId = b.BolgeID";
                DataTable dt = veritabaniBag.SorguCalistir(query);
                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["FabrikaID"].Visible = false;
                    dataGridView1.Columns["BolgeID"].Visible = false;
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
        
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
               
                // ID kolonları da DataGridView sorgusunda olmalı (görünmese bile)
                fabrikaId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["FabrikaID"].Value);
                bolgeId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BolgeID"].Value);

                // Doğrudan SelectedValue ata
                cmbFabrikalar.SelectedValue = fabrikaId;
                cmbBolgeAdi.SelectedValue = bolgeId;

                cmbFabrikalar.Text = dataGridView1.CurrentRow.Cells["Fabrika Adı"].Value?.ToString().Trim();
                cmbBolgeAdi.Text = dataGridView1.CurrentRow.Cells["Bölge Adı"].Value?.ToString().Trim();
                textBox2.Text = dataGridView1.CurrentRow.Cells["Ad"].Value?.ToString().Trim();
                textBox5.Text = dataGridView1.CurrentRow.Cells["TC"].Value?.ToString().Trim();
                textBox6.Text = dataGridView1.CurrentRow.Cells["Telefon"].Value?.ToString().Trim();
                
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            // 1️⃣ DataGridView'de seçili satır var mı kontrol et
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Lütfen silmek için bir üretici seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string ureticiAd = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString().Trim() ?? "Belirsiz";



            // 2️⃣ Seçili kullanıcının ID'sini al
            int ureticiId;
            if (!int.TryParse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString(), out ureticiId))
            {
                MessageBox.Show("Geçerli bir üretici ID'si alınamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3️⃣ Silme onayı
            DialogResult onay = MessageBox.Show("Seçili kullanıcıyı silmek istediğinize emin misiniz?",
                                                "Silme Onayı",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Question);

            if (onay != DialogResult.Yes)
                return;


            string query = $@"DELETE FROM Ureticiler WHERE UreticiID = {ureticiId}";
            //string query = "DELETE FROM Kullanicilar WHERE UreticiID = " + ureticiId;
            veritabaniBag.SorguCalistir(query);
            MessageBox.Show("Üretici Başarıyla Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ureticiListele();
            temizle();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            // 1️⃣ Zorunlu alan kontrolü
            if (string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2️⃣ Güncellenecek kullanıcı seçili mi kontrol et
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Güncellemek için bir kullanıcı seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3️⃣ Seçili kullanıcının ID'sini al
            int ureticiId;
            if (!int.TryParse(dataGridView1.CurrentRow.Cells["ID"].Value.ToString(), out ureticiId))
            {
                MessageBox.Show("Geçerli bir üretici ID'si alınamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

           


            // 5️⃣ Güncelleme sorgusu ve parametrelerin hazırlanması
            string tarihStr = DateTime.Now.ToString("yyyy-MM-dd");
            int fabrikaDeger = Convert.ToInt32(cmbFabrikalar.SelectedValue?.ToString().Trim());
            int bolgeDeger = Convert.ToInt32(cmbBolgeAdi.SelectedValue?.ToString().Trim());
            string queryGuncelle = $@"
                    UPDATE Ureticiler 
                    SET UreticiAdi = '{textBox2.Text.Trim()}', 
                        FabrikaID = {fabrikaDeger}, 
                        BolgeID = {bolgeDeger}, 
                        UreticiTC = '{textBox5.Text.Trim()}',  
                        UreticiTel = '{textBox6.Text.Trim()}', 
                        GuncellemeTarihi = '{tarihStr}'
                    WHERE UreticiID = {ureticiId}";

            // 6️⃣ Sorguyu çalıştır ve sonucu kontrol et            
            int sonuc = veritabaniBag.SorguCalistirNonQuery(queryGuncelle);

            if (sonuc > 0)
            {
                MessageBox.Show("Kullanıcı başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ureticiListele();
                temizle();
            }
            else
            {
                MessageBox.Show("Güncelleme işlemi başarısız oldu!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            temizle();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        public void temizle()
        {

            //// 5️⃣ TextBox’ları temizle
            cmbFabrikalar.SelectedIndex = 0;
            cmbBolgeAdi.SelectedIndex = 0;
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
        }

    }
}
