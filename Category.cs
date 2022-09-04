using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Inventory_Management
{
    public class Category
    {
        public Category()
        {

        }

        public void InsertCategory(string name, string description)
        {
            //connect to the database and insert the category into the database
            try
            {
                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();


                //TODO: change the sqlStatement to insert a product category
                string sqlStatement = $"INSERT INTO category('category_name','category_description') VALUES ('{name}','{description}')";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Category has been successfully inserted into the database");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }

        public void UpdateCategory(string id, string name, string description)
        {
            //establish connection and update the category details

            try
            {

                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change the sqlStatement to update the category details
                string sqlStatement = $"UPDATE `category` SET `category name` = '{name}','category description'='{description}' WHERE `category`.`category id` = {id}";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Category successfully updated");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }

        public void DeleteCategory(string id)
        {
            //connect to the database and delete the category

            try
            {

                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change the sqlStatement to delete the product category
                string sqlStatement = $"DELETE FROM category WHERE `category`.`category id` = {id}";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Product category has been successfully deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }
    }
}
