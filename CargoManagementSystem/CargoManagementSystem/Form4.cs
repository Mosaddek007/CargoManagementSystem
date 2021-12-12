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
    public partial class Form4 : Form
    {
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "insert into Client (name,id,email,pass,phone,company_name) values(@name,@id,@email,@pass,@phone,@company_name)";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("name", textBox1.Text);
                cmd.Parameters.AddWithValue("id", textBox2.Text);
                cmd.Parameters.AddWithValue("email", textBox3.Text);
                cmd.Parameters.AddWithValue("pass", textBox4.Text);
                cmd.Parameters.AddWithValue("phone", textBox5.Text);
                cmd.Parameters.AddWithValue("company_name", textBox6.Text);

                int b = cmd.ExecuteNonQuery();
                if (b>0)
                {
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    this.Hide();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Your Information Is Incorrect");
                }
            }
            else
            {
                MessageBox.Show("Fill Up All The Information Please");
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }
    }
}
