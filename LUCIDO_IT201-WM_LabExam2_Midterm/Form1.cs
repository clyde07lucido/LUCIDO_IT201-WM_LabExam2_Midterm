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

        private void price_item_TextValue(string itemname, string price)
        {
            textBox_ItemName.Text = itemname;
            textBox_Price.Text = price;
        }

        private void quantityTextBox()
        {
            textBox_Quantity.Clear();
            textBox_Quantity.Focus();
        }

        private void quantity_price_convert()
        {
            qty = Convert.ToInt32(textBox_Quantity.Text);
            price = Convert.ToDouble(textBox_Price.Text);
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
    }
}
