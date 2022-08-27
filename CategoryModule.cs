using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Inventory_Management
{
    public partial class CategoryModule : Form
    {
        public CategoryModule()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void CategoryModule_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string categoryName = textCategoryName.Text;
            string categoryDescription = textCategoryDescription.Text;
            string categoryID = textCategoryID.Text;

            try
            {
                if (MessageBox.Show("Are you sure you want to update this category?", "Updating user details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //creating a user instance to update the user details in the database
                    Category category= new Category();
                    category.UpdateCategory(categoryID,categoryName, categoryDescription);
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string categoryName = textCategoryName.Text;
            string categoryDescription = textCategoryDescription.Text;

            try
            {
                if (MessageBox.Show("Are you sure you want to save this category?", "Saving User", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //creating a user instance to insert the user details in the database
                    Category category= new Category();
                    category.InsertCategory(categoryName, categoryDescription);
                    Clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Clear()
        {
            textCategoryName.Text = "";
            textCategoryDescription.Text = "";
        }
    }
}
