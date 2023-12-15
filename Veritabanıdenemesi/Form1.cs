using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Veritabanıdenemesi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            // MySQL bağlantı dizesi XAMPP için
            string connectionString = "server=127.0.0.1;port=3306;database=kullanici;user=root;";
            MySqlConnection connection = new MySqlConnection(connectionString);

            try
            {
                connection.Open(); // Veritabanı bağlantısını aç
                Console.WriteLine("Veritabanı bağlantısı başarılı.");

                // INSERT sorgusu
                string insertQuery = "INSERT INTO kullanicilar (kullaniciadi, password) VALUES (@kullaniciadi, @sifre)";
                MySqlCommand command = new MySqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@kullaniciadi", kullaniciAdi);
                command.Parameters.AddWithValue("@sifre", sifre);

                int affectedRows = command.ExecuteNonQuery(); // Sorguyu çalıştır

                if (affectedRows > 0)
                {
                    Console.WriteLine("Kullanıcı başarıyla eklendi.");
                    MessageBox.Show("Kullanıcı başarıyla eklendi.");
                }
                else
                {
                    Console.WriteLine("Kullanıcı eklenirken bir hata oluştu.");
                    MessageBox.Show("Kullanıcı eklenirken bir hata oluştu.");
                }

                connection.Close(); // Veritabanı bağlantısını kapat
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Veritabanı bağlantısında hata oluştu: " + ex.Message);
                MessageBox.Show("Veritabanı bağlantısında hata oluştu: " + ex.Message);
            }
        }
    }
}