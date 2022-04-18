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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        private bool isuserValid()
        {
            if (textid.Text == string.Empty)
            {
                MessageBox.Show("UserID is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else if (textnewusername.Text == string.Empty)
            {
                MessageBox.Show("UsertName is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textcontact.Text == string.Empty)
            {
                MessageBox.Show("Contact is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else if (textnewpassword.Text == string.Empty)
            {
                MessageBox.Show("Password is Missing", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            else
            {
                return true;
            }

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {
            if (isuserValid())
            {
                SqlConnection con = new SqlConnection("Data Source=DESKTOP-0V2H0FE\\SQLEXPRESS;Initial Catalog=gg;Integrated Security=True;");
                con.Open();
                //SqlCommand cmd = new SqlCommand("INSERT INTO Signup_1 (UserID, Name, FName, Phone, Password) VALUES ('" + textid.Text + "','" + textnewusername.Text + "','" + textFName.Text + "','" + textcontact.Text + textnewpassword.Text + "')", con);
                SqlCommand cmd = new SqlCommand("INSERT INTO ggh (id, username, password, contact) VALUES ('" + textid.Text + "','" + textnewusername.Text + "','" + textnewpassword.Text + "','" + textcontact.Text + "')", con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("INSERTED");
                con.Close();

            }

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            ResetSignup();

        }
        private void ResetSignup()
        {
            textid.Clear();
            textcontact.Clear();
            textnewpassword.Clear();
            textnewusername.Clear();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
               
             
            
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            Login l1 = new Login();
            this.Hide();
            l1.Show();
        }
    }
}
