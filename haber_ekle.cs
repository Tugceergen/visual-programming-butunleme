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
    public partial class haber_ekle : Form
    {
        anaSayfa main;
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public haber_ekle(anaSayfa anaSayfa)
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

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {

                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("boş bırakmayınız");
                }
                else
                {
                    DialogResult baslangictus;
                    baslangictus = MessageBox.Show("başlık= '" + textBox1.Text + "', konu= '" + textBox2.Text + "' Haber bilgilerini eklemek istediğinize emin misiniz?", "duyuru ekleme ekranı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (baslangictus == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("insert into haberler(baslik,konu) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglan);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("başlık= '" + textBox1.Text + "', konu= '" + textBox2.Text + "'haber bilgileri eklendi");
                        admin admin = new admin(main);
                        admin.Show();
                        Close();
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            admin admin = new admin(main);
            admin.Show();
            Close();

        }
    }
}
