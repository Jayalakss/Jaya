using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.password.AutoSize = false;
            this.password.Size = new Size(this.password.Size.Width, 50);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.Black;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }

        private void login_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open(); 
            string query = "SELECT COUNT(*) FROM loginhost WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username.Text);
            cmd.Parameters.AddWithValue("@password", password.Text);
            int count = (int)cmd.ExecuteScalar();
            conn.Close();
            if(count>0)
            {
                MessageBox.Show("Login Success", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("Error in login");
            }
            if(username.Text=="admin" && password.Text
                =="admin")
            { 
            home ds = new home();
                ds.Show();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked==true)
            {
                password.UseSystemPasswordChar = false;
                
            }
            else
            {
                password.UseSystemPasswordChar = true;
            }
        }
    }
}
