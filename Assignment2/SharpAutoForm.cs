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
        double exteriorFinish = 0;
        double additionalOptionsTotal;
        double basePrice;
        double tradeIn;
        double subTotal;
        double total;

        public SharpAutoForm()
        {
            InitializeComponent();
        }

        // This method adds and removes items to/from the additionalItems List
        private void AdditionalItems_CheckedChanged(object sender, EventArgs e)
        {
            // declaring CheckBox type variable and initializing with sender object
            CheckBox cBox = (CheckBox)sender;

            string property = (string)cBox.Tag; // casts checkBox Tag property value as a string
            // sets itemPrice value acording to corresponding checkBox property from the AdditionalItem class
            double itemPrice = Convert.ToDouble(Program.additionalItem[property].ToString()); 

            // add to list
            if (cBox.Checked == true)
            {
                additionalItems.Add(itemPrice);
            }
            // remove from list
            else
            {
                additionalItems.Remove(itemPrice);
            }

            setAdditionalsTotalPrice(); // method call

        }

        // This method updates additionalTotalPrice value;
        private void ExteriorFinishRadioButtons_CheckedChanged(object sender, EventArgs e)
        {
            // declaring RadioButton type variable and initializing with sender object
            RadioButton rButton = (RadioButton)sender;

            // set exteriorFinish value based on user selection
            if (rButton.Name == "StandardFinishRadioButton")
            {
                exteriorFinish = 0;
            }
            else if (rButton.Name == "PearlizedFinishRadioButton")
            {
                exteriorFinish = 350;
            }
            else if (rButton.Name == "CustomFinishRadioButton")
            {
                exteriorFinish = 700;
            }
            
            setAdditionalsTotalPrice(); // method call
        }

        // This method sets additionalTotalPrice and displays it in AdditionalOptionsTextBox
        private void setAdditionalsTotalPrice()
        {
            additionalOptionsTotal = additionalItems.Sum() + exteriorFinish;
            AdditionalOptionsTextBox.Text = additionalOptionsTotal.ToString("C2");
        }

        // This method validates user input
        private void TextBox_Leave(object sender, EventArgs e)
        {
            // declaring TextBox type variable and initializing with sender object
            TextBox tBox = (TextBox)sender;
            // method scope variables
            string tempString;

            try
            {
                // if user inserted value starting "$", remove the "$"
                if(tBox.Text.Trim().Substring(0,1) == "$")
                {
                    tempString = tBox.Text.Substring(1);
                    // sets basePrice variable value and corresponding textBox text
                    if (tBox.Name == "BasePriceTextBox")
                    {
                        basePrice = Convert.ToDouble(tempString);                    
                        tBox.Text = basePrice.ToString("C2");                            
                    }
                    else if (tBox.Name == "TradeInAllowanceTextBox")
                    {
                        tradeIn = Convert.ToDouble(tempString); 
                        tBox.Text = tradeIn.ToString("C2");
                    }                    
                }
                else
                {
                    // sets basePrice variable value and corresponding textBox text
                    if (tBox.Name == "BasePriceTextBox")
                    {
                        basePrice = Convert.ToDouble(tBox.Text);
                        tBox.Text = basePrice.ToString("C2");
                    }
                    else if (tBox.Name == "TradeInAllowanceTextBox")
                    {
                        tradeIn = Convert.ToDouble(tBox.Text);
                        tBox.Text = tradeIn.ToString("C2");
                    }                    
                }   
                                                 
            }
            // if convert to double fails (user input contains characters other than numbers (decimal places are allowed), display error message
            catch (Exception)
            {
                MessageBox.Show("Please, insert a valid number.");
                tBox.Focus();
                tBox.SelectAll();
            }
            // if negative number, display error message
            finally
            {
                if (tBox.Text.Trim().Substring(0, 1) == "(")
                {
                    MessageBox.Show("Negative values are not allowed! \nPlease, try again.");
                    tBox.Focus();
                    tBox.SelectAll();
                }                    
            }
        }

        // returns subTotal
        private double getSubtotal()
        {
            return basePrice + additionalOptionsTotal;
        }

        // return salesTax
        private double getSalesTax()
        {
            return (subTotal * 1.13) - subTotal;
        }

        // display SalesTax
        private void displaySalesTax()
        {
            SalesTaxTextBox.Text = getSalesTax().ToString("C2");
        }

        // return total
        private double getTotal()
        {
            return total;
        }

        // display total
        private void displayTotal()
        {
            total = getSalesTax() + getSubtotal();
            TotalTextBox.Text = total.ToString("C2");
        }

        // return amount due
        private double getAmountDue()
        {
            return total - tradeIn;
        }

        // display amount due
        private void displayAmountDue()
        {
            AmountDueTextBox.Text = getAmountDue().ToString("C2");
        }

        // calculates and displays subTotal, SalesTax, Total and Amount Due
        private void Calculate(object sender, EventArgs e)
        {
            subTotal = getSubtotal();
            SubTotalTextBox.Text = subTotal.ToString("C2");
            displaySalesTax();
            displayTotal();
            displayAmountDue();
        }

        // clears form
        private void Clear(object sender, EventArgs e)
        {
            // reset textboxes
            foreach (Control tBox in TextBoxesPanel.Controls)
            {
                if (tBox.GetType() == typeof(TextBox))
                {
                    if (tBox.Name == "BasePriceTextBox" ||
                        tBox.Name == "AdditionalOptionsTextBox" ||
                        tBox.Name == "TradeInAllowanceTextBox")
                    {
                        tBox.Text = "$0.00";
                    }
                    else
                    {
                        tBox.Text = "";
                    }
                }
            }
            //foreach (Control cBox in AdditionalItemsGroupBox.Controls)
            //{
            //    if (cBox.GetType() == typeof(CheckBox))
            //    {
            //        cBox.Checked = false;  ***** WHY DOES IT NOT WORK?
            //    }
            //}

            // reset checkboxes
            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;

            // reset defautl radiobutton
            StandardFinishRadioButton.Checked = true;

            // clear additionalItems List
            additionalItems.Clear();

            // reset class variables
            exteriorFinish = 0;
            additionalOptionsTotal = 0;
            basePrice = 0;
            tradeIn = 0;
            subTotal = 0;
            total = 0;

        }

        // Closes application
        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Changes Font
        private void Edit_FontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePriceTextBox.Font = new Font("Arial", 18);
            AmountDueTextBox.Font = new Font("Arial", 18);
        }

        // Changes Color 
        private void Edit_ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePriceTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#03A9F4");
            AmountDueTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#03A9F4");
        }

        // Displays message box with app info
        private void Help_AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";

            message += "This program calculates the amount due on a New or Used Vehicle";
            message += "\nafter including Taxes and discounting Trade-in Allowance! ";

            MessageBox.Show(message, "About");
        }
    }
}
