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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
        }


        private bool isValid()
        {
            if (textPID.Text == string.Empty)
            {
                MessageBox.Show("ProductID is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (textPname.Text == string.Empty)
            {
                MessageBox.Show("ProductName is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textPQuantity.Text == string.Empty)
            {
                MessageBox.Show("Quantity is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textPprice.Text == string.Empty)
            {
                MessageBox.Show("Price is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }

        }

        private bool isIDvalid()
        {
            if (textPID.Text == string.Empty)
            {
                MessageBox.Show("ProductID is required for deletion ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void GetRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Product_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView1.DataSource = dt;

        }

        public void reset()
        {
            textPID.Clear();
            textPname.Clear();
            textPprice.Clear();
            textPQuantity.Clear();
            categoriesBox.Text = String.Empty;

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Product_1 (ProductID, ProductName, Category, Quantity, Price) VALUES ('" + textPID.Text + "','" + textPname.Text + "','" + categoriesBox.SelectedItem + "','" + textPQuantity.Text + "','" + textPprice.Text+ "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: Record inserted");
                reset();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (isIDvalid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Product_1 WHERE (ProductID = '" + textPID.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: Record Deleted");
                //reset();
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Product_1 SET ProductName ='" + textPname.Text + "', Category='" + categoriesBox.SelectedItem + "' , Quantity = '" + textPQuantity.Text + "' , Price = '" + textPprice.Text + "' WHERE (ProductID = '" + textPID.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: Record Updated");
                reset();
            }
        }

       

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            GetRecord();
        }

        private void bunifuDataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void Product_Load(object sender, EventArgs e)
        {
            GetRecord();
        }

        private void bunifuButton10_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {

            Customer cm = new Customer();
            this.Close();
            cm.Show();
        }

        private void bunifuDataGridView1_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            textPID.Text = bunifuDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textPname.Text = bunifuDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            categoriesBox.Text = bunifuDataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textPQuantity.Text = bunifuDataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textPprice.Text = bunifuDataGridView1.SelectedRows[0].Cells[4].Value.ToString();

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            this.Hide();
            bill.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            this.Hide();
            u1.Show();
        }
    }
}
