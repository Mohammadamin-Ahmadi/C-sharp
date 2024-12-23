using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetVorse
{
    public partial class view : Form
    {

        public void database()
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            //con.Open();

            OleDbCommand com = new OleDbCommand();
            com.CommandText = "select * from [reserv]";

            com.Connection = con;

            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = com;
            da.Fill(dt);
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dt;
        }
        private void savechange()
        {
            //OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder();
            //DataAdapter.Update(dataGridView1);

        }
        public view()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void view_Load(object sender, EventArgs e)
        {

            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            //con.Open();
            
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "select * from [reserv]";
            
            com.Connection = con;
            
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand= com;
            da.Fill(dt);
            dataGridView1.AutoGenerateColumns=true;
            dataGridView1.DataSource = dt;




            // TODO: This line of code loads data into the 'reservationDataSet3.reserv' table. You can move, or remove it, as needed.
            

            // TODO: This line of code loads data into the 'reservationDataSet.reserv' table. You can move, or remove it, as needed.
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
           var qsl= MessageBox.Show("Are you sure?", "Warning", MessageBoxButtons.YesNo);
            if(qsl== DialogResult.Yes)
            {
                if (dataGridView1.SelectedRows.Count > 0) 
                {
                    
                        
                        OleDbConnection con = new OleDbConnection();
                        con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
                        con.Open();
                        OleDbCommand com = new OleDbCommand();
                        com.CommandText = "delete from [reserv] where [ID]=?";

                        com.Parameters.AddWithValue("@ID", dataGridView1.CurrentRow.Cells["ID"].Value );
                        
                        com.Connection = con;
                        com.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Deleted");
                    view view = new view();                    
                    this.Hide();
                    view.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            edit edit = new edit();
            edit.firstname = dataGridView1.CurrentRow.Cells["fname"].Value.ToString();
            edit.lastname = dataGridView1.CurrentRow.Cells["lname"].Value.ToString();
            edit.checkin = dataGridView1.CurrentRow.Cells["cid"].Value.ToString();
            edit.checkout = dataGridView1.CurrentRow.Cells["cod"].Value.ToString();
            edit.address = dataGridView1.CurrentRow.Cells["address"].Value.ToString();
            edit.ID = (int)dataGridView1.CurrentRow.Cells["ID"].Value;
            this.Hide();
            edit.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            enter enter = new enter();
            this.Hide();
            enter.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            add add = new add();    
            this.Hide();
            add.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.ooledb.12.0;Data Source=Reservation.accdb";
            con.Open();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OleDbConnection con = new OleDbConnection();
            con.ConnectionString = "Provider=Microsoft.ace.oledb.12.0;Data Source=Reservation.accdb";
            con.Open();
            OleDbCommand com = new OleDbCommand();
            com.CommandText = "SELECT * FROM [reserv]";
            com.Connection = con;
            DataTable dt = new DataTable();
            OleDbDataAdapter da = new OleDbDataAdapter();
            da.SelectCommand = com;
            da.Fill(dt);
            
            dataGridView1.DataSource = dt;
            OleDbCommandBuilder commandBuilder = new OleDbCommandBuilder(da);
            da.Update(dt);
            con.Close();


        }
    }
}
