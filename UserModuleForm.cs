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
    public partial class UserModuleForm : Form
    {
        public UserModuleForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void UserModuleForm_Load(object sender, EventArgs e)
        {

        }


        //the close button to close the window
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }


        //checking to show the password or not
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (showPass.Checked == true)
            {
                textPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textPassword.UseSystemPasswordChar = true;
            }
        }


        //the save button to save user details to the database
        private void Button3_Click(object sender, EventArgs e)
        {
            string fullName = textFullName.Text;
            string email = textEmail.Text;
            string role = textRole.Text;
            string password = textPassword.Text;
            //MessageBox.Show($"{fullName},{email},{role},{password}");
            
            try
            {
                if(MessageBox.Show("Are you sure you want to save this user?","Saving User",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //creating a user instance to insert the user details in the database
                    User user = new User();
                    user.InsertUser(fullName, email, password, role);
                    clear();
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }


        //the clear button to clear the input fields
        private void Button1_Click(object sender, EventArgs e)
        {
            clear();
        }


        //method to clear the user input fields
        public void clear()
        {
            textFullName.Text = "";
            textEmail.Text = "";
            textRole.Text = "";
            textPassword.Text = "";
        }

        //the update button to update the user details in the database
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string fullName = textFullName.Text;
            string email = textEmail.Text;
            string role = textRole.Text;
            string password = textPassword.Text;

            try
            {
                if (MessageBox.Show("Are you sure you want to update this user?", "Updating user details", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    //creating a user instance to update the user details in the database
                    User user = new User();
                    user.UpdateUser(fullName, email, password, role);
                    clear();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
