using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace Projectshop
{
    public partial class Billing : Form
    {
        public Billing()
        {
            InitializeComponent();
            ProductGetRecord();
            //TransactionRecord();
        }
       /* private void cusGetRecord()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Customer_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView3.DataSource = dt;

        }*/

        private void ProductGetRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Product_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView4.DataSource = dt;

        }
        private void ProductBillRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from ProductBill_3", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView6.DataSource = dt;

        }
        /*private void TransactionRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Transaction_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView5.DataSource = dt;

        }*/

        private bool Isvalid()
        {
            if (textBox4.Text == string.Empty || textBox1.Text == string.Empty || textBox3.Text == string.Empty || textBox7ID.Text == string.Empty)
            {
                MessageBox.Show("Please Fill the Requirements", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                return true;
            }
        }
        private void updateshop()
        {
            int newqty = Convert.ToInt32(bunifuDataGridView4.SelectedRows[0].Cells[3].Value.ToString()) - Convert.ToInt32(textBox4.Text);
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("UPDATE Product_1 SET  Quantity = '" + newqty + "' WHERE (ProductID = '" + textBox7ID.Text + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ProductGetRecord();
           
        }


        private void transa()
        {
             SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO Transaction_1 (CustomerID, CustomerName, ProductName, Quantity, Price, Date) VALUES ('" + textBox5.Text + "','" + textBox2.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + bunifuDatepicker1.Value.ToString("MM/dd/yyyy") + "')", con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

       // int n = 0, Grdtotal = 0;
       //Add to Bill
        private void button1_Click(object sender, EventArgs e)
        {

            if (Isvalid())
            {
                //Quantity Check
                if (textBox4.Text == "" || Convert.ToInt32(textBox4.Text) > Convert.ToInt32(bunifuDataGridView4.SelectedRows[0].Cells[3].Value.ToString()))
                {
                    MessageBox.Show("Not Enough in Shop");
                }
                
                else
                {

                    //Qunatity * Price
                    int total = Convert.ToInt32(textBox4.Text) * Convert.ToInt32(textBox3.Text);
                   
                    SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ProductBill_3 (CustomerID,CustomerName,ProductID, ProductName, Quantity, Price, Date, TotalAmt) VALUES ('" + textBox5.Text + "','" + textBox2.Text + "','" + textBox7ID.Text + "','" + textBox1.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','" + bunifuDatepicker1.Value.ToString("MM/dd/yyyy") + "','" +total + "')", con); ;
                   
                    cmd.ExecuteNonQuery();
                    con.Close();
                    ProductBillRecord();
                    updateshop();
                    MessageBox.Show("Successfully: Record inserted");
                    textBox6.Text = total.ToString();

                    transa();


                    //Total Sales Price
                    int csum = 0;
                    for (int i = 0; i < bunifuDataGridView6.Rows.Count; i++)
                    {
                        csum += Convert.ToInt32(bunifuDataGridView6.Rows[i].Cells[7].Value);
                    }
                    label12.Text = csum.ToString();

                }

            }

        }

        //Reset ProductBill
        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("truncate table ProductBill_3", con);
            cmd.ExecuteNonQuery();
            con.Close();
            ProductBillRecord();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            SelectProduct hm = new SelectProduct();
            this.Hide();
            hm.Show();
        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            Print p = new Print();
            this.Hide();
            p.Show();
        }
        private void bunifuDataGridViewcus(object sender, DataGridViewCellEventArgs e)
        {

        }

       /* private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox5.Text = bunifuDataGridView3.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = bunifuDataGridView3.SelectedRows[0].Cells[1].Value.ToString();
        }*/

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            ProductGetRecord();
        }

        private void bunifuDataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox7ID.Text = bunifuDataGridView4.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = bunifuDataGridView4.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = bunifuDataGridView4.SelectedRows[0].Cells[4].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            textBox7ID.Clear();
            textBox1.Clear();
            textBox3.Clear();
            textBox4.Clear();           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            SelectCustomer hm = new SelectCustomer();
            this.Hide();
            hm.Show();

        }

        private void bunifuDataGridView6_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
           // TransactionRecord();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            TransactionHistory tr = new TransactionHistory();

            this.Hide();
            tr.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home tr = new Home();
            this.Hide();
            tr.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Customer tr = new Customer();
            this.Hide();
            tr.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Product tr = new Product();
            this.Hide();
            tr.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Login tr = new Login();
            this.Hide();
            tr.Show();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuDataGridView1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuDataGridView2(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void textPID_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {

        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView5_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Billing_Load(object sender, EventArgs e)
        {

        }
    }
}
