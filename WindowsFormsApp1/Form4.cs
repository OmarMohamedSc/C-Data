using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using MySql.Data.MySqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String username;
            String Email;
            String Password;
            MySqlParameter user;
            MySqlParameter pass;
            MySqlParameter mail;
            MySqlConnection cnn;
            MySqlCommand cmd;
            String cmdz;
            username = textBox1.Text;
            Email = textBox2.Text;
            Password = textBox3.Text;
            user = new MySqlParameter("@Username", username);
            pass = new MySqlParameter("@Password", Password);
            mail = new MySqlParameter("@Email", Email);
            if (username == "")
            {
                MessageBox.Show("Please Enter a username");
            }
            else
            {
                if (Password == "")
                {
                    MessageBox.Show("Please Enter a password");
                }
                else
                {
                    if(Email == "")
                    {
                        MessageBox.Show("Please enter an email");
                    }
                    else
                    {
                        cnn = new MySqlConnection("Data Source=sql9.freesqldatabase.com;Initial Catalog=sql9322806;User ID=sql9322806;Password=Q9bJAM5Bkq");
                        cnn.Open();
                        cmdz = "INSERT INTO `users`(`Username`, `Email`, `Password`) VALUES (@Username, @Email, @Password)";
                        cmd = new MySqlCommand(cmdz, cnn);
                        cmd.Parameters.Add(user);
                        cmd.Parameters.Add(pass);
                        cmd.Parameters.Add(mail);
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
        }
    }
}
