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
    public partial class TransactionHistory : Form
    {
        public TransactionHistory()
        {
            InitializeComponent();
            TransactionRecord();
        }

        private void TransactionHistory_Load(object sender, EventArgs e)
        {
           
                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("select * from Transaction_1", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                bunifuDataGridView1.DataSource = dt;

            
        }

        private void TransactionRecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from Transaction_1", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView1.DataSource = dt;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home hm = new Home();
            this.Hide();
            hm.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            this.Hide();
            u1.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Customer hm = new Customer();
            this.Hide();
            hm.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Product hm = new Product();
            this.Hide();
            hm.Show();
        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Billing hm = new Billing();
           // SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("INSERT INTO Transaction_1 (CustomerID, CustomerName, ProductName, Quantity, Price, Date) VALUES ('" + hm.textBox5.Text + "','" + hm.textBox2.Text + "','" + hm.textBox1.Text + "','" + hm.textBox4.Text + "','" + hm.textBox3.Text + "','" + hm.bunifuDatepicker1.Value.ToString("MM/dd/yyyy") + "')", con);
            //cmd.ExecuteNonQuery();
            //con.Close();

            this.Hide();
            hm.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Login hm = new Login();
            this.Hide();
            hm.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            con.Open();

            SqlCommand cmd = new SqlCommand("truncate table Transaction_1", con);
            cmd.ExecuteNonQuery();
            con.Close();
            TransactionRecord();


        }
    }
}
