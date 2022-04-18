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
using Microsoft.Reporting.WinForms;
namespace Projectshop
{
    public partial class Print : Form
    {
        public Print()
        {
            InitializeComponent();
        }

        private void Print_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void sum()
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from ProductBill_3  WHERE (CustomerID = '" + textBox1.Text + "')", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
        }



        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from ProductBill_3  WHERE (CustomerID = '" + textBox1.Text + "')", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            ReportDataSource rds = new ReportDataSource("DataSet1_Report", dt);
            reportViewer1.LocalReport.ReportPath = @"C:\Users\HaMza Ch\source\repos\Projectshop\Projectshop\Report1.rdlc";
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
            
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            this.Close();
            h1.Show();
        }
    }
}
