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
using System.Configuration;

namespace Win_Crud
{
    public partial class Register : Form
    {
        string constr = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;
        string Gender;
        public Register()
        {
            InitializeComponent();
        }

        private void btn_register_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            SqlCommand cmd = new SqlCommand("sp_register", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("Name", txt_name.Text);
            cmd.Parameters.AddWithValue("Email", txt_email.Text);
            cmd.Parameters.AddWithValue("Mobile", txt_mobile.Text);
            cmd.Parameters.AddWithValue("Gender", Gender);
            cmd.Parameters.AddWithValue("Username", txt_username.Text);
            cmd.Parameters.AddWithValue("Password", txt_password.Text);
            int i = cmd.ExecuteNonQuery();
            if (i > 0)
            {
                MessageBox.Show("User Registered Successfully");
            }
            else
            {
                MessageBox.Show("User Registeration Failed");
            }
            con.Close();
        }

        private void rb_male_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void rb_female_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
