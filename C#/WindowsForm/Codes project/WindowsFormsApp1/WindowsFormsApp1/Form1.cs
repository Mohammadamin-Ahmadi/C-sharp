using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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


        private void حالاکهاصرارداریبیاToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

        }

        private void mnuHelpExit2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("من میدونستم تو دیگه دوستم نداری برو دیگه برنگرد");

        }

        private void حالاکهاصرارداریبیاToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("سلام" + " " + textBox1.Text + "به برنامه خوش اومدی");
        }
    }
}
