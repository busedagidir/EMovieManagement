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
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_movies;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDirectorProducerValues();
            }
            GridView1.DataBind();
        }

        //go button click event
        protected void Button1_Click(object sender, EventArgs e)
        {
            GetMovieByID();
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
            UpdateMovieByID();
        }


        // Delete button click event
        protected void Button4_Click(object sender, EventArgs e)
        {
            DeleteMovieByID();
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

        // fonk duzgun CALISIYOR. :)
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
                    "producer_name, publish_date, language, edition, movie_cost, duration,movie_description,actual_stock,current_stock,movie_img_link)" +
                    "VALUES (@movie_id, @movie_name, @genre, @director_name,@producer_name, @publish_date, @language, @edition," +
                    "@movie_cost, @duration,@movie_description,@actual_stock,@current_stock,@movie_img_link)", con);

                cmd.Parameters.AddWithValue("@movie_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@movie_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genres);

                cmd.Parameters.AddWithValue("@director_name", DropDownList3.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@producer_name", DropDownList2.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);  
                cmd.Parameters.AddWithValue("@edition", TextBox7.Text.Trim());              //Year text box
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

        void GetMovieByID()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM movie_master_tbl WHERE movie_id='"+TextBox2.Text.Trim()+"';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
                {
                    TextBox3.Text = dt.Rows[0]["movie_name"].ToString();
                    TextBox6.Text = dt.Rows[0]["publish_date"].ToString();
                    TextBox7.Text = dt.Rows[0]["year"].ToString();
                    TextBox8.Text = dt.Rows[0]["movie_cost"].ToString().Trim();
                    TextBox9.Text = dt.Rows[0]["duration"].ToString().Trim();
                    TextBox1.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    TextBox4.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    TextBox10.Text = dt.Rows[0]["movie_description"].ToString();
                    TextBox5.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    DropDownList1.SelectedValue = dt.Rows[0]["language"].ToString().Trim();
                    DropDownList2.SelectedValue = dt.Rows[0]["producer_name"].ToString().Trim();
                    DropDownList3.SelectedValue = dt.Rows[0]["director_name"].ToString().Trim();

                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');

                    ListBox1.ClearSelection();
                    for(int i=0; i<genre.Length; i++)
                    {
                        for(int j = 0; j<ListBox1.Items.Count; j++)
                        {
                            if(ListBox1.Items[j].ToString() == genre[i])
                            {
                                ListBox1.Items[j].Selected = true;
                            }
                        }
                    }

                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_movies = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["movie_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid movie id');</script>");
                }

            }
            catch (Exception ex)
            {

            }
        }


        void UpdateMovieByID()
        {
            if (CheckMovieExist())
            {
                try
                {

                    int actual_stock = Convert.ToInt32(TextBox1.Text.Trim());
                    int current_stock = Convert.ToInt32(TextBox4.Text.Trim());

                    if(global_actual_stock == actual_stock)
                    {

                    }
                    else
                    {
                        if(actual_stock < global_issued_movies)
                        {
                            Response.Write("<script>alert('Actual Stock value cannot be less than the issued movies');</script>");
                            return;
                        }
                        else
                        {
                            current_stock = actual_stock - global_issued_movies;
                            TextBox4.Text = "" + current_stock;
                        }
                    }

                    string genres = "";
                    foreach (int i in ListBox1.GetSelectedIndices())
                    {
                        genres = genres + ListBox1.Items[i] + ",";
                    }
                    genres = genres.Remove(genres.Length - 1);

                    string filepath = "~/movie_inventory/image_part_016";
                    string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                    if(filename == "" || filename == null)
                    {
                        filepath = global_filepath;
                    }
                    else
                    {
                        FileUpload1.SaveAs(Server.MapPath("movie_inventory/" + filename));
                        filepath = "~/movie_inventory/" + filename;
                    }

                    SqlConnection con = new SqlConnection(strcon);

                    //check connection is open with the database
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("UPDATE movie_master_tbl SET movie_name=@movie_name," +
                        "genre=@genre, director_name=@director_name, producer_name=@producer_name, language=@language," +
                        "edition=@edition, movie_cost=@movie_cost, duration=@duration, movie_description=@movie_description," +
                        "actual_stock=@actual_stock, current_stock=@current_stock, movie_img_link=@movie_img_link" +
                        "WHERE movie_id='"+TextBox2.Text.Trim()+"' ", con);

                    cmd.Parameters.AddWithValue("@movie_name", TextBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@genre", genres);
                    cmd.Parameters.AddWithValue("@director_name", DropDownList3.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@producer_name", DropDownList2.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@edition", TextBox7.Text.Trim());
                    cmd.Parameters.AddWithValue("@movie_cost", TextBox8.Text.Trim());
                    cmd.Parameters.AddWithValue("@duration", TextBox9.Text.Trim());
                    cmd.Parameters.AddWithValue("@movie_description", TextBox10.Text.Trim());
                    cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
                    cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
                    cmd.Parameters.AddWithValue("@movie_img_link", filepath);



                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    Response.Write("<script>alert('Movie updated successfully');</script>");
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    //Response.Write("<script>alert('olmadı');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Movie ID');</script>");
            }
        }

        void DeleteMovieByID()
        {
            if (CheckMovieExist())
            {


                try
                {
                    SqlConnection con = new SqlConnection(strcon);

                    //check connection is open with the database
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE from movie_master_tbl WHERE movie_id='" + TextBox2.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();

                    Response.Write("<script>alert('Movie deleted successfully');</script>");
                    
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }

    }
}