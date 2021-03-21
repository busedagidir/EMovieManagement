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
    public partial class admindirectormanagement : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        // add director button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist())
            {
                Response.Write("<script>alert('Director with this ID already exist');</script>");
            }
            else
            {
                AddNewDirector();
            }

        }

        // update director button click event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist())
            {
                UpdateDirector();
            }
            else
            {
                Response.Write("<script>alert('Director does not exist. Add the director');</script>");
            }
        }

        // delete director button click event
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (CheckDirectorExist())
            {
                DeleteDirector();
            }
            else
            {
                Response.Write("<script>alert('Director does not exist.');</script>");
            }
        }

        // go button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetDirectorByID();
        }

        void GetDirectorByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM director_master_tbl WHERE director_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid director ID');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void DeleteDirector()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE from director_master_tbl WHERE director_id='" + TextBox1.Text.Trim() + "'", con);

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Director deleted successfully');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        void UpdateDirector()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("UPDATE director_master_tbl SET director_name=@director_name WHERE director_id='"+ TextBox1.Text.Trim() +"' ", con);

                cmd.Parameters.AddWithValue("@director_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Director updated successfully');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }


        void AddNewDirector()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO director_master_tbl " +
                    "(director_id, director_name) VALUES (@director_id, @director_name)", con);

                cmd.Parameters.AddWithValue("@director_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@director_name", TextBox2.Text.Trim());

                cmd.ExecuteNonQuery();
                con.Close();

                Response.Write("<script>alert('Director added successfully');</script>");
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool CheckDirectorExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM director_master_tbl WHERE director_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }

                con.Close();

                Response.Write("<script>alert('Sign Up successful. Go to User Login to Login');</script>");
                ClearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;
            }
        }


        void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}