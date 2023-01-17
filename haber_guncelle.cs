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
    public partial class haber_guncelle : Form
    {
        anaSayfa main;
        MySql.Data.MySqlClient.MySqlConnection baglan;
        public haber_guncelle(anaSayfa anaSayfa)
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
        DataTable tablo=new DataTable();
        private void haber_guncelle_Load(object sender, EventArgs e)
        {
            tablo.Columns.Add("HABER İD", typeof(string));
            tablo.Columns.Add("BAŞLIK", typeof(string));
            tablo.Columns.Add("HABER KONUSU", typeof(string));
            dataGridView1.DataSource = tablo;
            getir();
        }
        public void getir()
        {

            MySqlCommand cmd = new MySqlCommand("SELECT*FROM haberler", baglan);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                tablo.Rows.Add(dr[0], dr[1], dr[2]);
                dataGridView1.DataSource = tablo;
            }
            dr.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            admin admin = new admin(main);
            admin.Show();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen boş bırakmayınız");
                }
                else
                {
                    DialogResult baslangictus;
                    baslangictus = MessageBox.Show("'" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' = '" + textBox1.Text + "' ve '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' = '" + textBox2.Text + "' olarak güncellemek istediğinize emin misiniz?", "haber güncelleme ekranı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (baslangictus == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("UPDATE haberler SET baslik='" + textBox1.Text + "' , konu='" + textBox2.Text + "' WHERE  id='" + textBox3.Text + "'", baglan);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("'" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' = '" + textBox1.Text + "' ve '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' = '" + textBox2.Text + "' olarak başarıyla güncellendi");
                        haber_guncelle f = new haber_guncelle(main);
                        f.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
               
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
              
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {

                if ( textBox3.Text == "")
                {
                    MessageBox.Show("Lütfen silmek istediğiniz haberi yukarıdan seçiniz");
                }
                else
                {
                    DialogResult baslangictus;
                    baslangictus = MessageBox.Show("Başlık= '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' konu= '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' haber bilgilerini silmek istediğinize emin misiniz?", "haber silme ekranı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (baslangictus == DialogResult.Yes)
                    {
                        MySqlCommand cmd = new MySqlCommand("DELETE FROM haberler WHERE  id='" + textBox3.Text + "'", baglan);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Başlık= '" + dataGridView1.CurrentRow.Cells[1].Value.ToString() + "' konu= '" + dataGridView1.CurrentRow.Cells[2].Value.ToString() + "' haber başarıyla silindi");
                        haber_guncelle f = new haber_guncelle(main);
                        f.Show();
                        this.Close();
                    }
                }

            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.ToString());
            }
        }
    }
}
