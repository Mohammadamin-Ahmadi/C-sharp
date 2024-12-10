using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Help : Form
    {
        public Help()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            this.Hide();
            log.ShowDialog();
        }

        private void Help_Load(object sender, EventArgs e)
        {
            ControlBox=false;
        }
    }
}
