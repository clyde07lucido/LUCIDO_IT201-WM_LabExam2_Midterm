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

        int totalQty = 0;
        double totalDiscount = 0;
        double totalDiscounted = 0;
        double cash = 0;
        double change = 0;

        private void quantityTextBox()
        {
            textBox_Quantity.Clear();
            textBox_Quantity.Focus();
        }

        private bool quantity_price_convert()
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

        private void computation_Formula_and_DisplayData()
        {
            double gross = qty * price;
            discounted_amt = gross - discount_amt;

            textBox_DiscountAmount.Text = discount_amt.ToString("n2");
            textBox_DiscountedAmount.Text = discounted_amt.ToString("n2");
        }

        private void price_item_TextValue(string itemname, string price)
        {
            textBox_ItemName.Text = itemname;
            textBox_Price.Text = price;
        }

        private void ComputeTotals()
        {
            totalQty += qty;
            totalDiscount += discount_amt;
            totalDiscounted += discounted_amt;

            textBox_TotalQuantity.Text = totalQty.ToString();
            textBox_TotalDiscountGiven.Text = totalDiscount.ToString("n2");
            textBox_TotalDiscountedGiven.Text = totalDiscounted.ToString("n2");
        }

        private void ComputeChange()
        {
            if (!double.TryParse(textBox_CashRendered.Text, out cash))
            {
                MessageBox.Show("Invalid cash amount!");
                return;
            }

            change = cash - totalDiscounted;
            textBox_Change.Text = change.ToString("n2");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item1.Text, "Php 150.00");
            quantityTextBox();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item3.Text, "Php 250.00");
            quantityTextBox();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item2.Text, "Php 200.00");
            quantityTextBox();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            price_item_TextValue(lbl_item4.Text, "Php 300.00");
            quantityTextBox();
        }

        private void radioButton_SeniorCitizen_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_SeniorCitizen.Checked) return;
            if (!quantity_price_convert()) return;

            discount_amt = (qty * price) * 0.30;
            computation_Formula_and_DisplayData();
        }

        private void radioButton_WithDiscCard_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_WithDiscCard.Checked) return;
            if (!quantity_price_convert()) return;

            discount_amt = (qty * price) * 0.20;
            computation_Formula_and_DisplayData();
        }

        private void radioButton_EmployeeDisc_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_EmployeeDisc.Checked) return;
            if (!quantity_price_convert()) return;

            discount_amt = (qty * price) * 0.10;
            computation_Formula_and_DisplayData();
        }

        private void radioButton_NoDisc_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioButton_NoDisc.Checked) return;
            if (!quantity_price_convert()) return;

            discount_amt = 0;
            computation_Formula_and_DisplayData();
        }

        private void button_New_Click(object sender, EventArgs e)
        {
            textBox_ItemName.Clear();
            textBox_Price.Clear();
            textBox_Quantity.Clear();
            textBox_DiscountAmount.Clear();
            textBox_DiscountedAmount.Clear();
            textBox_CashRendered.Clear();
            textBox_Change.Clear();
            textBox_TotalQuantity.Clear();
            textBox_TotalDiscountGiven.Clear();
            textBox_TotalDiscountedGiven.Clear();

            totalQty = 0;
            totalDiscount = 0;
            totalDiscounted = 0;
            cash = 0;
            change = 0;

            discount_amt = 0;
            discounted_amt = 0;
            qty = 0;
            price = 0;

            radioButton_SeniorCitizen.Checked = false;
            radioButton_WithDiscCard.Checked = false;
            radioButton_EmployeeDisc.Checked = false;
            radioButton_NoDisc.Checked = false;

            textBox_Quantity.Focus();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            textBox_ItemName.Clear();
            textBox_Price.Clear();
            textBox_Quantity.Clear();
            textBox_DiscountAmount.Clear();
            textBox_DiscountedAmount.Clear();

            discount_amt = 0;
            discounted_amt = 0;
            qty = 0;
            price = 0;

            radioButton_SeniorCitizen.Checked = false;
            radioButton_WithDiscCard.Checked = false;
            radioButton_EmployeeDisc.Checked = false;
            radioButton_NoDisc.Checked = false;

            textBox_Quantity.Focus();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button_Calculate_Click(object sender, EventArgs e)
        {
            if (discounted_amt == 0 && discount_amt == 0)
            {
                MessageBox.Show("Please select discount and enter quantity first!");
                return;
            }

            ComputeTotals();
            ComputeChange();
        }
    }
}
