// RAD-Assignment4, Sergei #200325005, 30-11-2016. 
// This program select product table from Microsoft Azure and put products list to Data Grid,
// user can choose any product, save and read from files
// final form show all data and calculate total cost
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using rad_a4.Modules;

namespace rad_a4
{
    static class Program
    {
        // create product object to store data
        public static product orderedProduct;
        // variable to check if user want to open saved file
        public static bool openFromFile = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // create product object on application start
            orderedProduct = new product();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartForm());
        }
    }
}
