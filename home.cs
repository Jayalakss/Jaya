using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

     

        private void close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void close_MouseEnter(object sender, EventArgs e)
        {
            close.ForeColor = Color.White;
            
        }

        private void close_MouseLeave(object sender, EventArgs e)
        {
            close.ForeColor = Color.Red;
          
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.ForeColor = Color.Red;
            button1.BackColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackColor = Color.DarkSlateGray;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Red;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.ForeColor = Color.Red;
            button2.BackColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackColor = Color.DarkSlateGray;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 fm = new Form1();
            fm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            hosadmin ho = new hosadmin();
            ho.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Feesgen ge = new Feesgen();
            ge.Show();
            this.Hide();
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.ForeColor = Color.Red;
            button3.BackColor = Color.White;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
            button3.BackColor = Color.DarkSlateGray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Token to = new Token();
            to.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Expense ex = new Expense();
            ex.Show();
            this.Hide();
        }

        private void button4_MouseEnter(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Red;
            button4.BackColor = Color.White;
        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.White;
            button4.BackColor = Color.DarkSlateGray;
        }

        private void button5_MouseEnter(object sender, EventArgs e)
        {
            button5.ForeColor = Color.Red;
            button5.BackColor = Color.White;
        }

        private void button5_MouseLeave(object sender, EventArgs e)
        {
            button5.ForeColor = Color.White;
            button5.BackColor = Color.DarkSlateGray;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            refund ex = new refund();
            ex.Show();
            this.Hide();
        }
    }
}
