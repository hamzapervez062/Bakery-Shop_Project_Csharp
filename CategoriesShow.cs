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
    public partial class CategoriesShow : Form
    {
        public CategoriesShow()
        {
            InitializeComponent();
            //Biscuit();
        }
        private void Biscuit()
        {
            //string Ct = "Biscuit";
            /*  con.Open();
              SqlDataAdapter sda = new SqlDataAdapter("Select * from Product_1 where Category='" + Ct + "'", con);
              DataTable dt = new DataTable();
              sda.Fill(dt);

              label4.Text = dt.Rows[0][0].ToString();
              con.Close();*/

            //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            //SqlCommand cmd = new SqlCommand("Select * from Product_1 where Category='" + Ct + "'", con);
            //DataTable dt = new DataTable();
           //// con.Open();
           // SqlDataReader sdr = cmd.ExecuteReader();
           // dt.Load(sdr);
           // con.Close();
            //bunifuDataGridView1.DataSource = dt;
        }
        private void CategoriesShow_Load(object sender, EventArgs e)
        {
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();

            this.Hide();
            h1.Show();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
