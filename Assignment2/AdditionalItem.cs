using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assignment2
{
    public class AdditionalItem
    {
        public object this[string propertyName]
        {
            get { return this.GetType().GetProperty(propertyName).GetValue(this, null); }
            set { this.GetType().GetProperty(propertyName).SetValue(this, value, null); }
        }

        public double StereoSystem { get; set; } = 200.00;
        public double LeatherInterior { get; set; } = 800.00;
        public double ComputerNavigation { get; set; } = 500.00;

        //public double getValue(string property)
        //{
        //    if (property == "StereoSystem")
        //        return StereoSystem;
        //    else if (property == "LeatherInterior")
        //        return 800;
        //    else if (property == "ComputerNavigation")
        //        return 500;
        //    else
        //        return 0;
        //}

    }
}