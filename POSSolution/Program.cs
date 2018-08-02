using POSSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace POSSolution
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new POSSolution.Controllers.LocalModels.UserController().Search("Salman");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

        }
    }
}
