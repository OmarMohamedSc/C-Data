using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        MySqlConnection cnn;
        public Form3()
        {
            InitializeComponent();
            cnn = new MySqlConnection("Data Source=sql9.freesqldatabase.com;Initial Catalog=sql9322806;User ID=sql9322806;Password=Q9bJAM5Bkq");
            cnn.Open();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT * FROM users", cnn);
            var output = cmd.ExecuteReader();
            while (output.Read())
            {
                listBox1.Items.Add(output["Username"].ToString());
            }
            cnn.Close();
            timer1.Start();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String chosen;
            MySqlCommand cmd;
            MySqlParameter chossen;
            chosen = listBox1.GetItemText(listBox1.SelectedItem);
            if (chosen == ""){
                MessageBox.Show("Please Select a user");
            }
            else
            {
                cnn.Open();
                chossen = new MySqlParameter("@Username", chosen);
                cmd = new MySqlCommand("DELETE FROM users WHERE `Username`=@Username", cnn);
                cmd.Parameters.Add(chossen);
                cmd.ExecuteNonQuery();
                listBox1.Items.Clear();
                cmd = new MySqlCommand("SELECT * FROM users", cnn);
                var output = cmd.ExecuteReader();
                while (output.Read())
                {
                    listBox1.Items.Add(output["Username"].ToString());
                }
                cnn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String chosen;
            String username;
            String password;
            String email;
            MySqlParameter user;
            MySqlParameter passz;
            MySqlParameter mail;
            MySqlParameter chossen;
            bool changeusername = true;
            bool changepassword = true;
            bool changeemail = true;
            bool nothingtoupdate = false;
            MySqlCommand cmd;
            String cmdz;
            chosen = listBox1.GetItemText(listBox1.SelectedItem);
            username = textBox1.Text;
            password = textBox2.Text;
            email = textBox3.Text;
            user = new MySqlParameter("@Username", username);
            passz = new MySqlParameter("@Password", password);
            mail = new MySqlParameter("@Email", email);
            chossen = new MySqlParameter("@Chosen", chosen);
            if (username == "")
            {
                // Remove username from SQL Command
                changeusername = false;
            }
            if (password == "")
            {
                // Remove password from SQL Command
                changepassword = false;
            }
            if (email == "")
            {
                changeemail = false;
            }
            
            cmdz = "UPDATE users SET ";
            if (changeusername)
            {
                cmdz += "`Username`=@Username ";
            }
            if (changepassword)
            {
                cmdz += ",`Password`=@Password ";
            }
            if (changeemail)
            {
                cmdz += ",`Email`=@Email ";
            }
            if (changeusername == false)
            {
                if (changepassword == false)
                {
                    if (changeemail == false)
                    {
                        MessageBox.Show("Nothing to update");
                        nothingtoupdate = true;
                    }
                }
            }
            if (nothingtoupdate == false)
            {
                // Update
                cmdz += " WHERE `Username`=@Chosen";
                MessageBox.Show(cmdz);
                cnn.Open();
                cmd = new MySqlCommand(cmdz, cnn);
                cmd.Parameters.Add(user);
                cmd.Parameters.Add(passz);
                cmd.Parameters.Add(mail);
                cmd.Parameters.Add(chossen);
                try
                {
                    cnn.Open();
                }
                catch
                {
                    // Pass
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Changed Successfuly");
                    listBox1.Items.Clear();
                    cmd = new MySqlCommand("SELECT * FROM users", cnn);
                    var output = cmd.ExecuteReader();
                    while (output.Read())
                    {
                        listBox1.Items.Add(output["Username"].ToString());
                    }
                    cnn.Close();
                }
                catch
                {
                    //Pass
                    MessageBox.Show("Try Again");
                }
                
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
            } catch {
                // Pass
            }
            
            listBox1.Items.Clear();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT * FROM users", cnn);
            var output = cmd.ExecuteReader();
            while (output.Read())
            {
                listBox1.Items.Add(output["Username"].ToString());
            }
            cnn.Close();
            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                cnn.Open();
            }
            catch
            {
                // Pass
            }

            listBox1.Items.Clear();
            MySqlCommand cmd;
            cmd = new MySqlCommand("SELECT * FROM users", cnn);
            var output = cmd.ExecuteReader();
            while (output.Read())
            {
                listBox1.Items.Add(output["Username"].ToString());
            }
            cnn.Close();
        }
    }
}
    