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
using System.Text.RegularExpressions;

namespace CargoManagementSystem
{
    public partial class Form4 : Form
    {
        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
        string mobileNumber = @"(^([+]{1}[8]{2}|0088)?(01){1}[3-9]{1}\d{8})$";
        string idvalidation  = @"^\d+$";

        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
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
                if (b > 0)
                {
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    this.Hide();
                    f2.Show();
                }
                else
                {
                    MessageBox.Show("Your Information Is Incorrect !");
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

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, pattern) == false)
            {
                textBox3.Focus();
                errorProvider1.SetError(this.textBox3, "Email Is Invalid !");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (Regex.IsMatch(textBox5.Text, mobileNumber) == false)
            {
                textBox5.Focus();
                errorProvider2.SetError(this.textBox5, "Mobile number is invalid, Try with Country Code");
            }
            else
            {
                errorProvider2.Clear();
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) == true)
            {
                textBox1.Focus();
                errorProvider3.SetError(this.textBox1, "Name Cannot Be Empty!");
            }
            else
            {
                errorProvider3.Clear();
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, idvalidation) == false)
            {
                textBox2.Focus();
                errorProvider4.SetError(this.textBox2, "ID is invalid, Try Integer Numbers");
            }
            else
            {
                errorProvider4.Clear();
            }

        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text) == true)
            {
                textBox4.Focus();
                errorProvider5.SetError(this.textBox4, "PassWord Cannot Be Empty!");
            }
            else
            {
                errorProvider5.Clear();
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text) == true)
            {
                textBox6.Focus();
                errorProvider6.SetError(this.textBox6, "Company Name Cannot Be Empty!");
            }
            else
            {
                errorProvider6.Clear();
            }
        }
    }
}
