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
    public partial class edit : Form
    {

        public string firstname { get; set; }
        public string lastname { get; set; }
        public string checkin { get; set; }
        public string checkout { get; set; }
        public string address { get; set; }
        public int ID { get; set; }

        public edit()
        {
            InitializeComponent();
        }

        private void edit_Load(object sender, EventArgs e)
        {
            textBox5.Text= firstname;
            textBox4.Text= lastname;
            textBox3.Text= checkin;
            textBox2.Text= checkout;
            textBox1.Text= address;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            view view = new view();
            this.Hide();
            view.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var qsl = MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if (qsl == DialogResult.Yes)
            {
                
                


                    OleDbConnection con = new OleDbConnection();
                    con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
                    con.Open();
                    OleDbCommand com = new OleDbCommand();
                    com.CommandText = "update [reserv] set [fname]=?,[lname]=?,[cid]=?,[cod]=?,[address]=? where [ID]=?";
                    com.Parameters.AddWithValue("@fname",textBox5.Text);
                    com.Parameters.AddWithValue("@lname",textBox4.Text);
                    com.Parameters.AddWithValue("@cid",textBox3.Text);
                    com.Parameters.AddWithValue("@cod",textBox2.Text);
                    com.Parameters.AddWithValue("@address",textBox1.Text);
                    com.Parameters.AddWithValue("@ID",ID);
                    com.Connection = con;
                    com.ExecuteNonQuery();


                    MessageBox.Show("Regestered");

                    con.Close();
         
                view view = new view();
                this.Hide(); view.Show();
                    








                
            }
        }
    }
}
