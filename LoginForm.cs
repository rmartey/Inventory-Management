using MySql.Data.MySqlClient;
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
                passText.UseSystemPasswordChar = false;
            }
            else
            {
                passText.UseSystemPasswordChar = true; 
            }
        }

        private void ClearTxt_Click(object sender, EventArgs e)
        {
            emailText.Clear(); 
            passText.Clear();
        }


        //button to sign in
        private void signInButton_Click(object sender, EventArgs e)
        {
            Login();
        }


        //a method to handle the logging in of a user (Admin or Attendant)
        public void Login()
        {
            string email = emailText.Text;
            string password = passText.Text;

            string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
            


            try
            {

                //user details from the database
                string userEmail = "";
                string userPassword = "";
                string role = "";

                string sqlStatement = $"SELECT * FROM inventory_management.users WHERE Email like '{email}'";

                //connect to the database 
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                
                while (reader.Read())
                {
                    userEmail = reader[1].ToString();
                    userPassword = reader[3].ToString();
                    role = reader[2].ToString();
                }

                

                reader.Close();
                con.Close();    
                if(email == userEmail && password == userPassword)
                {
                    //check if the role in the database is an admin
                    if(role == "Administrator")
                    {
                        this.Hide();
                        MainForm mainForm = new MainForm();
                        mainForm.ShowDialog();
                    }
                    //or if its an attendant
                    else if(role == "Attendant")
                    {
                        this.Hide();
                        AttendantMainForm attendantForm = new AttendantMainForm();
                        attendantForm.ShowDialog(); 
                    }
                }
               
            }
            catch(Exception e)
            {
                MessageBox.Show($"{e.StackTrace}","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            
        }
    }
}
