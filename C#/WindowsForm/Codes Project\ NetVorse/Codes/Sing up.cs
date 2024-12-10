using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Sing_up : Form
    {
        public Sing_up()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();    
            this.Hide();
            log.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter your firstname");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter your Lastname");

            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter your Email");

            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Enter your Username");
                
            }
            else if (textBox5.Text =="") 
            {
                MessageBox.Show("Enter your Password");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter your Repeat Password");
            }
            else if (textBox5.Text != textBox6.Text)
            {
                MessageBox.Show("Password Error");
            }
            else
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
                con.Open();
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM [enter] WHERE [uname]=?";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@uname", textBox4.Text);
                int count = (int)cmd.ExecuteScalar();
                if (count == 1)
                {
                    con.Close();

                    MessageBox.Show("user already registered");

                }
                else
                {
                    con.Close();
                    OleDbConnection connect = new OleDbConnection();
                    connect.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
                    connect.Open();
                    OleDbCommand com = new OleDbCommand();
                    com.CommandText = "insert into [enter] ([fname],[lname],[email],[uname],[password]) values(?,?,?,?,?)";
                    com.Parameters.AddWithValue("@fname", textBox1.Text);
                    com.Parameters.AddWithValue("@lname", textBox2.Text);
                    com.Parameters.AddWithValue("@email", textBox3.Text);
                    com.Parameters.AddWithValue("@uname", textBox4.Text);
                    com.Parameters.AddWithValue("password", textBox6.Text);
                    com.Connection = connect;
                    com.ExecuteNonQuery();

                    OleDbConnection coon = new OleDbConnection();
                    coon.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
                    coon.Open();
                    OleDbCommand coom = new OleDbCommand();
                    coom.CommandText = "insert into [reserv]([username]) values(?)";
                    coom.Parameters.AddWithValue("@username", textBox4.Text);
                    coom.Connection = coon;
                    coom.ExecuteNonQuery();
                    coon.Close();

                    MessageBox.Show("your sing up was successful !");
                    this.Hide();
                    Form1 log = new Form1();
                    log.ShowDialog();
                    connect.Close();
                    
                   
                }
                

            }

        }

      

        private void Sing_up_Load(object sender, EventArgs e)
        {
            ControlBox = false;

        }
    }
}
