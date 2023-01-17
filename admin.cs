using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace basketbolFinal
{
    public partial class admin : Form
    {
        anaSayfa main;
        public admin(anaSayfa anaSayfa)
        {
            InitializeComponent();
            main = anaSayfa;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            haber_ekle k = new haber_ekle(main);
            k.Show();
            Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            haber_guncelle guncelle = new haber_guncelle(main);
            guncelle.Show();
            Hide();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            duyuru_ekle d = new duyuru_ekle(main);
            d.Show();
            Hide();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            duyuru_guncelle d = new duyuru_guncelle(main);
            d.Show();
            Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           admingiris admingiris = new admingiris(main);
            admingiris.Show();
            Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            oyuncu_ekle oyuncu = new oyuncu_ekle(main);
            oyuncu.Show();
            Hide();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            oyuncu_guncelle oyuncu = new oyuncu_guncelle(main);
            oyuncu.Show();
            Hide();
        }
    }
}
