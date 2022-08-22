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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxPass.Checked == true)
            {
                PassText.UseSystemPasswordChar = false;
            }
            else
            {
                PassText.UseSystemPasswordChar = true; 
            }
        }

        private void ClearTxt_Click(object sender, EventArgs e)
        {
            EmailText.Clear(); 
            PassText.Clear();
        }
    }
}
