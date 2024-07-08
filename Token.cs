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
    public partial class Token : Form
    {
        public Token()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Insert into htoken values('" + comboBox4.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + textBox6.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + textBox2.Text + "','" + textBox7.Text + "')";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Saved");
                comboBox4.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox6.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                textBox2.Clear();
                textBox7.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (comboBox4.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && textBox6.Text != "" && textBox4.Text != "" && comboBox1.Text != "" && textBox2.Text != "" && textBox7.Text != "") 
            {
                String[] row1 = new string[] { comboBox4.Text, comboBox2.Text, comboBox3.Text, textBox6.Text, textBox4.Text, comboBox1.Text, textBox2.Text ,textBox7.Text};
                dataGridView1.Rows.Add(row1);
            }
            else
            {
                MessageBox.Show("Empty Text Field", "EMPTY", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void close_Click(object sender, EventArgs e)
        {
            home ho = new home();
            ho.Show();
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Token_Load(object sender, EventArgs e)
        {
            Fill();
        }
        private void Fill()
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From htoken";
            SqlDataAdapter da = new SqlDataAdapter(query, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].HeaderText = "TokenID";
            dataGridView1.Columns[1].HeaderText = "TokenName";
            dataGridView1.Columns[2].HeaderText = "StudentName";
            dataGridView1.Columns[3].HeaderText = "DisplayOrder";
            dataGridView1.Columns[4].HeaderText = "Value";
            dataGridView1.Columns[5].HeaderText = "Color";
            dataGridView1.Columns[6].HeaderText = "AdjestedFeesName";
            dataGridView1.Columns[7].HeaderText = "Discript";
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
            conn.Open();
            String query = "Select * From htoken where tname = '" + comboBox2.Text + "'";
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
                String query = "update htoken set tname ='" + comboBox2.Text + "',sname ='" + comboBox3.Text + "',dorder ='" + textBox6.Text + "',value ='" + textBox4.Text + "',color ='" + comboBox1.Text + "',afname ='" + textBox2.Text + "',discript ='" + textBox7.Text + "' where tid='"+comboBox4.Text+"'";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteScalar();
                conn.Close();
                MessageBox.Show("Successfully Updated");
                Fill();
                comboBox4.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                textBox6.Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                textBox2.Clear();
                textBox7.Clear();
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
                comboBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["tid"].FormattedValue.ToString();
                comboBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["tname"].FormattedValue.ToString();
                comboBox3.Text = dataGridView1.Rows[e.RowIndex].Cells["sname"].FormattedValue.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells["dorder"].FormattedValue.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells["value"].FormattedValue.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells["color"].FormattedValue.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells["afname"].FormattedValue.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells["discript"].FormattedValue.ToString();
               
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection("Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=loginhos;Integrated Security=True;TrustServerCertificate=True");
                conn.Open();
                String query = "Delete from htoken where dorder ='" + textBox6.Text + "'";
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
