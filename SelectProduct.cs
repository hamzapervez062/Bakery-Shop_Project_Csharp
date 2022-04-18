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
    public partial class SelectProduct : Form
    {
        public SelectProduct()
        {
            InitializeComponent();
        }

        private void SelectProduct_Load(object sender, EventArgs e)
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

        private void bunifuDataGridView1_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Billing f1 = new Billing();
            f1.textBox7ID.Text = bunifuDataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            f1.textBox1.Text = bunifuDataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            f1.textBox3.Text = bunifuDataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            this.Hide();
            f1.Show();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
