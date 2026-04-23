using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ŞEKERTAKİPOTOMASYONU
{
    public partial class randevuİslemleri : Form
    {
       
        public int fabrikaId, bolgeId;

        public randevuİslemleri()
        {
            InitializeComponent();
        }

        private void randevuİslemleri_Load(object sender, EventArgs e)
        {
           
            // Diğer ComboBox'lar manuel olarak çağrılan metotlarla doldurulacak.
            cmbFabrikalarDoldur();
            cmbBolgeDoldur();
            cmbUreticiDoldur();
            comboBoxFabrikalar.SelectedIndexChanged += comboBoxFabrikalar_SelectedIndexChanged_1;
            comboBoxBolgeler.SelectedIndexChanged += comboBoxBolgeler_SelectedIndexChanged;

            
            RandevulariListele();
        }

        private void cmbFabrikalarDoldur()
        {
            try
            {
                comboBoxFabrikalar.Items.Clear();

                string query = "SELECT FabrikaID, FabrikaAdi FROM Fabrikalar ORDER BY FabrikaAdi";

                DataTable dt = veritabaniBag.SorguCalistir(query);  // DataTable döndürüyor

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxFabrikalar.DataSource = dt;
                    comboBoxFabrikalar.DisplayMember = "FabrikaAdi";   // ComboBox'ta gözükecek alan
                    comboBoxFabrikalar.ValueMember = "FabrikaID";      // Seçildiğinde değeri alacağımız alan
                    comboBoxFabrikalar.SelectedIndex = 0;

                    
                }
                else
                {
                    comboBoxFabrikalar.Text = "Fabrika Bulunamadı.";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Fabrikalar getirilirken hata: " + ex.Message);
            }
        }

        private void cmbBolgeDoldur()
        {
            if (comboBoxFabrikalar.SelectedValue == null) return;

            int fabrikaID = Convert.ToInt32(comboBoxFabrikalar.SelectedValue);

            try
            {
                string query = $"SELECT BolgeID, BolgeAdi FROM Bolgeler WHERE FabrikaID = {fabrikaID} ORDER BY BolgeAdi";

                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxBolgeler.DataSource = dt;
                    comboBoxBolgeler.DisplayMember = "BolgeAdi"; // ComboBox'ta görünecek alan
                    comboBoxBolgeler.ValueMember = "BolgeID";    // Seçildiğinde değeri alacağımız alan
                    comboBoxBolgeler.SelectedIndex = 0;
                }
                else
                {
                    comboBoxBolgeler.Text = "Bölge Bulunamadı.";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölgeler getirilirken hata: " + ex.Message);
            }
        }

        private void cmbUreticiDoldur()
        {
            if (comboBoxFabrikalar.SelectedValue == null || comboBoxBolgeler.SelectedValue == null) return;

            int fabrikaID = Convert.ToInt32(comboBoxFabrikalar.SelectedValue);
            int bolgeID = Convert.ToInt32(comboBoxBolgeler.SelectedValue);

            try
            {
                comboBoxUreticiAd.DataSource = null;
                comboBoxUreticiAd.Items.Clear();

                string query = $"SELECT UreticiID, UreticiAdi FROM Ureticiler WHERE FabrikaID = {fabrikaID} AND BolgeID = {bolgeID} ORDER BY UreticiAdi";
                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxUreticiAd.DataSource = dt;
                    comboBoxUreticiAd.DisplayMember = "UreticiAdi";
                    comboBoxUreticiAd.ValueMember = "UreticiID";
                    comboBoxUreticiAd.SelectedIndex = 0;
                    
                }
                else
                {
                    comboBoxUreticiAd.Text = "Üretici Bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üreticiler getirilirken hata: " + ex.Message);
            }
        }

        private void RandevulariListele()
        {
            try
            {
                string query = $@"SELECT r.RandevuID as rID, r.UreticiID as ID,   r.FabrikaID as FabID, 
                     r.BolgeID as BID, f.FabrikaAdi as [Fabrika Adı], 
                     b.BolgeAdi as [Bölge Adı], r.UreticiAd as Ad,  r.UreticiTC as TC, 
                     r.UreticiTel as Telefon, r.RandevuTarih as [Randevu Tarih], 
                     r.RandevuTonu as [Randevu Ton] FROM Randevu r
                    inner join Fabrikalar f on r.FabrikaID = f.FabrikaID  
                    inner join Bolgeler b on r.BolgeId = b.BolgeID";
                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null)
                {
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns["rID"].Visible = false;
                    dataGridView1.Columns["ID"].Visible = false;
                    dataGridView1.Columns["FabID"].Visible = false;
                    dataGridView1.Columns["BID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevular listelenirken hata oluştu: " + ex.Message);
            }
        }

      


        private void btnOlustur_Click(object sender, EventArgs e)
        {
            try { 
             if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Geçmiş tarihli randevu alamazsınız");
                return;
            }

            
            decimal randevuTonu;
            if (string.IsNullOrWhiteSpace(textBoxRandevuTon.Text))
            {
                MessageBox.Show("Lütfen 'Randevu Tonu' için bir değer giriniz.");
                return;
            }
            if (!decimal.TryParse(textBoxRandevuTon.Text, out randevuTonu))
            {
                MessageBox.Show("Lütfen 'Randevu Tonu' için geçerli bir sayı giriniz.");
                return;
            }
             string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd").Trim();

             int ureticiID = (int)comboBoxUreticiAd.SelectedValue;
            int fabrikaID = (int)comboBoxFabrikalar.SelectedValue;
            int bolgeID = (int)comboBoxBolgeler.SelectedValue;

            string queryUretici = $@"SELECT UreticiAdi, UreticiTel, UreticiTC 
                         FROM Ureticiler 
                         WHERE UreticiID = {ureticiID}";
            DataTable dt = veritabaniBag.SorguCalistir(queryUretici);

            string telNo = "", ureticiTCNo = "", ureticiAd = "";

            if (dt != null && dt.Rows.Count > 0) // Satır varsa
            {
                DataRow row = dt.Rows[0]; // İlk satır

                ureticiAd = row["UreticiAdi"].ToString();
                telNo = row["UreticiTel"].ToString();
                ureticiTCNo = row["UreticiTC"].ToString();
            }




            comboBoxUreticiAd.Text.Trim();
            string query = $@"INSERT INTO Randevu (UreticiID, RandevuTarih, RandevuTonu, FabrikaID, BolgeID, UreticiAd,UreticiTel,UreticiTC) 
            VALUES ({ureticiID},'{tarih}',{randevuTonu},{fabrikaID},{bolgeID},'{ureticiAd}','{telNo}','{ureticiTCNo}')";
            veritabaniBag.SorguCalistir(query);
            MessageBox.Show("Randevu başarıyla oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RandevulariListele();

                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        private void comboBoxBolgeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxFabrikalar.SelectedValue == null || comboBoxFabrikalar.SelectedValue is DataRowView ||
                comboBoxBolgeler.SelectedValue == null || comboBoxBolgeler.SelectedValue is DataRowView)
                return;

            int fabrikaID = Convert.ToInt32(comboBoxFabrikalar.SelectedValue);
            int bolgeID = Convert.ToInt32(comboBoxBolgeler.SelectedValue);
           

            try
            {
                string query = $"SELECT UreticiID, UreticiAdi FROM Ureticiler WHERE FabrikaID = {fabrikaID} AND BolgeID = {bolgeID} ORDER BY UreticiAdi";
                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxUreticiAd.DataSource = dt;
                    comboBoxUreticiAd.DisplayMember = "UreticiAdi";
                    comboBoxUreticiAd.ValueMember = "UreticiID";
                    comboBoxUreticiAd.SelectedIndex = 0;
                }
                else
                {
                    comboBoxUreticiAd.Text = "Üretici Bulunamadı.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Üreticiler getirilirken hata: " + ex.Message);
            }
        }

        public void temizle()
        {

            //// 5️⃣ TextBox’ları temizle
            comboBoxFabrikalar.SelectedIndex = 0;
            comboBoxBolgeler.SelectedIndex = 0;
            comboBoxUreticiAd.SelectedIndex = 0;
            textBoxRandevuTon.Clear();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen güncellemek için bir randevu seçin.");
                    return;
                }

                int randevuID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["rID"].Value);

                if (dateTimePicker1.Value.Date < DateTime.Now.Date)
                {
                    MessageBox.Show("Geçmiş tarihli randevu alamazsınız.");
                    return;
                }

                decimal randevuTonu;
                if (!decimal.TryParse(textBoxRandevuTon.Text, out randevuTonu))
                {
                    MessageBox.Show("Lütfen geçerli bir Randevu Tonu girin.");
                    return;
                }

                int ureticiID = (int)comboBoxUreticiAd.SelectedValue;
                int fabrikaID = (int)comboBoxFabrikalar.SelectedValue;
                int bolgeID = (int)comboBoxBolgeler.SelectedValue;

                string queryUretici = $@"SELECT UreticiAdi, UreticiTel, UreticiTC 
                                 FROM Ureticiler 
                                 WHERE UreticiID = {ureticiID}";
                DataTable dt = veritabaniBag.SorguCalistir(queryUretici);

                string ureticiAd = "", telNo = "", ureticiTC = "";
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    ureticiAd = row["UreticiAdi"].ToString();
                    telNo = row["UreticiTel"].ToString();
                    ureticiTC = row["UreticiTC"].ToString();
                }

                string tarih = dateTimePicker1.Value.ToString("yyyy-MM-dd");

                string query = $@"UPDATE Randevu 
                          SET UreticiID={ureticiID}, FabrikaID={fabrikaID}, BolgeID={bolgeID}, 
                              UreticiAd='{ureticiAd}', UreticiTel='{telNo}', UreticiTC='{ureticiTC}', 
                              RandevuTarih='{tarih}', RandevuTonu={randevuTonu} 
                          WHERE RandevuID={randevuID}";

                veritabaniBag.SorguCalistir(query);
                MessageBox.Show("Randevu başarıyla güncellendi!");
                RandevulariListele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme sırasında hata: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentRow == null)
                {
                    MessageBox.Show("Lütfen silmek için bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DateTime randevuTarih = Convert.ToDateTime(dataGridView1.CurrentRow.Cells["Randevu Tarih"].Value);
                dateTimePicker1.Text = randevuTarih.ToString("yyyy-MM-dd");



                if (randevuTarih < DateTime.Now.Date)
                {
                    MessageBox.Show("Geçmiş tarihli randevu silinemez.");
                    return;
                }

                int randevuID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["rID"].Value);

                DialogResult sonuc = MessageBox.Show("Bu randevuyu silmek istediğinize emin misiniz?",
                                     "Onay",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (sonuc == DialogResult.Yes)
                {
                    string query = $@"DELETE FROM Randevu WHERE RandevuID={randevuID}";
                    veritabaniBag.SorguCalistir(query);
                    MessageBox.Show("Randevu başarıyla silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Silme işlemi iptal edildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                RandevulariListele();
                temizle();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Silme işlemi sırasında hata: " + ex.Message);
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // Başlık satırı tıklanırsa çık

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            try
            {
                // ComboBox ve TextBox değerlerini doldur
                textBoxRandevuTon.Text = row.Cells["Randevu Ton"].Value.ToString();

                int fabrikaID = Convert.ToInt32(row.Cells["FabID"].Value);
                int bolgeID = Convert.ToInt32(row.Cells["BID"].Value);
                int ureticiID = Convert.ToInt32(row.Cells["ID"].Value);

                // Fabrika ComboBox
                comboBoxFabrikalar.SelectedValue = fabrikaID;

                // Bölge ComboBox, önce bölgeyi doldur
                cmbBolgeDoldur();
                comboBoxBolgeler.SelectedValue = bolgeID;

                // Üretici ComboBox, önce üreticiyi doldur
                cmbUreticiDoldur();
                comboBoxUreticiAd.SelectedValue = ureticiID;

                // Tarih
                dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Randevu Tarih"].Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bilgiler box'lara doldurulurken hata oluştu: " + ex.Message);
            }
        }


        private void comboBoxFabrikalar_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxFabrikalar.SelectedValue == null || comboBoxFabrikalar.SelectedValue is DataRowView)
                return;

            int fabrikaID = Convert.ToInt32(comboBoxFabrikalar.SelectedValue);


            try
            {
                string query = $"SELECT BolgeID, BolgeAdi FROM Bolgeler WHERE FabrikaID = {fabrikaID} ORDER BY BolgeAdi";
                DataTable dt = veritabaniBag.SorguCalistir(query);

                if (dt != null && dt.Rows.Count > 0)
                {
                    comboBoxBolgeler.DataSource = dt;
                    comboBoxBolgeler.DisplayMember = "BolgeAdi";
                    comboBoxBolgeler.ValueMember = "BolgeID";
                    comboBoxBolgeler.SelectedIndex = 0;
                }
                else
                {
                    comboBoxBolgeler.Text = "Üretici Bulunamadı.";
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Bölgeler getirilirken hata: " + ex.Message);
            }
        }

    }
}