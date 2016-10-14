using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment2
{
    public partial class SharpAutoForm : Form
    {
        List<Double> additionalItems = new List<Double>();
        double totalPrice;

        public SharpAutoForm()
        {
            InitializeComponent();
        }

        // Closes application
        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AdditionalItems_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cBox = (CheckBox)sender;
            string property = (string)cBox.Tag;
            double itemPrice = Convert.ToDouble(Program.additionalItem[property].ToString());

            if (cBox.Checked == true)
            {
                additionalItems.Add(itemPrice);
            }
            else
            {
                additionalItems.Remove(itemPrice);
            }

            totalPrice = additionalItems.Sum();
            string totalString = Convert.ToString(totalPrice);
            string formatedTotal = string.Format("{0:0.00}", totalString);

            AdditionalOptionsTextBox.Text = totalPrice.ToString("C2");

        }
    }
}
