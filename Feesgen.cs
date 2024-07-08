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
    public partial class Feesgen : Form
    {
        public Feesgen()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Insert into hfeegen1 values('" + textBox5.Text + "','" + dateTimePicker2.Text + "','" + textBox1.Text + "','" + textBox2.Text + "','"+comboBox3.Text+"','" + dateTimePicker1.Text + "','" + comboBox1.Text + "','" + textBox4.Text + "','" + dateTimePicker3.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Saved");
                textBox5.Clear();
                dateTimePicker2.Value = DateTime.Now;
                textBox1.Clear();
                textBox2.Clear();
                comboBox3.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                textBox4.Clear();
                dateTimePicker3.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (comboBox1.Text != "" && textBox1.Text != "" && textBox2.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && dateTimePicker2.Text != "" && dateTimePicker3.Text != "")
            {
                String[] row1 = new string[] { comboBox1.Text, textBox1.Text, textBox2.Text, comboBox2.Text, comboBox3.Text, dateTimePicker2.Text, dateTimePicker3.Text };
                dataGridView1.Rows.Add(row1);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            home he = new home();
            he.Show();
            this.Hide();
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.Black;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }

        private void Feesgen_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From hfeegen1";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "InvoiceNo";
            dataGridView1.Columns[1].HeaderText = "InvoiceDate";
            dataGridView1.Columns[2].HeaderText = "StudentID";
            dataGridView1.Columns[3].HeaderText = "StudentName";
            dataGridView1.Columns[4].HeaderText = "FeesName";
            dataGridView1.Columns[5].HeaderText = "AcademicYear";
            dataGridView1.Columns[6].HeaderText = "Semester";
            dataGridView1.Columns[7].HeaderText = "Amount";
            dataGridView1.Columns[8].HeaderText = "DueDate";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From hfeegen1 where sid = '" + textBox1.Text + "'";
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
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "update hfeegen1 set invno='"+textBox5.Text+"',invdate =getdate(),sname ='" + textBox2.Text + "',fname='"+comboBox3.Text+"',ayear=getdate(),sem ='" + comboBox1.Text + "',amt ='" + textBox4.Text + "',duedate ='" + dateTimePicker3.Text + "' where sid='"+ textBox1.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Updated");
                Fill();
                textBox5.Clear();
                dateTimePicker2.Value = DateTime.Now;
                textBox1.Clear();
                textBox2.Clear();
                comboBox3.SelectedIndex = -1;
                dateTimePicker1.Value = DateTime.Now;
                comboBox1.SelectedIndex = -1;
                textBox4.Clear();
                dateTimePicker3.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["invno"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["sid"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["sname"].FormattedValue.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["fname"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["sem"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["amt"].FormattedValue.ToString();
              
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Delete from hfeegen1 where sid='" + textBox1.Text + "'";
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
