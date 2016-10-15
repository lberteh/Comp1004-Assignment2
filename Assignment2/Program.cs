using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public static class Program
    {
        public static AdditionalItem additionalItem;
        public static Value value;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // instantiate an Additionaltem object to make use through my whole application
            additionalItem = new AdditionalItem();
            value = new Assignment2.Value();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SharpAutoForm());
        }
    }
}
