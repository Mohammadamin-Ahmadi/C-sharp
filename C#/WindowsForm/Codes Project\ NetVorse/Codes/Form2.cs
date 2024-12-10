
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp2;

namespace NetVorse
{
    public partial class Form2 : Form
    {
        

        public Form2(string usernname)
        {
            InitializeComponent();
            
            
        }

        public Form2()
        {
            InitializeComponent();
        }

       

        private void Form2_Load(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "SELECT * FROM [enter] WHERE [uname]=?";
            com.Parameters.AddWithValue("@uname",NetVorse.Properties.Settings.Default.userlog);
            com.Connection = con;
            OleDbDataReader reader = com.ExecuteReader();
            if (reader.Read())
            {
                textBox1.Text = reader["fname"].ToString();
                textBox2.Text = reader["lname"].ToString();
                textBox3.Text = reader["email"].ToString();
                textBox4.Text = reader["uname"].ToString();
                textBox5.Text = reader["password"].ToString();

                if (reader["picture"] != DBNull.Value)
                {
                    byte[] image = (byte[])reader["picture"];
                    using (MemoryStream ms = new MemoryStream(image))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                        con.Close();
                    }
                }
                else
                {
                    pictureBox1.Image=null;
                    con.Close();

                }
            }
            else
            {
                
                
                MessageBox.Show("Error");
                
                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            enter enter = new enter();
            enter.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = NetVorse.Properties.Settings.Default.userlog;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "Update [enter] set [fname]=?,[lname]=?,[email]=?,[uname]=?,[password]=? WHERE [uname]=? ";
            com.Connection=con;
            com.Parameters.AddWithValue("@fname",textBox1.Text);
            com.Parameters.AddWithValue("@lname",textBox2.Text);
            com.Parameters.AddWithValue("@email",textBox3.Text);
            com.Parameters.AddWithValue("@uname",textBox4.Text);
            com.Parameters.AddWithValue("@password",textBox5.Text);
            com.Parameters.AddWithValue("@uname",username);
            int raw =(int)com.ExecuteNonQuery();
            con.Close();

            if (raw > 0)
            {
                NetVorse.Properties.Settings.Default.userlog = textBox4.Text;
                NetVorse.Properties.Settings.Default.Save();
                MessageBox.Show("changes applied");
               

            }
            else
            {
                MessageBox.Show("An error occurred Please try again later");
            }

           

        }

        private void savePhotoToDatabase(byte[] photobyte)
        {
            string username=NetVorse.Properties.Settings.Default.userlog;
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "UPDATE [enter] SET [picture]=@picture where [uname]=@unname ";
            com.Connection = con;
            com.Parameters.AddWithValue("@picture", photobyte);
            com.Parameters.AddWithValue("@uname", username);

            int row =(int)com.ExecuteNonQuery();
            if (row > 0)
            {
                con.Close();

                MessageBox.Show("photo changed");
            }
            else
            {
                con.Close();

                MessageBox.Show("An error occurred Please try again later");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath = openFileDialog.FileName;
                pictureBox1.Image = new Bitmap(filepath);
            }
            if (pictureBox1 != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photobyte = ms.ToArray();
                savePhotoToDatabase(photobyte);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "UPDATE [enter] SET [picture]=? WHERE [uname]=?";
            string username = NetVorse.Properties.Settings.Default.userlog.ToString();
            com.Parameters.AddWithValue("@picture", DBNull.Value);

            com.Parameters.AddWithValue("@uname", username);
          
            com.Connection = con;
            int count =(int)com.ExecuteNonQuery();
            if (count == 1)
            {
                MessageBox.Show("Photo Deleted");
                Form2 form2 = new Form2();
                this.Hide();
                con.Close();
                form2.Show();
            }
            else
            {
                MessageBox.Show("An error occurred Please try again later");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are You sure?", "Warning", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                OleDbConnection con = new OleDbConnection();
                con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=logindata.accdb";
                con.Open();
                OleDbCommand com = new OleDbCommand();
                com.CommandText = "delete from [enter] where [uname]=?";
                string username = NetVorse.Properties.Settings.Default.userlog.ToString();
                com.Parameters.AddWithValue("@uname", username);
                com.Connection = con;
                int count = (int)com.ExecuteNonQuery();
                if (count == 1)
                {
                    con.Close();

                    MessageBox.Show("Delete Account was success");
                    NetVorse.Properties.Settings.Default.userlog = null;
                    NetVorse.Properties.Settings.Default.Save();
                    Form1 form1 = new Form1();
                    this.Hide();
                    form1.Show();

                }
                else
                {

                    con.Close();

                    MessageBox.Show("An error occurred Please try again later");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NetVorse.Properties.Settings.Default.logined = false;
            NetVorse.Properties.Settings.Default.Save();
            NetVorse.Properties.Settings.Default.userlog = null;
            NetVorse.Properties.Settings.Default.Save();

            this.Hide();
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }
    }
}
