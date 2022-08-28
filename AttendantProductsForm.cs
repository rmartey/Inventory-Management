using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    public partial class AttendantProductsForm : Form
    {
        private static ArrayList Barcode = new ArrayList();
        private static ArrayList ProductName = new ArrayList();
        private static ArrayList ProductDescription = new ArrayList();
        private static ArrayList CategoryID = new ArrayList();
        private static ArrayList Quantity = new ArrayList();
        private static ArrayList SellingPrice = new ArrayList();
        private static ArrayList CostPrice = new ArrayList();

        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT * FROM inventory_management.products";
        public AttendantProductsForm()
        {
            InitializeComponent();
            LoadProducts();
            if (Barcode.Count > 0)
            {
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Data not found");
            }
        }

        public void LoadProducts()
        {
            int i = 0;
            try
            {

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    i++;


                    //updating the list that stores the product details
                    Barcode.Add(reader[0].ToString());
                    ProductName.Add(reader[1].ToString());
                    ProductDescription.Add(reader[2].ToString());
                    CategoryID.Add(reader[3].ToString());
                    Quantity.Add(reader[4].ToString());
                    CostPrice.Add(reader[5].ToString());
                    SellingPrice.Add(reader[6].ToString());


                }
                reader.Close();
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void UpdateDataGrid()
        {
            dataGridProduct.Rows.Clear();

            for (int i = 0; i < Barcode.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridProduct);
                newRow.Cells[0].Value = (i + 1).ToString();
                newRow.Cells[1].Value = Barcode[i];
                newRow.Cells[2].Value = ProductName[i];
                newRow.Cells[3].Value = ProductDescription[i];
                newRow.Cells[4].Value = CategoryID[i];
                newRow.Cells[5].Value = Quantity[i];
                newRow.Cells[6].Value = CostPrice[i];
                newRow.Cells[7].Value = SellingPrice[i];
                dataGridProduct.Rows.Add(newRow);
            }
        }

    }
}
