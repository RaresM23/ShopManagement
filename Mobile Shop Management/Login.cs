using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            richTextBox2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(richTextBox1.Text == " " &&  richTextBox2.Text == " ")
                {
                    MessageBox.Show("Missing Information");
                }
                else if(richTextBox1.Text == "Admin" && richTextBox2.Text == "Password")
                { 
                    Home home = new Home();
                    home.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Please enter the correct admin name and password");
                }

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
