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

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

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

        private void button3_Click(object sender, EventArgs e)
        {
            string fullName = textFullName.Text;
            string email = textEmail.Text;
            string role = textRole.Text;
            string password = textPassword.Text;
            //MessageBox.Show($"{fullName},{email},{role},{password}");
            User user = new User(fullName,email,password,role);
            user.createUser();
            MessageBox.Show(user.ToString());
            /*try
            {
                user.createUser();
                //MessageBox.Show("User created successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
             
        }
    }
}
