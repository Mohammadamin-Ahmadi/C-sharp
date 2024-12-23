using NetVorse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ControlBox=false;
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void profileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void profileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            this.Hide();
            form2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {


           
            
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enetr your First name");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Enter your Last name");
            }
            else if (pictureBox2.Image == null)
            {
                MessageBox.Show("Enter Birth certificate photo");
            }
            else if (pictureBox3.Image == null)
            {
                MessageBox.Show("Enter ID Card photo");
            }
            else if (textBox5.Text == "")
            {
                MessageBox.Show("Enter your Check-in Date");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Enter your Check-out Date");
            }
            else if (textBox6.Text == "")
            {
                MessageBox.Show("Enter your Address");
            }
            else 
            {
                if (checkBox1.Checked) 
                {
                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
                    con.Open();
                    OleDbCommand com = new OleDbCommand();
                    com.CommandText = "INSERT INTO [reserv]([fname],[lname],[cid],[cod],[address]) VALUES(?,?,?,?,?)";
                    com.Parameters.AddWithValue("@fname",textBox1.Text);
                    com.Parameters.AddWithValue("@lname",textBox2.Text);
                    com.Parameters.AddWithValue("@cid",textBox5.Text);
                    com.Parameters.AddWithValue("@cod",textBox3.Text);
                    com.Parameters.AddWithValue("@address",textBox6.Text);
                    com.Connection = con;
                    int count=(int)com.ExecuteNonQuery();
                    if (count == 1)
                    {
                        con.Close();
                        MessageBox.Show("Request is Submite");
                        enter enter = new enter();
                        this.Hide();
                        enter.Show();
                    }
                    else
                    {
                        con.Close();
                        MessageBox.Show("An error occurred Please try again later");
                    }
                }
                else
                {
                    MessageBox.Show("Accept the commitment letter");
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath1 = openFileDialog.FileName;
                pictureBox2.Image = new Bitmap(filepath1);
            }
            if (pictureBox2 != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox2.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photobyte1 = ms.ToArray();
                savePhotoToDatabase1(photobyte1);
            }
        }
        private void savePhotoToDatabase1(byte[] photobyte1)
        {
            //string username=NetVorse.Properties.Settings.Default.userlog;
            
            //OleDbConnection con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            //con.Open();
            //OleDbCommand com = new OleDbCommand();
            //com.CommandText = "UPDATE [reserv] SET [bcpicture]=? WHERE [username]=?";
            //com.Connection = con;
            //com.Parameters.AddWithValue("@bcpicture", photobyte1);
            //com.Parameters.AddWithValue("@username", username);
            

            //int row = (int)com.ExecuteNonQuery();
            //if (row > 0)
            //{
            //    con.Close();
                

               
            //}
            //else
            //{
            //    con.Close();

            //   ;
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filepath2 = openFileDialog.FileName;
                pictureBox3.Image = new Bitmap(filepath2);
            }
            if (pictureBox3 != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox3.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                byte[] photobyte2 = ms.ToArray();
                savePhotoToDatabase2(photobyte2);
            }
        }
        private void savePhotoToDatabase2(byte[] photobyte2)
        {
            //string username = NetVorse.Properties.Settings.Default.userlog;

            //OleDbConnection con = new OleDbConnection();
            //con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            //con.Open();
            //OleDbCommand com = new OleDbCommand();
            //com.CommandText = "update [reserv] set [idpicture]=? where [username]=?";
            //com.Connection = con;
            //com.Parameters.AddWithValue("@idpicture", photobyte2);
            //com.Parameters.AddWithValue("@username", username);
            

            //int row = (int)com.ExecuteNonQuery();
            //if (row > 0)
            //{
            //    con.Close();

            //    ;
            //}
            //else
            //{
            //    con.Close();

               
            //}
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            enter enter = new enter();
            this.Hide();
            enter.Show();
        }
    }
}
