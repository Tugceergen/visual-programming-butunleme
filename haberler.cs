using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using MySql.Data;



namespace basketbolFinal
{
    public partial class haberler : Form
    {
        MySql.Data.MySqlClient.MySqlConnection baglan;
        anaSayfa main;
        public haberler(anaSayfa anaSayfa)
        {
            InitializeComponent();
            main = anaSayfa;
            try
            {
                baglan = new MySql.Data.MySqlClient.MySqlConnection("server=127.0.0.1; uid=root;pwd=secret;database=voleybol");
                baglan.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException hata)
            {
                MessageBox.Show(hata.Message);
            }

        }

        private void haberler_Load(object sender, EventArgs e)
        {
            habergetir();
            string[] parcalar = baslik.Split('/');
            string[] parcalarr = konu.Split('/');

            richTextBox3.Text= parcalar[1];
            richTextBox4.Text = parcalar[2];
            richTextBox5.Text = parcalar[3];
            richTextBox7.Text = parcalar[4];

            richTextBox1.Text = parcalarr[1];
            richTextBox2.Text = parcalarr[2];
            richTextBox6.Text = parcalarr[3];
            richTextBox8.Text = parcalarr[4];
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }


        string baslik,konu;
        public void habergetir()
        {
            baslik = "";
            konu = "";
            MySqlCommand yy = new MySqlCommand("SELECT*FROM haberler", baglan);
            MySqlDataReader dr = yy.ExecuteReader();

            while (dr.Read())
            {
                baslik += "/" + dr["baslik"].ToString();
                konu += "/" + dr["konu"].ToString();
            }
            dr.Close();
        }

    }
}
