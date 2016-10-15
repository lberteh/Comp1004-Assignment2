/*
 * App: Sharp Auto
 * Author: Lucas Schoenardie
 * Student ID: 200322197
 * Created on: 14/10/2016
 * Description: This program calculates the amount due on a New or Used Vehicle
 *              after including Taxes and discounting Trade-in Allowance.           
 */

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
        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            // instantiate an Additionaltem object to make use through my whole application
            additionalItem = new AdditionalItem();            

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SharpAutoForm());
        }
    }
}
