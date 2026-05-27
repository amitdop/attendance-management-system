using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Attendance_System
{
    public partial class Teacher : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridShow();
        }

        private void GridShow()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Teacher", con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con2 = new SqlConnection(str);
            SqlDataAdapter sda1 = new SqlDataAdapter("select * from Teacher where TUserID='" + TextBox3.Text.ToString() + "' ", con2);
            DataTable dt = new DataTable();
            sda1.Fill(dt);
            if (dt.Rows.Count == 1)
            {
                Label1.Text = "Entered EmailID is already existing.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                string Fname = TextBox2.Text;
                string Lname = TextBox4.Text;
                string FullName = Fname +" "+ Lname;
                SqlConnection con = new SqlConnection(str);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into Teacher(TName,TUserID,TPassword) values(@1,@2,@3)", con);
                cmd.Parameters.AddWithValue("@1", FullName);
                cmd.Parameters.AddWithValue("@2", TextBox3.Text);
                cmd.Parameters.AddWithValue("@3", TextBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                Label1.Text = "Successfully Added";
                Label1.ForeColor = System.Drawing.Color.Green;
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox1.Text = "";
                TextBox4.Text = "";
                GridShow();
            }
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridShow();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int TeacherId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from Teacher where TID=@1", con1);

            cmd1.Parameters.AddWithValue("@1", TeacherId);
            cmd1.ExecuteNonQuery();
            con1.Close();
            Label1.Text = "Record Deleted Successful";
            Label1.ForeColor = System.Drawing.Color.DarkGreen;
            GridShow();
        }
    }
}