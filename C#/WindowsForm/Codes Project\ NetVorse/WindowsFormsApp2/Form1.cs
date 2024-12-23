using NetVorse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            MaximizeBox = false;
            textBox2.PasswordChar = '*';
            textBox1.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.CommandText= "SELECT COUNT(*) FROM [enter] WHERE uname =? AND password=?";
                com.Parameters.AddWithValue("@uname",textBox1.Text);
                com.Parameters.AddWithValue("@password",textBox2.Text);
                com.Connection = con;
                int count=(int)com.ExecuteScalar();
                if (count == 1)
                {
                    NetVorse.Properties.Settings.Default.logined = true;
                    NetVorse.Properties.Settings.Default.Save();
                    NetVorse.Properties.Settings.Default.userlog=textBox1.Text;
                    NetVorse.Properties.Settings.Default.Save();


                    enter enter = new enter();
                    this.Hide();
                    con.Close();

                    enter.ShowDialog();
                    
                    
                }
                else
                {
                    MessageBox.Show("user not found");
                }
                
            }
            else if (textBox1.Text != "" && textBox2.Text == "")
            {
                MessageBox.Show("Please Enter your Password");
            }
            else if (textBox1.Text == "" && textBox2.Text != "")
            {
                MessageBox.Show("Please Enter your Username");
            }
            else
            {
                MessageBox.Show("Error");
            }
            
            

                
            

        }

        private void singupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sing_up sing_Up = new Sing_up();
            this.Hide();
            sing_Up.ShowDialog();
            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            this.Hide();
            help.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
