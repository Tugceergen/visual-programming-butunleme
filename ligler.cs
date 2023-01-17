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
    public partial class ligler : Form
    {
        anaSayfa main;
        public ligler(anaSayfa anaSayfa)
        {
            InitializeComponent();
            main = anaSayfa;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            main.Show();
        }
    }
}
