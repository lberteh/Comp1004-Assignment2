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
using System.Text;

namespace Assignment2
{
    public class AdditionalItem
    {
        // class properties
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public double StereoSystem { get; set; } = 200.00;
        public double LeatherInterior { get; set; } = 800.00;
        public double ComputerNavigation { get; set; } = 500.00;

     
    }
}