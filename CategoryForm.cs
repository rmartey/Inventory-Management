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
    public partial class CategoryForm : Form
    {

        private static ArrayList CategoryID = new ArrayList();
        private static ArrayList CategoryName = new ArrayList();
        private static ArrayList CategoryDescription = new ArrayList();

        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT * FROM inventory_management.category";
        public CategoryForm()
        {
            InitializeComponent();
            LoadCategory();
            if (CategoryID.Count > 0)
            {
                UpdateDataGrid();
            }
            else
            {
                MessageBox.Show("Data not found");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CategoryModule categoryModule = new CategoryModule();
            categoryModule.ShowDialog();
        }


        //function to load the categories from the database to update the arrayLists
        public void LoadCategory()
        {
            int i = 0;

            try
            {
                //dataGridUser.Rows.Clear();

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand(sqlStatement, con);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    i++;

                    //updating the list that stores the user's details
                    CategoryID.Add(reader[0].ToString());
                    CategoryName.Add(reader[1].ToString());
                    CategoryDescription.Add(reader[2].ToString());
                }
                reader.Close();
                con.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }


        //method to update the datagrig with the values in the arraylists
        public void UpdateDataGrid()
        {
            dataGridCategory.Rows.Clear();

            for (int i = 0; i < CategoryID.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridCategory);
                newRow.Cells[0].Value = (i + 1).ToString();
                newRow.Cells[1].Value = CategoryID[i];
                newRow.Cells[2].Value = CategoryName[i];
                newRow.Cells[3].Value = CategoryDescription[i];
                dataGridCategory.Rows.Add(newRow);
            }
        }
    }
}
