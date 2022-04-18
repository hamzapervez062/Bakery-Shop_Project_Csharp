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
    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
            userrecord();
        }
        private void userrecord()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-0V2H0FE\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("select * from ggh", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            bunifuDataGridView1.DataSource = dt;
        }

        private bool isuserValid()
        {
            if (textidu.Text == string.Empty)
            {
                MessageBox.Show("UserID is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (textnewname.Text == string.Empty)
            {
                MessageBox.Show("UsertName is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textCphn.Text == string.Empty)
            {
                MessageBox.Show("Contact is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textBoxpassword.Text == string.Empty)
            {
                MessageBox.Show("Password is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }

        }
        private void User_Load(object sender, EventArgs e)
        {

        }


        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            if (isuserValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE ggh SET username ='" + textnewname.Text + "', password='" + textBoxpassword.Text + "' , contact = '" + textCphn.Text + "' WHERE (id = '" + textidu.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                userrecord();
                MessageBox.Show("Successfully: Record Updated");
                claer();
            }
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            claer();
        }
        private void claer()
        {
            textBoxpassword.Clear();
            textCphn.Clear();
            textidu.Clear();
            textnewname.Clear();

        }
        private bool isIDvalid()
        {
            if (textidu.Text == string.Empty)
            {
                MessageBox.Show("Please Enter UserID for deletion ", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (isIDvalid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("delete from ggh WHERE (id = '" + textidu.Text + "')", con);
                cmd.ExecuteNonQuery();

                con.Close();
                userrecord();
                MessageBox.Show("Successfully: Record Deleted");
                claer();
            }
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            Home h1 = new Home();
            this.Hide();
            h1.Show();
        }
    }
}
