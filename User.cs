using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public void insertUser(string name, string email, string password, string role)
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


        public void updateUser()
        {
            //establish connection and update the specified user
        }

        public void deleteUser()
        {
            //connect to the database and delete the specified user
        }
    }
}
