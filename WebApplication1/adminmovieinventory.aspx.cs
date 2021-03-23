using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class adminmovieinventory : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            FillDirectorProducerValues();
            GridView1.DataBind();
        }

        // Add button click event
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (CheckMovieExist())
            {
                Response.Write("<script>alert('Book already exist!');</script>");
            }
            else
            {
                AddNewMovie();
            }
        }


        // Update button click event
        protected void Button3_Click(object sender, EventArgs e)
        {

        }


        // Delete button click event
        protected void Button4_Click(object sender, EventArgs e)
        {

        }


        void FillDirectorProducerValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                    

                SqlCommand cmd = new SqlCommand("SELECT director_name FROM director_master_tbl;", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                DropDownList3.DataSource = dt;
                DropDownList3.DataValueField = "director_name";
                DropDownList3.DataBind();

                cmd = new SqlCommand("SELECT producer_name FROM producer_master_tbl;", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                DropDownList2.DataSource = dt;
                DropDownList2.DataValueField = "producer_name";
                DropDownList2.DataBind();
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

                SqlCommand cmd = new SqlCommand("SELECT * FROM movie_master_tbl WHERE movie_id='" + TextBox2.Text.Trim() + "' OR movie_name='"+TextBox3.Text.Trim() +"'", con);
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
                //ClearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

                return false;
            }
        }


        void AddNewMovie()
        {
            try
            {
                string genres = "";
                foreach (int i in ListBox1.GetSelectedIndices())
                {
                    genres = genres + ListBox1.Items[i] + ",";
                }
                genres = genres.Remove(genres.Length - 1);

                string filepath = "~/movie_inventory/image_part_016";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("movie_inventory/" + filename));
                filepath = "~/movie_inventory/" + filename;

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO movie_master_tbl (movie_id, movie_name, genre, director_name, " +
                    "producer_name, publish_date, language, movie_cost, duration,movie_description,actual_stock,current_stock,movie_img_link)" +
                    "VALUES (@movie_id, @movie_name, @genre, @director_name,@producer_name, @publish_date, @language" +
                    "@movie_cost, @duration,@movie_description,@actual_stock,@current_stock,@movie_img_link)", con);

                cmd.Parameters.AddWithValue("@movie_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);

                cmd.Parameters.AddWithValue("@director_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@producer_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                //cmd.Parameters.AddWithValue("@edition", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_cost", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@duration", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_description", TextBox10.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_img_link", filepath);

                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Movie added successfully');</script>");
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}