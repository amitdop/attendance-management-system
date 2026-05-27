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
    public partial class Student : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ---------------- Session Check ----------------
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx"); // redirect if not logged in
                return; // stop further execution
            }

            // ---------------- Existing Code ----------------
            if (!IsPostBack)
            {
                DrpDwnCourse();
                ShowStudent();
            }
        }


        private void DrpDwnCourse()
        {
            SqlConnection con = new SqlConnection(str);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Course", con);
            DropDownList2.DataSource = cmd.ExecuteReader();
            DropDownList2.DataTextField = "CourseName";
            DropDownList2.DataValueField = "CID";
            DropDownList2.DataBind();
            con.Close();
            DropDownList2.Items.Insert(0, "Select Course");

        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(DropDownList3.SelectedValue) > 0)
            {
                DataTable statedt = new DataTable();
                statedt.Columns.Add("SemId", typeof(int));
                statedt.Columns.Add("SemName");
                if (DropDownList3.SelectedValue == "1")
                {
                    statedt.Rows.Add(0, "Select Semester");
                    statedt.Rows.Add(1, "Sem I");
                    statedt.Rows.Add(2, "Sem II");
                }
                if (DropDownList3.SelectedValue == "2")
                {
                    statedt.Rows.Add(0, "Select Semester");
                    statedt.Rows.Add(3, "Sem III");
                    statedt.Rows.Add(4, "Sem IV");
                }
                if (DropDownList3.SelectedValue == "3")
                {
                    statedt.Rows.Add(0, "Select Semester");
                    statedt.Rows.Add(5, "Sem V");
                    statedt.Rows.Add(6, "Sem VI");
                }
                DropDownList1.DataSource = statedt;
                DropDownList1.DataTextField = "SemName";
                DropDownList1.DataValueField = "SemId";
                DropDownList1.DataBind();
                if (DropDownList3.SelectedValue == "0")
                {
                    Label1.Text = "Please select proper Semester field.";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "Select Course" && DropDownList3.SelectedValue == "0" && DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please select all the fields.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else if (DropDownList2.SelectedValue == "Select Course" || DropDownList3.SelectedValue == "0" || DropDownList1.SelectedValue == "0")
            {
                Label1.Text = "Please select all the fields.";
                Label1.ForeColor = System.Drawing.Color.Red;
            }
            else
            {
                SqlConnection con2 = new SqlConnection(str);
                SqlDataAdapter sda1 = new SqlDataAdapter("select * from Student where Email='" + TextBox2.Text.ToString() + "' ", con2);
                DataTable dt = new DataTable();
                sda1.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    Label1.Text = "Entered EmailID is already existing.";
                    Label1.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    string FName = TextBox1.Text;
                    string LName = TextBox5.Text;
                    string FullName = FName +" "+ LName;
                    SqlConnection con = new SqlConnection(str);
                    SqlCommand cmd = new SqlCommand("insert into Student(SName,Roll,Email,Phone,Course,Year,Sem,Password) values(@1,@2,@3,@4,@5,@6,@7,@8)", con);
                    con.Open();
                    cmd.Parameters.AddWithValue("@1", FullName);
                    cmd.Parameters.AddWithValue("@2", TextBox4.Text);
                    cmd.Parameters.AddWithValue("@3", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@4", TextBox3.Text);
                    cmd.Parameters.AddWithValue("@5", DropDownList2.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@6", DropDownList3.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@7", DropDownList1.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@8", TextBox6.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    TextBox1.Text = "";
                    TextBox2.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox6.Text = "";
                    DropDownList2.SelectedValue = "Select Course";
                    Label1.Text = "Added Successfully";
                    Label1.ForeColor = System.Drawing.Color.Green;
                    ShowStudent();
                }
            }
        }

        private void ShowStudent()
        {
            SqlConnection con = new SqlConnection(str);
            SqlDataAdapter sda = new SqlDataAdapter("select * from Student", con);
            con.Open();
            DataTable dt = new DataTable();
            sda.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            ShowStudent();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int StudentId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
            SqlConnection con1 = new SqlConnection(str);
            con1.Open();
            SqlCommand cmd1 = new SqlCommand("Delete from Student where STID=@1", con1);

            cmd1.Parameters.AddWithValue("@1", StudentId);
            cmd1.ExecuteNonQuery();
            con1.Close();
            Label1.Text = "Record Deleted Successful";
            Label1.ForeColor = System.Drawing.Color.DarkGreen;
            ShowStudent();
        }
    }
}