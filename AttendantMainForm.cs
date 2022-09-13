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
    public partial class AttendantMainForm : Form
    {
        double total = 0.00;

        //for the datagride
        private static ArrayList Barcode = new ArrayList();
        private static ArrayList ProductName = new ArrayList();
        private static ArrayList ProductDescription = new ArrayList();
        private static ArrayList CategoryID = new ArrayList();
        private static ArrayList Quantity = new ArrayList();
        private static ArrayList SellingPrice = new ArrayList();


        //tobe displayed on the receipt
        private static ArrayList PName = new ArrayList();
        private static ArrayList PQuantity = new ArrayList();
        private static ArrayList PTotal = new ArrayList();


        string cs = "server=localhost;uid=root;pwd=;database=inventory_management";
        string sqlStatement = "SELECT * FROM products WHERE barcode LIKE '{barcode}'";




        public AttendantMainForm()
        {
            InitializeComponent();
            ShowDate();
            
            //textDate.Text = DateTime.Now.ToString("hh:mm:ss");
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelHeader_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnOrders_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnProducts_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
                LoginForm loginForm = new LoginForm();
                loginForm.ShowDialog();
               
            }        
           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        public void AddToCart(string barcode, int quantity)
        {
            
            int i = 0;
            try
            {

                MySqlConnection con = new MySqlConnection(cs);
                con.Open();
                MySqlCommand cmd = new MySqlCommand($"SELECT * FROM products WHERE barcode LIKE '{barcode}'", con);
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    //the value of the quantity in the database in reader[4]
                    //the unit price of each product is given by the reader[5]


                    //i++;
                    //updating the list that stores the product details

                    
                    Barcode.Add(reader[0].ToString());
                    ProductName.Add(reader[1].ToString());
                    ProductDescription.Add(reader[2].ToString());
                    CategoryID.Add(reader[3].ToString());
                    Quantity.Add(quantity);
                    SellingPrice.Add((double)reader[6] * quantity);
                    
                    //MessageBox.Show($"{reader[0].ToString()},{reader[1].ToString()} ,{reader[2].ToString()}, {reader[3].ToString()} , {reader[6].ToString()}");

                }
                reader.Close();
                con.Close();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            UpdateCartDataGrid();
        }

        public void UpdateCartDataGrid()
        {
            dataGridCart.Rows.Clear();

            for (int i = 0; i < Barcode.Count; i++)
            {
                
                DataGridViewRow newRow = new DataGridViewRow();

                newRow.CreateCells(dataGridCart);
                newRow.Cells[0].Value = (i + 1).ToString();
                newRow.Cells[1].Value = Barcode[i];
                newRow.Cells[2].Value = ProductName[i];
                newRow.Cells[3].Value = ProductDescription[i];
                newRow.Cells[4].Value = CategoryID[i];
                newRow.Cells[5].Value = Quantity[i];
                newRow.Cells[6].Value = SellingPrice[i];
                dataGridCart.Rows.Add(newRow);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string barcode = textBarcode.Text;
            int quantity = (int)textQuantity.Value;
            AddToCart(barcode, quantity);
            Clear();
            GetTotal();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        public void Clear()
        {
            textQuantity.Value = 0;
            textBarcode.Text = "";

        }

        private void ShowDate()
        {
            textDate.Text = DateTime.Now.ToString("hh:mm:ss");
            textDate.Update();
        }


        //button to show the attendant's products form
        private void btnProducts_Click_1(object sender, EventArgs e)
        {
            AttendantProductsForm attendantProductsForm = new AttendantProductsForm();
            attendantProductsForm.ShowDialog();
        }

        private void btnOrders_Click_1(object sender, EventArgs e)
        {
            OrderForm orderForm = new OrderForm();
            orderForm.FormBorderStyle = FormBorderStyle.Fixed3D;
            orderForm.ShowDialog();

        }

        public void GetTotal()
        {
            total = 0;
            for(int i = 0; i < dataGridCart.Rows.Count; i++)
            {
                string v = dataGridCart.Rows[i].Cells[6].Value.ToString();
                total += double.Parse(v);
                
            }
            textPrice.Text = total.ToString();

        }


        //button to complete the order and send it to the database
        private void button3_Click(object sender, EventArgs e)
        {
            //a loop to loop through the rows in the datagride and insert each row into the database
            for(int i =0;i < dataGridCart.Rows.Count; i++)
            {
                string barcode = dataGridCart.Rows[i].Cells[1].Value.ToString();
                string productName = dataGridCart.Rows[i].Cells[2].Value.ToString();
                int quantity = int.Parse(dataGridCart.Rows[i].Cells[5].Value.ToString());
                var totalPrice = double.Parse(dataGridCart.Rows[i].Cells[6].Value.ToString());

                //MessageBox.Show($"{barcode}, {productName}, {quantity}, {totalPrice}");

                Order order = new Order();
                order.InsertOrder(barcode, productName, quantity, totalPrice);


                //adding to the arraylist
                PName.Add(productName.ToString());
                PQuantity.Add(quantity);   
                PTotal.Add(totalPrice);
                
            }

            //MessageBox.Show("Order successfully placed","Order",MessageBoxButtons.OK,MessageBoxIcon.Information);

            //clearing the rows after inserting into the database
            dataGridCart.Rows.Clear();
            Print();

        }

        public void ClearCart()
        {
            dataGridCart.Rows.Clear();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            double totalAmount = 0;
            //TODO: design the receipt here
            e.Graphics.DrawString("*********************************************************************************", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(100, 50));
            e.Graphics.DrawString("Welcome to Shoprite", new Font("Arial", 24, FontStyle.Regular), Brushes.Red, new Point(250, 70));
            e.Graphics.DrawString("Receipt", new Font("Arial", 24, FontStyle.Regular), Brushes.Red, new Point(340, 100));
            e.Graphics.DrawString("*********************************************************************************", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(100, 150));


            e.Graphics.DrawString("Product", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(150, 190));
            e.Graphics.DrawString("Quantity", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(350, 190));
            e.Graphics.DrawString("Price", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(500, 190));
            e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Regular), Brushes.Red, new Point(100, 220));


            int yPos = 240;
            for(int i = 0; i < PName.Count; i++)
            {
                string productName = PName[i].ToString();
                int quantity = int.Parse(PQuantity[i].ToString());
                var totalPrice = double.Parse(PTotal[i].ToString());
                e.Graphics.DrawString($"{productName}", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(150, yPos));
                e.Graphics.DrawString($"{quantity}", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(350, yPos));
                e.Graphics.DrawString($"{totalPrice}", new Font("Arial", 18, FontStyle.Regular), Brushes.Black, new Point(500, yPos));
                totalAmount += totalPrice;
                yPos += 50;
            }


            e.Graphics.DrawString("----------------------------------------------------------------------------------------------", new Font("Arial", 14, FontStyle.Regular), Brushes.Red, new Point(100, yPos));
            e.Graphics.DrawString("TOTAL AMOUNT", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(100, yPos + 50));
            e.Graphics.DrawString($"GHC {totalAmount.ToString()}.00", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(600, yPos+50));

            e.Graphics.DrawString("**************************", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(340, yPos+130));
            e.Graphics.DrawString("THANK YOU", new Font("Arial", 24, FontStyle.Regular), Brushes.Black, new Point(340, yPos + 150));
            e.Graphics.DrawString("**************************", new Font("Arial", 14, FontStyle.Regular), Brushes.Black, new Point(340, yPos + 190));

        }


        public void Print()
        {
            dataGridCart.Rows.Clear();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }
    }
}
