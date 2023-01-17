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
    public partial class duyurular : Form
    {
        anaSayfa main;
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public duyurular(anaSayfa anaSayfa)
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }

        private void duyurular_Load(object sender, EventArgs e)
        {
            duyurugetir();
            string[] parcalar = baslik.Split('/');
            string[] parcalarr = konu.Split('/');

            label1.Text = parcalar[1];
            label3.Text = parcalar[2];
            label5.Text = parcalar[3];

            label2.Text = parcalarr[1];
            label4.Text = parcalarr[2];
            label6.Text = parcalarr[3];


        }

        string baslik, konu;
        public void duyurugetir()
        {
            baslik = "";
            konu = "";
            MySqlCommand yy = new MySqlCommand("SELECT*FROM duyuru", baglan);
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
