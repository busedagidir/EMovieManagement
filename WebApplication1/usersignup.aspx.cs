using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    

    public partial class usersignup : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        // Sign Up Button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (CheckMemberExist())
            {
                Response.Write("<script>alert('Member ID is already taken!');</script>");
            }
            else
            {
                SignUpNewMember();
            }
        }


        //users for sign up first time
        void SignUpNewMember()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO member_master_tbl " +
                    "(full_name, dob, contact_no, email, state, city, zipcode, full_address, member_id, password, account_status)" +
                    "values (@full_name, @dob, @contact_no, @email, @state, @city, @zipcode, @full_address, @member_id, @password, @account_status)", con);

                cmd.Parameters.AddWithValue("@full_name", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@email", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@state", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@zipcode", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@password", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Sign Up successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        //check for same member id
        bool CheckMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+ TextBox5.Text.Trim() +"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if(dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();

                Response.Write("<script>alert('Sign Up successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}