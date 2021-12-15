using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace CargoManagementSystem
{
    public delegate void cair(int a, int b, int c);
    public partial class Form14 : Form
    {
        int sych = 28000;
        int syrj = 37000;
        int disc = 5500;
        int sum = 0;
        public void cost(int a, int b, int d)
        {
            sum = (a - d) + (b - d);
        }
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form14()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form7 f7 = new Form7();
            this.Hide();
            f7.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && dateTimePicker1.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into cargoair (id,bid,fcity,tcity,t_departure) values(@id,@bid,@fcity,@tcity,@t_departure)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("bid", textBox2.Text);
                cmd.Parameters.AddWithValue("fcity", comboBox1.Text.ToString());
                cmd.Parameters.AddWithValue("tcity", comboBox2.Text.ToString());
                cmd.Parameters.AddWithValue("t_departure", dateTimePicker1.Text);

                int b = cmd.ExecuteNonQuery();
                if (b > 0)
                {
                    MessageBox.Show("Your Cargo is Booked");
                    textBox1.Clear();
                    textBox2.Clear();

                    Form7 f7 = new Form7();
                    this.Hide();
                    f7.Show();
                }
                else
                {
                    MessageBox.Show("Fill Information Correctly");
                }

            }
            else
            {
                MessageBox.Show("Your Booking Is Failled");

            }
            cair c = this.cost;
            c(sych, syrj, disc);

            MessageBox.Show("Total Cost Will Be :" + sum);
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            textBox1.Text = Form2.Id.ToString();
            SqlConnection con = new SqlConnection(cs);
            SqlDataAdapter sda = new SqlDataAdapter("Select isnull (max(cast(bid as int)),0)+1 from cargoair", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            textBox2.Text = dt.Rows[0][0].ToString();
        }
    }
}
