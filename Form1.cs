using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basketbolFinal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySql.Data.MySqlClient.MySqlConnection conn;
        public void baglanti()
        {
            
            string myConnectionString;
            myConnectionString = "server=localhost;uid=root;" +
                   "pwd=secret;database=voleybol";
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            conn.ConnectionString = myConnectionString;
           
        }
        private void pictureBox6_Click(object sender, EventArgs e)
        {
            
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                MessageBox.Show("lütfen bilgilerinizi eksiksiz girin!");
            }
            else
            {
                textBox2.Text = md5.sifrele(textBox2.Text,"eeee");
                baglanti();
                conn.Open();
                MySqlCommand baglan = new MySqlCommand("select * from kullanici where kullaniciAdi=@p1 and sifre=@p2",conn);
                baglan.Parameters.AddWithValue("@p1", textBox1.Text);
                baglan.Parameters.AddWithValue("@p2", textBox2.Text);
                MySqlDataReader dr = baglan.ExecuteReader();
                if (dr.Read())
                {
                    anaSayfa anaSayfa = new anaSayfa(this);
                    anaSayfa.Show();
                   this.Hide();
                    
                    
                }
                else
                {
                    textBox2.Clear();
                    MessageBox.Show("Kullanıcı bilgileriniz hatalı!");
                }
            }
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
           Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

            kayitOl kayitOl = new kayitOl(this);
            kayitOl.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            profil profil = new profil(this);
            textBox1.Select();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                pictureBox6_Click(sender, e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
