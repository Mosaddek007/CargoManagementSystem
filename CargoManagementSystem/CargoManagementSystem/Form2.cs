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
    public partial class Form2 : Form
    {
        string idvalidation = @"^\d+$";
        string cs = ConfigurationManager.ConnectionStrings["CargoManagementSystem"].ConnectionString;
        public Form2()
        {
            InitializeComponent();
        }
        public static string name;
        public static int Id;
        public static string email;
        public static string pass;
        public static string cname;
        public static string phone;

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 f4 = new Form4();
            this.Hide();
            f4.ShowDialog();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
          
        }
        
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != "" && textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(cs);
                string query = "select *from Client where id = @id and pass = @pass";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                cmd.Parameters.AddWithValue("id", textBox1.Text);
                cmd.Parameters.AddWithValue("pass", textBox2.Text);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    name = dt.Rows[0]["name"].ToString();
                    Id = Convert.ToInt32(dt.Rows[0]["id"].ToString());
                    email = dt.Rows[0]["email"].ToString();
                    phone = (dt.Rows[0]["phone"].ToString());
                    cname = dt.Rows[0]["company_name"].ToString();
                    pass = dt.Rows[0]["pass"].ToString();

                    Form6 f6 = new Form6();
                    
                    this.Hide();
                    f6.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Your PassWord is Wrong, Try Again");
                }
            }
            else
            {
                MessageBox.Show("Please Enter Your ID & PassWord");
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, idvalidation) == false)
            {
                textBox1.Focus();
                errorProvider1.SetError(this.textBox1, "ID Is Invalid !");
            }
            else
            {
                errorProvider1.Clear();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = true;
            }
            else
            {
                textBox2.UseSystemPasswordChar = false;
            }
        }
    }
}
