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
    public partial class hosadmin : Form
    {
        DataTable table = new DataTable("table");
        public hosadmin()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void close_Click(object sender, EventArgs e)
        {
            home he = new home();
            he.Show();
            this.Hide();
        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.White;
            close.BackColor = Color.Red;
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Insert into hadmis2 values('" + comboBox2.Text + "','" + dateTimePicker2.Text + "','" + dateTimePicker3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + comboBox3.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox6.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Saved!");
                comboBox2.SelectedIndex = -1;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker3.Value = DateTime.Now;
                textBox4.Clear();
                textBox5.Clear();
                comboBox3.SelectedIndex = -1;
                textBox8.Clear();
                textBox7.Clear();
                comboBox1.SelectedIndex = -1;
                textBox9.Clear();
                textBox6.Clear();
                dateTimePicker1.Value = DateTime.Now;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if(comboBox2.Text !="" &&  textBox4.Text !="" && textBox5.Text !="" && textBox7.Text !="" && textBox9.Text !="" && comboBox3.Text !="" && comboBox1.Text !="")
            {
                String[] row1 = new string[] { comboBox2.Text, textBox4.Text, textBox5.Text, textBox7.Text, textBox9.Text, comboBox3.Text, comboBox1.Text };
                    dataGridView1.Rows.Add(row1);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                   
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.CustomFormat="dd/MM/yyyy";
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
        }

        private void hosadmin_Load(object sender, EventArgs e)
        {
            table.Columns.Add("ID", Type.GetType("System.String"));
            table.Columns.Add("Studentname", Type.GetType("System.String"));
            table.Columns.Add("Studing", Type.GetType("System.String"));
            table.Columns.Add("Prefix", Type.GetType("System.String"));
            table.Columns.Add("Roomno", Type.GetType("System.Int32"));
            table.Columns.Add("Hostelid", Type.GetType("System.String"));
            table.Columns.Add("Status", Type.GetType("System.String"));
            table.Columns.Add("Vacatedate", Type.GetType("System.String"));
            table.Columns.Add("Discription", Type.GetType("System.String"));
            dataGridView1.DataSource = table;
            dataGridView1.Columns[7].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[2].DefaultCellStyle.Format = "dd/MM/yyyy";
            dataGridView1.Columns[3].DefaultCellStyle.Format = "dd/MM/yyyy";
            Fill();
           
        }
        private void Fill()
        {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From hadmis2";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "HostelName";
            dataGridView1.Columns[1].HeaderText = "TranDate";
            dataGridView1.Columns[2].HeaderText = "AddmissionDate";
            dataGridView1.Columns[3].HeaderText = "ID";
            dataGridView1.Columns[4].HeaderText = "StudentName";
            dataGridView1.Columns[5].HeaderText = "Studying";
            dataGridView1.Columns[6].HeaderText = "Prefix";
            dataGridView1.Columns[7].HeaderText = "Roomno";
            dataGridView1.Columns[8].HeaderText = "HostelID";
            dataGridView1.Columns[9].HeaderText = "Status";
            dataGridView1.Columns[10].HeaderText = "VacateDate";
            dataGridView1.Columns[11].HeaderText = "Discript";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From hadmis2 where hostelname = '"+comboBox2.Text+"'";
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
                String query = "update hadmis2 set hostelname ='" + comboBox2.Text + "',trandate =getdate(),admissdate =getdate(),sname ='" + textBox5.Text + "',study ='" + textBox7.Text + "',prefix ='" + textBox8.Text + "',roomno ='" + textBox9.Text + "',hostelid ='" + comboBox3.Text + "',status ='" + comboBox1.Text + "',vacatedate =getdate(),discript ='" + textBox6.Text + "' where id= '" + textBox4.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Updated");
                Fill();
                comboBox2.SelectedIndex = -1;
                dateTimePicker2.Value = DateTime.Now;
                dateTimePicker3.Value = DateTime.Now;
                textBox4.Clear();
                textBox5.Clear();
                comboBox3.SelectedIndex = -1;
                textBox8.Clear();
                textBox7.Clear();
                comboBox1.SelectedIndex = -1;
                textBox9.Clear();
                textBox6.Clear();
                dateTimePicker1.Value = DateTime.Now;
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
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["hostelname"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["id"].FormattedValue.ToString();
                textBox5.Text= dataGridView1.Rows[e.RowIndex].Cells["sname"].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["study"].FormattedValue.ToString();
                textBox8.Text = dataGridView1.Rows[e.RowIndex].Cells["prefix"].FormattedValue.ToString();
                textBox9.Text = dataGridView1.Rows[e.RowIndex].Cells["roomno"].FormattedValue.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["hostelid"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["status"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["discript"].FormattedValue.ToString();

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Delete from hadmis2 where id ='" + textBox4.Text + "'";
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
