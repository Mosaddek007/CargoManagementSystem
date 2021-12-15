using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CargoManagementSystem
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form20 f20 = new Form20();
            this.Hide();
            f20.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            Form15 f15 = new Form15();
            this.Hide();
            f15.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form16 f16 = new Form16();
            this.Hide();
            f16.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form17 f17 = new Form17();
            this.Hide();
            f17.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form18 f18 = new Form18();
            this.Hide();
            f18.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form19 f19 = new Form19();
            this.Hide();
            f19.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form23 f23 = new Form23();
            this.Hide();
            f23.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.ShowDialog();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
