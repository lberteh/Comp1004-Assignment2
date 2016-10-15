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


            setTotalPrice();

        }


        private void ExteriorFinishRadioButtons_CheckedChanged(object sender, EventArgs e)
        {

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

            //set totalPrice and display it in AdditionalOptionsTextBox
            setTotalPrice();
        }

        
        private void setTotalPrice()
        {
            additionalOptionsTotal = additionalItems.Sum() + exteriorFinish;
            AdditionalOptionsTextBox.Text = additionalOptionsTotal.ToString("C2");
        }

        private void TextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //    (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox tBox = (TextBox)sender;
            
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            TextBox tBox = (TextBox)sender;
            string tempString;

            try
            {
                if(tBox.Text.Trim().Substring(0,1) == "$")
                {
                    tempString = tBox.Text.Substring(1);
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
                    // MessageBox.Show("Tirei o $");
                }
                else
                {
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
                    // MessageBox.Show("Não precisei tirar o $");
                }   
                                                 
            }
            catch (Exception)
            {
                MessageBox.Show("Please, insert a valid number.");
                tBox.Focus();
                tBox.SelectAll();
            }
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
        private void displaySalesTax()
        {
            SalesTaxTextBox.Text = getSalesTax().ToString("C2");
        }
        private double getTotal()
        {
            return total;
        }
        private void displayTotal()
        {
            total = getSalesTax() + getSubtotal();
            TotalTextBox.Text = total.ToString("C2");
        }
        private double getAmountDue()
        {
            return total - tradeIn;
        }
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

        private void Clear(object sender, EventArgs e)
        {
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
            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;
            StandardFinishRadioButton.Checked = true;
            additionalItems.Clear();
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

        private void Edit_ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BasePriceTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#03A9F4");
            AmountDueTextBox.ForeColor = System.Drawing.ColorTranslator.FromHtml("#03A9F4");
        }

        private void Help_AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";

            message += "This program calculates the amount due on a New or Used Vehicle";
            message += "\nafter including Taxes and discounting Trade-in Allowance! ";

            MessageBox.Show(message, "About");
        }
    }
}
