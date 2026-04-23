using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace ŞEKERTAKİPOTOMASYONU
{
    
    public class veritabaniBag
    {
        private static string connectionString = "Server=eylulari\\SQLEXPRESS;Database=SekerTakipDB;Trusted_Connection=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public static void TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    MessageBox.Show("Veritabanı bağlantısı başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public static bool KullaniciGirisi(string kullaniciAd, string kullaniciSifre)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE kullaniciAd = @kullaniciAd AND kullaniciSifre = @kullaniciSifre";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kullaniciAd", kullaniciAd);
                    cmd.Parameters.AddWithValue("@kullaniciSifre", kullaniciSifre);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Giriş kontrolünde hata: " + ex.Message);
                    return false;
                }
            }
        }
        public static int SorguCalistirNonQuery(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorgu çalıştırma hatası: " + ex.Message);
                    return -1;
                }
            }
        }
        public static class VeritabaniBag
        {
            private static readonly string connString = @"Data Source=SERVER_ADIN;Initial Catalog=VERITABANI_ADIN;Integrated Security=True";
            // Integrated Security=True yerine SQL Server Authentication kullanıyorsan uygun şekilde değiştir

            public static SqlConnection GetConnection()
            {
                return new SqlConnection(connString);
            }

            public static DataTable SorguCalistir(string sql)
            {
                using (SqlConnection conn = GetConnection())
                {
                    try
                    {
                        conn.Open();
                        SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        return dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Sorgu hatası: " + ex.Message);
                        return null;
                    }
                }
            }
        }


        public static DataTable SorguCalistir(string sql)
        {
            using (SqlConnection conn = GetConnection())
            {
                try
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Sorgu çalıştırma hatası: " + ex.Message);
                    return null;
                }
            }
        }

    }

}



