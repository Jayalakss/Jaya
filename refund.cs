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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class refund : Form
    {
        public refund()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }
        SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                String query = "Insert into refund values('" + textBox2.Text + "','" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + dateTimePicker2.Text + "','" + comboBox2.Text + "','" + comboBox1.Text + "','" + textBox3.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Saved!");
                
                textBox2.Clear();
                textBox1.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                comboBox2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
                textBox3.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat = "yyyy/MM/dd";
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy/MM/dd";
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            /*conn.Open();
            if (textBox2.Text != "")
            {
                SqlCommand cmd = new SqlCommand("SELECT sname FROM hadmis2 WHERE id = @id", conn);
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox2.Text));
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    textBox1.Text = reader.GetString(0);
                }

                reader.Close();
                conn.Close();
            }*/
        }
        private void Fill()
        {
            
            String query = "Select * From refund";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "Student ID";
            dataGridView1.Columns[1].HeaderText = "Student Name";
            dataGridView1.Columns[2].HeaderText = "JoinDate";
            dataGridView1.Columns[3].HeaderText = "Vacate Date";
            dataGridView1.Columns[4].HeaderText = "Month Value";
            dataGridView1.Columns[5].HeaderText = "Fees Name";
            dataGridView1.Columns[6].HeaderText = "Amount";
            
            conn.Close();
        }

        private void refund_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["sid"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["sname"].FormattedValue.ToString();       
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["mvalue"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["amt"].FormattedValue.ToString();
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            String query = "Select * From refund where fname = '" + comboBox1.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                conn.Open();
                String query = "update refund set sname ='" + textBox1.Text + "',jdate =getdate(),vdate =getdate(),mvalue ='" + comboBox2.Text + "',fname ='" + comboBox1.Text + "',amt ='" + textBox3.Text + "' where sid= '" + textBox2.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Updated");
                Fill();
               
               
                textBox2.Clear();
                textBox1.Clear();
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker2.Value = DateTime.Now;
                comboBox2.SelectedIndex = -1;
                comboBox1.SelectedIndex = -1;
                textBox3.Clear();
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                conn.Open();
                String query = "Delete from refund where sid='"+textBox2.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Deleted");
                Fill();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        }
}
