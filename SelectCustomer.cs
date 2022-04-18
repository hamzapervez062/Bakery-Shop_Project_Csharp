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
    public partial class SelectCustomer : Form
    {
        public SelectCustomer()
        {
            InitializeComponent();
            
        }

        private void SelectCustomer_Load(object sender, EventArgs e)
        {
       
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                SqlCommand cmd = new SqlCommand("select * from Customer_1", con);
                DataTable dt = new DataTable();
                con.Open();
                SqlDataReader sdr = cmd.ExecuteReader();
                dt.Load(sdr);
                con.Close();
                bunifuDataGridView3.DataSource = dt;

                label3.Text = dt.Rows.Count.ToString();
        }

        private void bunifuDataGridView3_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Billing f2 = new Billing();
            f2.textBox5.Text = this.bunifuDataGridView3.CurrentRow.Cells[0].Value.ToString();
            f2.textBox2.Text = this.bunifuDataGridView3.SelectedRows[0].Cells[1].Value.ToString();
            this.Hide();
            f2.Show();
            

        }

        private void bunifuDataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton9_Click(object sender, EventArgs e)
        {
            Billing b2 = new Billing();
            this.Hide();
            b2.Show();
        }

        private void bunifuButton8_Click(object sender, EventArgs e)
        {
            Product b2 = new Product();
            this.Hide();
            b2.Show();
        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            Customer b2 = new Customer();
            this.Hide();
            b2.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Home b2 = new Home();
            this.Hide();
            b2.Show();
        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            this.Hide();
            u1.Show();
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Login b2 = new Login();
            this.Hide();
            b2.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
