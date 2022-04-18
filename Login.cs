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
    public partial class Login : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
        public Login()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            this.Hide();
            f2.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand cmd = new SqlCommand("Select Count(*) from ggh where username ='" + textusername.Text + "'and password = '" + textpassword.Text + "'", con);
            DataTable dt = new DataTable();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Home h1 = new Home();
                this.Hide();
                h1.Show();
            }
            else
            {
                MessageBox.Show("UserName and Password is incorrect");

            }
            con.Close();
        }




        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }
        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
        }
        private void bunifuProgressBar1_progressChanged(object sender, EventArgs e)
        {

        }



        //Login Button 2 // Second Method
        private void button1_Click(object sender, EventArgs e)
        {
            User u1 = new User();
           for(int i=0; i < u1.bunifuDataGridView1.Rows.Count-1; i++)
            {
                if (textpassword.Text == u1.bunifuDataGridView1.Rows[i].Cells[2].Value.ToString() && textusername.Text == u1.bunifuDataGridView1.Rows[i].Cells[1].Value.ToString())
                {
                    Home h1 = new Home();
                    this.Hide();
                    h1.Show();

                }
                
              

            }

            
        }
    }
}
