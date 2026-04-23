using System;
using System.Data;
using System.Windows.Forms;
using ŞEKERTAKİPOTOMASYONU.Properties;

namespace ŞEKERTAKİPOTOMASYONU
{
    public partial class AnaSayfa : Form
    {
        public AnaSayfa()
        {
            InitializeComponent();

        }

        // Kullanıcı işlemleri butonu
        private void button1_Click(object sender, EventArgs e)
        {
            Kullanici anaForm = new Kullanici();
            anaForm.Show();
        }

        // Çiftçi işlemleri butonu
        private void button2_Click(object sender, EventArgs e)
        {
            Form2 ciftciForm = new Form2(); // Çiftçi İşlemleri formunu oluştur
            ciftciForm.Show(); // Formu göster
        }

        private void button3_Click(object sender, EventArgs e)
        {
            randevuİslemleri randevuForm = new randevuİslemleri();
            randevuForm.Show(); // Formu açar
        }

        private void AnaSayfa_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Application.Exit(); 
        }
    }
}
