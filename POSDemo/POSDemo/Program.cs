using POSDemo.Screens.All_Sales;
using POSDemo.Screens.Customer;
using POSDemo.Screens.Products;
using POSDemo.Screens.Reports;
using POSDemo.Screens.SallsBill;
using POSDemo.Screens.Suppliers;
using POSDemo.Screens.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POSDemo
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
            Application.Run(new  MainForm());
            
        }
    }
}
