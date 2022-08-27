using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management
{
    public partial class ProductModuleForm : Form
    {
        public ProductModuleForm()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        //button to save products to the database
        private void btnSave_Click(object sender, EventArgs e)
        {
            string barcode = textBarcode.Text;
            string name = textProductName.Text;
            string description = textDescription.Text;
            int costPrice = int.Parse(textCPrice.Text);
            int sellingPrice = int.Parse(textSPrice.Text);
            int categoryID = int.Parse(textCategoryID.Text);
            int quantity = (int)textQuantity.Value;

            Product product = new Product();
            product.InsertProduct(barcode, name, description, categoryID, quantity, costPrice, sellingPrice);
            Clear();

        }


        //button to update product details in the database
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string barcode = textBarcode.Text;
            string name = textProductName.Text;
            string description = textDescription.Text;
            int costPrice = int.Parse(textCPrice.Text);
            int sellingPrice = int.Parse(textSPrice.Text);
            int categoryID = int.Parse(textCategoryID.Text);
            int quantity = (int)textQuantity.Value;

            Product product = new Product();
            product.UpdateProduct(barcode, name, description, categoryID, quantity, costPrice, sellingPrice);
            Clear();
        }


        //button to clear the product input fields
        private void btnClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            textBarcode.Text = "";
            textProductName.Text = "";
            textDescription.Text = "";
            textCPrice.Text = "";
            textSPrice.Text = "";
            textCategoryID.Text = "";
            textQuantity.Value=0;


        }
    }
}
