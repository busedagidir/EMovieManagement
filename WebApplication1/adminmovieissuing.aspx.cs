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
    public partial class adminmovieissuing : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }


        //Go button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetNames();
        }


        //issue button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if(CheckMovieExist() && CheckMemberExist())
            {
                if (CheckIssueExist())
                {
                    Response.Write("<script>alert('This member has already issued this movie');</script>");
                }
                else
                {
                    IssueMovie();
                }

                
            }
            else
            {
                Response.Write("<script>alert('Wrong movie ID or member ID');</script>");
            }
        }


        //return button click event
        protected void Button3_Click(object sender, EventArgs e)
        {
            if (CheckMovieExist() && CheckMemberExist())
            {
                if (CheckIssueExist())
                {
                    ReturnMovie();
                }
                else
                {
                    Response.Write("<script>alert('This entry does not exist');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Wrong movie ID or member ID');</script>");
            }
        }


        void ReturnMovie()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM movie_issue_tbl WHERE movie_id='" + TextBox2.Text.Trim() + "' AND member_id='" + TextBox1.Text.Trim() + "'", con);
                int result = cmd.ExecuteNonQuery();
                

                if(result > 0)
                {
                    cmd = new SqlCommand("UPDATE movie_master_tbl SET current_stock=current_stock+1 WHERE movie_id='"+TextBox2.Text.Trim() +"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Movie returned successfully');</script>");
                    GridView1.DataBind();
                    con.Close();
                }
                else
                {
                    Response.Write("<script>alert('Error - Invalid Details');</script>");
                }
            }
            catch (Exception ex)
            {

            }
        }


        void IssueMovie()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO movie_issue_tbl " +
                    "(member_id, member_name, movie_id, movie_name, issue_date, due_date) VALUES" +
                    "(@member_id, @member_name, @movie_id, @movie_name, @issue_date, @due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_id", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE movie_master_tbl SET current_stock=current_stock-1" +
                    "WHERE movie_id='"+ TextBox3.Text.Trim() + "' " , con);
                cmd.ExecuteNonQuery();

                con.Close();

                    
                ClearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void ClearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
        }


        void GetNames()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT movie_name FROM movie_master_tbl WHERE movie_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["movie_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong movie ID');</script>");
                }


                cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox4.Text = dt.Rows[0]["full_name"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Wrong member ID');</script>");
                }
            }
            catch(Exception ex)
            {

            }

        }


        bool CheckMovieExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM movie_master_tbl WHERE movie_id='" + TextBox2.Text.Trim() + "' AND current_stock > 0", con);
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
            }
            catch(Exception ex)
            {
                return false;
            }
        }


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

                SqlCommand cmd = new SqlCommand("SELECT full_name FROM member_master_tbl WHERE member_id='" + TextBox1.Text.Trim() + "' AND current_stock > 0", con);
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
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        bool CheckIssueExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM movie_issue_tbl WHERE member_id='" + TextBox1.Text.Trim() + "' AND movie_id='"+TextBox2.Text.Trim()+"'", con);
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
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if(today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}