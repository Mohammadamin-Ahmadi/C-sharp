using NetVorse;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
namespace WindowsFormsApp2
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (NetVorse.Properties.Settings.Default.logined == false)
            {
                Application.Run(new Form1());

            }
            else
            {

                Application.Run(new enter());
            }
        }
    }
}
