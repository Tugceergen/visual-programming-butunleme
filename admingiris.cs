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
using MySql.Data.MySqlClient;

namespace basketbolFinal
{
    public partial class admingiris : Form
    {
        anaSayfa main;
        public admingiris(anaSayfa anaSayfa)
        {
            InitializeComponent();
            main = anaSayfa;
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
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("lütfen bilgilerinizi eksiksiz girin!");
            }
            else
            {
                textBox2.Text = md5.sifrele(textBox2.Text, "eeee");
                baglanti();
                conn.Open();
                MySqlCommand baglan = new MySqlCommand("select * from admin where kullaniciAdi=@p1 and sifre=@p2", conn);
                baglan.Parameters.AddWithValue("@p1", textBox1.Text);
                baglan.Parameters.AddWithValue("@p2", textBox2.Text);
                MySqlDataReader dr = baglan.ExecuteReader();
                if (dr.Read())
                {
                   admin n= new admin(main);
                    n.Show();   
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
            this.Close();
            main.Show();
        }

        private void admingiris_Load(object sender, EventArgs e)
        {
            textBox1.Select();
        }
    }
}
