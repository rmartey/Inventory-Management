using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventory_Management
{
     public class User
    {
        /*
        private string id;
        private string name;
        private string email;
        private string password;
        private string role;
        */

        public User()
        {
            /*
            this.id = id;
            this.name = name;
            this.email = email;
            this.password = password;
            this.role = role;
            */
        }
        public void InsertUser(string name, string email, string password, string role)
        {
            try {
               
                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                string sqlStatement = $"INSERT INTO users(Name,Email,Role,Password) VALUES ('{name}','{email}','{role}','{password}')";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("User successfully created");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }

        }


        public void UpdateUser(string name, string email, string password, string role)
        {
            //establish connection and update the specified user

            try {
                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();


                //TODO: change the sqlStatement to update the user details
                string sqlStatement = $"UPDATE users SET Name='{name}',Role='{role}',Password='{password}' WHERE Email LIKE '{email}'";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("User successfully updated");

            }
            catch(Exception e) {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }    

           
        }

        public void DeleteUser(string email)
        {
            //connect to the database and delete the specified user
            try
            {
                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change the sqlStatement to the user
                string sqlStatement = $"DELETE FROM users WHERE Email LIKE '{email}'";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("User successfully deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }
    }
}
