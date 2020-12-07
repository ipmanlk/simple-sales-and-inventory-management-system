using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using sales_and_inventory.Controller;

namespace sales_and_inventory
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form loginForm = new View.Login();
            AuthController.loginForm = loginForm;
            Application.Run(loginForm);
        }
    }
}
