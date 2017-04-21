using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dobokocka
{
    public partial class Form1 : Form
    {
        int eltelt = 0;
        int kilepes = 0;
        int dobas;
        int ut;
        int[] dobott = new int[6];
        float[] dobottsz = new float[6];
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            eltelt++;
            toolStripStatusLabel1.Text = String.Format("Eltelt: {0:00}:{1:00}", eltelt / 60, eltelt % 60);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = String.Format("Eltelt: {0:00}:{1:00}", eltelt / 60, eltelt % 60);
            toolStripStatusLabel2.Text = "Kilepesek szama: " + kilepes.ToString();
            toolStripStatusLabel3.Text = String.Format("Pontos ido: {0:hh:mm:ss}", DateTime.Now);

            button2_Click(sender, e);
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = String.Format("Pontos ido: {0:hh:mm:ss}", DateTime.Now);
        }

        private void lassabbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval *= 2;
        }

        private void gyorsabbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval /= 2;
        }

        private void normalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eltelt = 0;
            toolStripStatusLabel1.Text = String.Format("Eltelt: {0:00}:{1:00}", eltelt / 60, eltelt % 60);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ut = r.Next(1, 7);
            dobott[ut - 1]++;
            dobas++;
            label7.Text = ut.ToString();
            pictureBox1.Image = imageList1.Images[ut-1];
            listBox1.Items.Insert(0, ut.ToString());
            for (int i = 0; i < 6; i++)
            {
                //dobottsz[i] = (float)dobott[i] / dobas * 100;
                dobottsz[i] = 100.0f * dobott[i] / dobas;
            }
            label1.Text = "1-es: " + dobott[0] + " db = " + dobottsz[0] + " %";
            label2.Text = "2-es: " + dobott[1] + " db = " + dobottsz[1] + " %";
            label3.Text = "3-as: " + dobott[2] + " db = " + dobottsz[2] + " %";
            label4.Text = "4-es: " + dobott[3] + " db = " + dobottsz[3] + " %";
            label5.Text = "5-os: " + dobott[4] + " db = " + dobottsz[4] + " %";
            label6.Text = "6-os: " + dobott[5] + " db = " + dobottsz[5] + " %";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; i++)
            {
                dobott[i] = 0;
            }
            dobas = 0;
            label1.Text = label2.Text = label3.Text = label4.Text = label5.Text = label6.Text = label7.Text = "Meg nem volt dobas";
            listBox1.Items.Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Valoban ki akarsz lepni?", "FIGYELEM", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
                Close();
            kilepes++;
            toolStripStatusLabel2.Text = "Kilepesek szama: " + kilepes.ToString();
        }
    }
}
