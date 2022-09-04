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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if(activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelMain.Controls.Add(childForm);
            panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void DashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openChildForm(new ProductForm());
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            openChildForm(new UserForm());
        }

        private void btnCategories_Click(object sender, EventArgs e)
        {
            openChildForm(new CategoryForm());
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            openChildForm(new OrderForm());
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to logout?","Confirm",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
            }
        }
    }
}
