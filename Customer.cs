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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }


        private bool isValid()
        {
            if (textcusid.Text == string.Empty)
            {
                MessageBox.Show("ID is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (textCusName.Text == string.Empty)
            {
                MessageBox.Show("CustomerName is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textCusPhn.Text == string.Empty)
            {
                MessageBox.Show("Customer Contact is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textCusAddress.Text == string.Empty)
            {
                MessageBox.Show("CustomerAddress is required", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }

        }

        private bool isIDvalid()
        {
            if (textcusid.Text == string.Empty)
            {
                MessageBox.Show("CustomerID is required for deletion ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void GetRecord()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Customer_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView2.DataSource = dt;

        }

        public void reset()
        {
            textcusid.Clear();
            textCusName.Clear();
            textCusPhn.Clear();
            textCusAddress.Clear();
         
        }


        private void Customer_Load(object sender, EventArgs e)
        {
            GetRecord();

        }

      
       

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Customer_1 (CusID, CusName, CusPhone, CusAddress) VALUES ('" + textcusid.Text + "','" + textCusName.Text + "','" + textCusPhn.Text.ToString() + "','" + textCusAddress.Text + "')", con);
                cmd.ExecuteNonQuery();
                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: CUSTOMER Record inserted");
                reset();
            }
        }

        

        private void bunifuDataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textcusid.Text = bunifuDataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            textCusName.Text = bunifuDataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            textCusPhn.Text = bunifuDataGridView2.SelectedRows[0].Cells[2].Value.ToString();
            textCusAddress.Text = bunifuDataGridView2.SelectedRows[0].Cells[3].Value.ToString();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            reset();

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (isIDvalid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from Customer_1 WHERE (CusID = '" + textcusid.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: Customer Record Deleted");
                //reset();
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Customer_1 SET CusName ='" + textCusName.Text + "', CusPhone='" + textCusPhn.Text.ToString() + "' , CusAddress = '" + textCusAddress.Text + "' WHERE (CusID = '" + textcusid.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                GetRecord();
                MessageBox.Show("Successfully: Record Updated");
                reset();
            }
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            this.Hide();
            u1.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Customer cm = new Customer();
            this.Close();
            cm.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Product pd = new Product();
            this.Close();
            pd.Show();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            this.Hide();
            bill.Show();
        }
    }
}
