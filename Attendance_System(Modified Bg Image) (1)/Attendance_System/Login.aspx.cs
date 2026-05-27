using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Attendance_System
{
    public partial class Login : System.Web.UI.Page
    {
        string str = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                hfRole.Value = "teacher"; // default role
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Label1.Text = "";
            Label1.ForeColor = System.Drawing.Color.Red;

            string selectedRole = Request.Form[hfRole.UniqueID];

            if (string.IsNullOrEmpty(selectedRole))
            {
                Label1.Text = "Please select a role.";
                return;
            }

            selectedRole = selectedRole.Trim().ToLower();
            string username = TextBox1.Text.Trim();
            string password = TextBox2.Text.Trim();

            if (username == "" || password == "")
            {
                Label1.Text = "Username and Password required.";
                return;
            }

            DataTable dtTeacher = new DataTable();
            DataTable dtStudent = new DataTable();

            using (SqlConnection con = new SqlConnection(str))
            {
                con.Open();

                SqlCommand cmdT = new SqlCommand("SELECT * FROM Teacher WHERE TUserID=@u AND TPassword=@p", con);
                cmdT.Parameters.AddWithValue("@u", username);
                cmdT.Parameters.AddWithValue("@p", password);

                SqlDataAdapter daT = new SqlDataAdapter(cmdT);
                daT.Fill(dtTeacher);

                SqlCommand cmdS = new SqlCommand("SELECT * FROM Student WHERE Email=@u AND Password=@p", con);
                cmdS.Parameters.AddWithValue("@u", username);
                cmdS.Parameters.AddWithValue("@p", password);

                SqlDataAdapter daS = new SqlDataAdapter(cmdS);
                daS.Fill(dtStudent);
            }

            // ================= ROLE VALIDATION =================

            if (selectedRole == "admin")
            {
                if (username == "Admin" && password == "123")
                {
                    Response.Redirect("Admin_Home.aspx");
                }
                else
                {
                    Label1.Text = "Invalid Admin credentials.";
                }
            }
            else if (selectedRole == "teacher")
            {
                if (dtTeacher.Rows.Count == 1)
                {
                    Session["TeacherID"] = dtTeacher.Rows[0][0];
                    Session["TeacherName"] = dtTeacher.Rows[0][1];
                    Response.Redirect("Teacher_Home.aspx");
                }
                else if (dtStudent.Rows.Count == 1)
                {
                    Label1.Text = "These credentials belong to a Student. Select Student.";
                }
                else
                {
                    Label1.Text = "Invalid Teacher credentials.";
                }
            }
            else if (selectedRole == "student")
            {
                if (dtStudent.Rows.Count == 1)
                {
                    // Store useful session info
                    Session["UserID"] = dtStudent.Rows[0]["STID"];      // Student ID
                    Session["UserName"] = dtStudent.Rows[0]["SName"];   // Student Name
                    Session["UserRole"] = "Student";                     // Optional role
                    Response.Redirect("Student_Home.aspx");
                }

                else if (dtTeacher.Rows.Count == 1)
                {
                    Label1.Text = "These credentials belong to a Teacher. Select Teacher.";
                }
                else
                {
                    Label1.Text = "Invalid Student credentials.";
                }
            }
            else
            {
                Label1.Text = "Invalid role selected.";
            }
        }
    }
}
