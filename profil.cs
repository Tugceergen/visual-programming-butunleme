using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;

namespace basketbolFinal
{
    public partial class profil : Form
    {
        Form1 main;
        public profil(Form1 form1)
        {
            InitializeComponent();
          main = form1;
        }

        MySql.Data.MySqlClient.MySqlConnection conn;
        void baglanti()
        {
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;" +
                   "pwd=secret;database=voleybol";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
        }
        string sifre;

        void kayitGetir()
        {
            baglanti();
            conn.Open();
            MySqlCommand baglan = new MySqlCommand("select ad, soyad, kullaniciAdi, sifre from kullanici where kullaniciAdi='" + main.textBox1.Text + "'", conn);
            MySqlDataReader oku = baglan.ExecuteReader();
            if (oku.Read())
            {
                textBox1.Text = oku.GetString(0);
                textBox2.Text = oku.GetString(1);
                textBox3.Text = oku.GetString(2);
                sifre = oku.GetString(3);
                oku.Close();
                conn.Close();
            }
            else
            {
                oku.Close();
                conn.Close();
            }

        }
        private void profil_Load(object sender, EventArgs e)
        {
           kayitGetir();
            textBox4.Select();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text=="" || textBox2.Text=="" || textBox3.Text=="")
            {
                MessageBox.Show("Lüften Bilgilerinizi Eksiksiz Doldurun");
            }
            else if (textBox4.Text=="")
            {
                MessageBox.Show("Eski Şifrenini Doğru Girmeden Kullanıcı Bilgilerinde Degişiklik Yapamazsınız!");
            }
            else
            {
                string cozul,cozul2;
                cozul = md5.sifrele(textBox4.Text, "eeee");
                cozul2 = md5.sifrele(textBox5.Text, "eeee");
                if (cozul==sifre)
                {
                    conn.Open();
                    MySqlCommand guncelle = new MySqlCommand("Update kullanici set ad='"+textBox1.Text+"', soyad='"+textBox2.Text+"', sifre=@p1 Where kullaniciAdi='"+textBox3.Text+"'  ",conn);
                    if (textBox5.Text=="")
                    {
                        guncelle.Parameters.AddWithValue("@p1", cozul);
                    }
                    else
                    {
                        guncelle.Parameters.AddWithValue("@p1",cozul2);
                    }
                    guncelle.ExecuteNonQuery();
                    conn.Close();
                    kayitGetir();
                    MessageBox.Show("Kullanıcı Bilgileriniz Güncellendi!");
                    textBox4.Clear();
                    textBox5.Clear();
                }
                else
                {
                    MessageBox.Show("Eski Şifre Yanlış"); 
                }
                

            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
