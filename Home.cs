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
    public partial class Home : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
        public Home()
        {
            InitializeComponent();
            countcake();
            countBread();
            countBiscuits();
            countPastries();
        }

        
        private void countcake()
        {
            string Ct = "Cake";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Product_1 where Category='"+Ct+"'",con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label2.Text = dt.Rows[0][0].ToString();
            con.Close();
            

        }
        private void countPastries()
        {
            string Ct = "Pasteries";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label3.Text = dt.Rows[0][0].ToString();
            con.Close();


        }
        private void countBread()
        {
            string Ct = "Bread";
            con.Open();
            SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            label5.Text = dt.Rows[0][0].ToString();
            con.Close();


        }
        private void countBiscuits()
        {
            
            CategoriesShow h1 = new CategoriesShow();
            string Ct = "Biscuit";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            h1.bunifuDataGridView1.DataSource = dt;
            int a = h1.bunifuDataGridView1.Rows.Count - 1;
            label4.Text =a.ToString();


        }



        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Customer cm = new Customer();
            this.Hide();
            cm.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Product pd = new Product();
            this.Hide();
            pd.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void Home_Load(object sender, EventArgs e)
        {
            
        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Billing bill = new Billing();
            this.Hide();
            bill.Show();
        }

        private void bunifuImageButton1_Click_1(object sender, EventArgs e)
        {
            CategoriesShow h1 = new CategoriesShow();
            string Ct = "Biscuit";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            h1.bunifuDataGridView1.DataSource = dt;
            //label4.Text =h1.bunifuDataGridView1.RowCount.ToString();
            this.Hide();
            h1.Show();

        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            CategoriesShow h1 = new CategoriesShow();
            string Ct = "Pasteries";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            h1.bunifuDataGridView1.DataSource = dt;
            this.Hide();
            h1.Show();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            CategoriesShow h1 = new CategoriesShow();
            string Ct = "Bread";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            h1.bunifuDataGridView1.DataSource = dt;
            this.Hide();
            h1.Show();
        }

        private void bunifuImageButton2_DoubleClick(object sender, EventArgs e)
        {
            CategoriesShow h1 = new CategoriesShow();
            string Ct = "Cake";

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            h1.bunifuDataGridView1.DataSource = dt;
            this.Hide();
            h1.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            this.Hide();
            u1.Show();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            TransactionHistory tr = new TransactionHistory();

            this.Hide();
            tr.Show();
        }

        private void bunifuButton1_Click_1(object sender, EventArgs e)
        {
            Home h1 = new Home();
            this.Hide();
            h1.Show();
        }
    }
}
