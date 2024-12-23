using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetVorse
{
    public partial class add : Form
    {
        public add()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view view = new view();
            this.Hide();
            view.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "insert into [reserv]([fname],[lname],[cid],[cod],[address]) values(?,?,?,?,?)";
            com.Parameters.AddWithValue("@fname",textBox5.Text);
            com.Parameters.AddWithValue("@lname",textBox4.Text);
            com.Parameters.AddWithValue("@cid",textBox3.Text);
            com.Parameters.AddWithValue("@cod",textBox2.Text);
            com.Parameters.AddWithValue("@address",textBox1.Text);
            com.Connection = con;
            com.ExecuteNonQuery();


            MessageBox.Show("Added");

            con.Close();
            view view = new view();
            this.Hide(); view.Show();
            
        }
    }
}
