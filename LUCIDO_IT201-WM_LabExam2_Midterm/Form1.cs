using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LUCIDO_IT201_WM_LabExam2_Midterm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double price;
        int qty;
        double discount_amt;
        double discounted_amt;

        private void quantityTextBox()
        {
            textBox_Quantity.Clear();
            textBox_Quantity.Focus();
        }

        private void quantity_price_convert()
        {
            if (!int.TryParse(textBox_Quantity.Text, out qty))
                throw new Exception("Invalid quantity");

            price = Convert.ToDouble(textBox_Price.Text.Replace("Php ", ""));
        }

        private void computation_Formula_and_DisplayData()
        {
            discounted_amt = (qty * price) - discount_amt;
            textBox_DiscountAmount.Text = discount_amt.ToString("n");
            textBox_DiscountedAmount.Text = discounted_amt.ToString("n");
        }
        private void price_item_TextValue(string itemname, string price)
        {
            textBox_ItemName.Text = itemname;
            textBox_Price.Text = price;
        }

        private bool ValidateInput()
        {
            if (!int.TryParse(textBox_Quantity.Text, out qty))
            {
                MessageBox.Show("Invalid quantity!");
                return false;
            }

            if (!double.TryParse(textBox_Price.Text.Replace("Php ", ""), out price))
            {
                MessageBox.Show("Invalid price!");
                return false;
            }

            return true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item1.Text, "Php 150.00");
            quantityTextBox();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item2.Text, "Php 200.00");
            quantityTextBox();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item3.Text, "Php 250.00");
            quantityTextBox();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item4.Text, "Php 300.00");
            quantityTextBox();
        }

        private void radioButton_SeniorCitizen_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                quantity_price_convert();
                discount_amt = (qty * price) * 0.30;
                computation_Formula_and_DisplayData();
                radioButton_WithDiscCard.Checked = false;
                radioButton_EmployeeDisc.Checked = false;
                radioButton_NoDisc.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantityTextBox();
            }
        }

        private void radioButton_WithDiscCard_CheckedChanged(object sender, EventArgs e)
        {
            try {
                quantity_price_convert();
                discount_amt = (qty * price) * 0.20;
                computation_Formula_and_DisplayData();
                radioButton_SeniorCitizen.Checked = false;
                radioButton_EmployeeDisc.Checked = false;
                radioButton_NoDisc.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantityTextBox();
            }
        }

        private void radioButton_EmployeeDisc_CheckedChanged(object sender, EventArgs e)
        {
            try {
                quantity_price_convert();
                discount_amt = (qty * price) * 0.10;
                computation_Formula_and_DisplayData();
                radioButton_SeniorCitizen.Checked = false;
                radioButton_WithDiscCard.Checked = false;
                radioButton_NoDisc.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantityTextBox();
            }
        }

        private void radioButton_NoDisc_CheckedChanged(object sender, EventArgs e)
        {
            try 
            {
                quantity_price_convert();
                discount_amt = 0;
                computation_Formula_and_DisplayData();
                radioButton_SeniorCitizen.Checked = false;
                radioButton_WithDiscCard.Checked = false;
                radioButton_EmployeeDisc.Checked = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please enter a valid quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                quantityTextBox();
            }
        }
    }
}
