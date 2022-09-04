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
    public class Order
    {
        public Order() { }

        public void InsertOrder(string barcode, string productName, int quantity, double totalPrice)
        {
            try
            {
                string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
                MySqlConnection con = new MySqlConnection(cs);
                con.Open();

                string sqlStatement = $"INSERT INTO `orders` (`order_id`, `product_barcode`, `product_name`, `quantity_sold`, `total_price`) VALUES (NULL, '{barcode}', '{productName}', '{quantity}', '{totalPrice}')";
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();

                con.Close();
               // MessageBox.Show("Order successfully placed");

            }
            catch (Exception e)
            {
                Console.WriteLine($"An error occured {e.StackTrace}");
            }
        }

        //TODO: create method to update the quantity of the ordered products

    }
}
