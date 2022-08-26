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
    public class Product
    {
        /*
        private string barcode;
        private string name;
        private string description;
        private int quantity;
        private string category;
        private int sellingPrice;
        private int costPrice;

        */


        public Product()
        {
           
        }
        
        public void insertProduct(string barcode, string name, string description, string category, int quantity, int costPrice, int sellingPrice)
        {
            //connect to database and insert the product
            try
            {

                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change the sqlStatement to insert into the products table
                //string sqlStatement = $"INSERT INTO users(Name,Email,Role,Password) VALUES ('{name}','{email}','{role}','{password}')";
                //MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                //cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Porduct has been successfully inserted into the database");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }

        public void updateProduct()
        {
            //connect to the database to update the specified product
            try
            {

                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change the sqlStatement to update the product details
                //string sqlStatement = $"INSERT INTO users(Name,Email,Role,Password) VALUES ('{name}','{email}','{role}','{password}')";
                //MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                //cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Product has been successfully updated");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }

        }

        public void deleteProduct()
        {
            //connect to the database to delete the product
            try
            {

                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                //TODO: change sqlStatement to delete the product 
                //string sqlStatement = $"INSERT INTO users(Name,Email,Role,Password) VALUES ('{name}','{email}','{role}','{password}')";
                //MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                //cmd.ExecuteNonQuery();

                con.Close();
                MessageBox.Show("Product has been deleted");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }
    }
}
