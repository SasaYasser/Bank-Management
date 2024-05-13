using DVLD.Login;
using System;
using System.Windows.Forms;

namespace DVLD
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Application.Run(new frmMain());
            // Application.Run(new frmTest2());
            Application.Run(new frmLogin());
            // Application.Run(new frmMain());
        }
    }
}