using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mobile_Shop_Management
{
    public partial class MobilePhone : Form
    {
        public MobilePhone()
        {
            InitializeComponent();
            DisplayMobile();
        }
        readonly SqlConnection Con =  new SqlConnection(connectionString: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\mecsx\Documents\Mobile MS.mdf"";Integrated Security=True;Connect Timeout=30");

        private void DisplayMobile()
        {
            try
            {
                Con.Open();
                string Query = "select * from MTBL";
                SqlDataAdapter sda = new SqlDataAdapter(Query, Con);
                SqlCommandBuilder sql = new SqlCommandBuilder(sda);
                var ds = new DataSet();
                sda.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                Con.Close();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if(textBox1.Text==" " || comboBox1.Text==" " || comboBox2.Text==" " || textBox2.Text==" " || textBox3.Text==" ")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    string query = "insert into MTBL values('"+textBox1.Text+ "', '"+comboBox1.Text+ "', '"+comboBox2.Text+ "', '"+textBox2.Text+ "', '"+textBox3.Text+"')";
                    SqlCommand cmd = new SqlCommand(query,Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Entered Succsessfully");
                    DisplayMobile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == " ")
            {
                MessageBox.Show("Enter the Mobile ID");
            }
            else
            {
                try
                {
                    Con.Open();
                    string query = "delete From MTBL WHERE MId='" + textBox1.Text + "';";
                    SqlCommand cmd = new SqlCommand(query, Con);
                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Deleted Succsessfully");
                    DisplayMobile();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    Con.Close();
                }
            }   
        }

        private void HomeBtn_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == " " || comboBox1.Text == " " || comboBox2.Text == " " || textBox2.Text == " " || textBox3.Text == " ")
                {
                    MessageBox.Show("Missing Info");
                }
                else
                {
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update MTBL set MName=@CN, Series=@CP, Storage=@S, Price=@P WHERE MId=@Key", Con);
                    cmd.Parameters.AddWithValue("@CN", comboBox1.Text);
                    cmd.Parameters.AddWithValue("@CP", comboBox2.Text);
                    cmd.Parameters.AddWithValue("@S", textBox2.Text);

                    cmd.Parameters.AddWithValue("@P", textBox3.Text);
                    cmd.Parameters.AddWithValue("@Key", textBox1.Text);

                    cmd.ExecuteNonQuery();
                    Con.Close();
                    MessageBox.Show("Record Update Succsessfully");
                    DisplayMobile();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Con.Close();
            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }
    }
}
