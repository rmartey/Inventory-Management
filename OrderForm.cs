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
    public partial class OrderForm : Form
    {
        private ArrayList OrderID = new ArrayList();
        private ArrayList ProductBarcode = new ArrayList();
        private ArrayList ProductName = new ArrayList();
        private ArrayList Quantity = new ArrayList();
        private ArrayList Total = new ArrayList();

        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT * FROM inventory_management.orders";
        public OrderForm()
        {
            InitializeComponent();
            LoadProducts();
            if (OrderID.Count > 0)
            {
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Data not found");
            }
        }

        private void dataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
           
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

                //clearing the cached data in the arraylist before updating it with the new order details from the database
                OrderID.Clear();
                ProductBarcode.Clear();
                ProductName.Clear();
                Quantity.Clear();
                Total.Clear();

                while (reader.Read())
                {
                    i++;


                    //updating the list that stores the order details
                    OrderID.Add(reader[0].ToString());
                    ProductBarcode.Add(reader[1].ToString());
                    ProductName.Add(reader[2].ToString());
                    Quantity.Add(reader[3].ToString());
                    Total.Add(reader[4].ToString());


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
            for (int i = 0; i < OrderID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridOrders);
                newRow.Cells[0].Value = (i + 1).ToString();
                newRow.Cells[1].Value = OrderID[i];
                newRow.Cells[2].Value = ProductBarcode[i];
                newRow.Cells[3].Value = ProductName[i];
                newRow.Cells[4].Value = Quantity[i];
                newRow.Cells[5].Value = Total[i];
               
                dataGridOrders.Rows.Add(newRow);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
