using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Expense : Form
    {
        public Expense()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Insert into expen values('" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Text + "','" + comboBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Saved");
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Value = DateTime.Now;
                comboBox2.SelectedIndex = -1;
                textBox1.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (textBox2.Text != "" && textBox3.Text != "" && comboBox2.Text != "" && textBox1.Text != "" && textBox4.Text != "" && textBox5.Text != "" )
            {
                String[] row1 = new string[] { textBox2.Text, textBox3.Text, comboBox2.Text, textBox1.Text, textBox4.Text, textBox5.Text };
                dataGridView1.Rows.Add(row1);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

         private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From expen where tname = '" + comboBox2.Text + "'";
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
                String query = "update expen set roomno ='" + textBox2.Text + "',day=getdate(),tname ='" + comboBox2.Text + "',amt ='" + textBox1.Text + "',remark ='" + textBox4.Text + "', aday='"+textBox5.Text+"' where sid ='" + textBox3.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Updated");
                Fill();
                textBox2.Clear();
                textBox3.Clear();
                dateTimePicker1.Value = DateTime.Now;
                comboBox2.SelectedIndex = -1;
                textBox1.Clear();
                textBox4.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
            void Expense_Load(object sender, EventArgs e)
            {
                Fill();
            }
             void Fill()
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Select * From expen";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "RoomNo";
            dataGridView1.Columns[1].HeaderText = "StudentID";
            dataGridView1.Columns[2].HeaderText = "Date";
            dataGridView1.Columns[3].HeaderText = "TokenName";
            dataGridView1.Columns[4].HeaderText = "Amount";
            dataGridView1.Columns[5].HeaderText = "Remark";
            dataGridView1.Columns[6].HeaderText = "AttendanceDay";
            conn.Close();
            }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["roomno"].FormattedValue.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["sid"].FormattedValue.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tname"].FormattedValue.ToString();
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["amt"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["remark"].FormattedValue.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells["aday"].FormattedValue.ToString();
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Delete from expen where sid ='" + textBox3.Text + "'";
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }

        
    }
