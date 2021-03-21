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
    public partial class adminmembermanagement : System.Web.UI.Page
    {

        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //Go button
        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {
            GetMemberByID();
        }

        //Active button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }
        //pending button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {

        }

        //deactive button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }


        //delete button
        protected void Button2_Click(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        void GetMemberByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                //check connection is open with the database
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "';", con);
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
    }
}