using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            String username;
            String password;
            MySqlCommand cmd;
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "")
            {
                MessageBox.Show("Please don't leave username empty");
            }
            else
            {
                if (password == "")
                {
                    MessageBox.Show("Please don't leave password empty");
                }
                else
                {
                    cnn = new MySqlConnection("Data Source=sql9.freesqldatabase.com;Initial Catalog=sql9322806;User ID=sql9322806;Password=Q9bJAM5Bkq");
                    cnn.Open();
                    cmd = new MySqlCommand("SELECT * FROM users", cnn);
                    var output = cmd.ExecuteReader();
                    while (output.Read())
                    {
                        if (username == output.GetString(0))
                        {
                            if (password == output.GetString(3))
                            {
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Try Again");
                            }
                        }
                    }
                    cnn.Close();
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            String username;
            String password;
            MySqlCommand cmd;
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "")
            {
                MessageBox.Show("Please don't leave username empty");
            }
            else
            {
                if (password == "")
                {
                    MessageBox.Show("Please don't leave password empty");
                }
                else
                {
                    cnn = new MySqlConnection("Data Source=sql9.freesqldatabase.com;Initial Catalog=sql9322806;User ID=sql9322806;Password=Q9bJAM5Bkq");
                    cnn.Open();
                    cmd = new MySqlCommand("SELECT * FROM users", cnn);
                    var output = cmd.ExecuteReader();
                    while (output.Read())
                    {
                        if (username == output.GetString(0))
                        {
                            if (password == output.GetString(3))
                            {
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Try Again");
                            }
                        }
                    }
                    cnn.Close();
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MySqlConnection cnn;
            String username;
            String password;
            MySqlCommand cmd;
            username = textBox1.Text;
            password = textBox2.Text;
            if (username == "")
            {
                MessageBox.Show("Please don't leave username empty");
            }
            else
            {
                if (password == "")
                {
                    MessageBox.Show("Please don't leave password empty");
                }
                else
                {
                    cnn = new MySqlConnection("Data Source=sql9.freesqldatabase.com;Initial Catalog=sql9322806;User ID=sql9322806;Password=Q9bJAM5Bkq");
                    cnn.Open();
                    cmd = new MySqlCommand("SELECT * FROM users", cnn);
                    var output = cmd.ExecuteReader();
                    while (output.Read())
                    {
                        if (username == output.GetString(0))
                        {
                            if (password == output.GetString(3))
                            {
                                Form2 form2 = new Form2();
                                form2.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Try Again");
                            }
                        }
                    }
                    cnn.Close();
                }
            }
        }
    }
}
