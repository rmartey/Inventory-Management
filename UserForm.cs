using Google.Protobuf.Collections;
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
    public partial class UserForm : Form
    {

        //lists to store user details
        private static ArrayList ListName = new ArrayList();
        private static ArrayList ListEmail = new ArrayList();
        private static ArrayList ListRole = new ArrayList();

        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT Name,Email,Role FROM inventory_management.users";
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
            if (ListName.Count > 0)
            {
                updateDatagrid();
            }
            else
            {
                MessageBox.Show("Data not found");
            }
           
        }

        private void DataGridUser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dataGridUser.Columns[e.ColumnIndex].Name;
            if (colName == "Edit")
            {
                UserModuleForm userModule = new UserModuleForm();
                userModule.textFullName.Text = dataGridUser.Rows[e.RowIndex].Cells[1].Value.ToString(); 
                userModule.textEmail.Text = dataGridUser.Rows[e.RowIndex].Cells[2].Value.ToString(); 
                userModule.textRole.Text = dataGridUser.Rows[e.RowIndex].Cells[3].Value.ToString(); 

                userModule.btnSave.Enabled = false;
                userModule.btnUpdate.Enabled = true;
                userModule.textEmail.Enabled = false;
                userModule.ShowDialog();

            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?","Delete Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    User user = new User();
                    user.DeleteUser(dataGridUser.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
            }
        }

        public void LoadUser()
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
                    //dataGridUser.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    //dataGridUser.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    //MessageBox.Show($"{reader[0].ToString()},{reader[1].ToString()},{reader[2].ToString()}");

                    //updating the list that stores the user's details
                    ListName.Add(reader[0].ToString());
                    ListEmail.Add(reader[1].ToString());
                    ListRole.Add(reader[2].ToString());
                }
                reader.Close(); 
                con.Close();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            dataGridUser.Rows.Clear();
        }
        //updating the datagrid containing the user information


        private void updateDatagrid()
        {
            dataGridUser.Rows.Clear();

            for (int i = 0; i < ListName.Count; i++)
            {
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridUser);
                newRow.Cells[0].Value = (i +1).ToString();
                newRow.Cells[1].Value = ListName[i];
                newRow.Cells[2].Value = ListEmail[i];
                newRow.Cells[3].Value = ListRole[i];
                dataGridUser.Rows.Add(newRow);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserModuleForm userModule = new UserModuleForm();
            userModule.btnSave.Enabled = true;
            userModule.btnSave.Enabled = true;
            userModule.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
