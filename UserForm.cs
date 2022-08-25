using MySql.Data.MySqlClient;
using System;
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
        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT Name,Email,Role FROM inventory_management.users";
        public UserForm()
        {
            InitializeComponent();
            LoadUser();
            /*dataGridUser.Rows.Add(1, "Richmond Martey", "email@email.com", "Admin");
            dataGridUser.Rows.Add(2, "Adusei Benedict", "email1@email.com", "Admin");
            dataGridUser.Rows.Add(3, "Ransmond Martey", "email2@email.com", "Supervisor");
            dataGridUser.Rows.Add(4, "Francis Obeng", "email3@email.com", "Attendant");
            */
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
                userModule.ShowDialog();

            }
            else if(colName == "Delete")
            {
                if(MessageBox.Show("Are you sure you want to delete this user?","Delete Record",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {

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
                    dataGridUser.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    dataGridUser.Rows.Add(i, reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    MessageBox.Show($"{reader[0].ToString()},{reader[1].ToString()},{reader[2].ToString()}");
                }
                reader.Close(); 
                con.Close();
            }catch(Exception e)
            {
                MessageBox.Show(e.Message); 
            }
            dataGridUser.Rows.Clear();
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
