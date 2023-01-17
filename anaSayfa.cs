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
    public partial class anaSayfa : Form
    {
        Form1 main;
        public anaSayfa(Form1 form1)
        {
            InitializeComponent();
            main = form1;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 fr=new Form1();
            fr.Show();
            this.Close();
           
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            basket basket = new basket();
            basket.ShowDialog();
          
        }

        private void haberlerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            haberler haberler=new haberler(this);
            haberler.Show();
            this.Hide();
        }

        private void liglerToolStripMenuItem_Click(object sender, EventArgs e)
        {
           ligler ligler=new ligler(this);
            ligler.Show();
            this.Hide();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void anaSayfa_Load(object sender, EventArgs e)
        {
            toolStripTextBox1.Enabled = false;
        }

        private void takımlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            takimlar takimlar=new takimlar(this);
            takimlar.Show();
            this.Hide();
        }

        private void oyuncularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            oyuncular oyuncular=new oyuncular(this);
            oyuncular.Show();
            this.Hide();
        }

        private void duyurularToolStripMenuItem_Click(object sender, EventArgs e)
        {
            duyurular duyurular=new duyurular(this);
            duyurular.Show();
            this.Hide();
        }

        private void canlıMaçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            canliMac canliMac = new canliMac(this);
            canliMac.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            profil profil = new profil(main);
            profil.ShowDialog();
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            admingiris n = new admingiris(this);
            n.Show();
            Hide();
        }
    }
}
