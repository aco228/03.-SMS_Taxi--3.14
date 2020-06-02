using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SMS_Taxi.Aco;

namespace SMS_Taxi
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            provjera p = new provjera();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new _01_intro());
        }
    }
}
