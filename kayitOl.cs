using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace basketbolFinal
{
    public partial class kayitOl : Form
    {
        public kayitOl(Form1 form1)
        {
            InitializeComponent();
            main = form1;
        }
        Form1 main;
        MySql.Data.MySqlClient.MySqlConnection conn;

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void baglanti() {
            
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=root;" +
                   "pwd=secret;database=voleybol";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
        }
       

        bool durum;
       void kontrol()
        {
            baglanti();
            conn.Open();
            MySqlCommand kontrol = new MySqlCommand("select * from kullanici where kullaniciAdi=@p1",conn);
            kontrol.Parameters.AddWithValue("@p1", textBox3.Text);
            MySqlDataReader dr =kontrol.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            conn.Close();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            try
            {
                baglanti();
                kontrol();
                conn.Open();
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
                {
                    MessageBox.Show("lütfen bilgilerinizi kontrol edin!");
                }
                else if (textBox4.Text != textBox5.Text)
                {
                    MessageBox.Show("sifreler aynı değil!");
                }
                else if (durum == true)
                {
                    textBox4.Text = md5.sifrele(textBox4.Text, "eeee");
                    MySqlCommand komutkaydet = new MySqlCommand("insert into kullanici(ad,soyad,kullaniciAdi,sifre) values (@p1,@p2,@p3,@p4)", conn);
                    komutkaydet.Parameters.AddWithValue("@p1", textBox1.Text);
                    komutkaydet.Parameters.AddWithValue("@p2", textBox2.Text);
                    komutkaydet.Parameters.AddWithValue("@p3", textBox3.Text);
                    komutkaydet.Parameters.AddWithValue("@p4", textBox4.Text);
                    komutkaydet.ExecuteNonQuery();
                    MessageBox.Show("Kayıt Tamamlandı lütfen Giriş Yapınız.");
                    textBox4.Clear();
                    textBox5.Clear();
                    conn.Close();
                }       
                else
                {
                    MessageBox.Show("Kullanıcı Adı Zaten kayıtlı");
                }
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void kayitOl_Load(object sender, EventArgs e)
        {
            textBox1.Select();
            
        }

        private void kayitOl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                pictureBox6_Click(sender, e);
            }
        }
    }
}
