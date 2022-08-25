using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }

        public void updateProduct()
        {
            //connect to the database to update the specified product
        }

        public void deleteProduct()
        {
            //connect to the database to delete the product
        }
    }
}
