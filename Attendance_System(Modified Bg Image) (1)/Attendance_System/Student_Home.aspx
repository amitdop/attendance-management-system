<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Student_Home.aspx.cs" Inherits="Attendance_System.Student_Home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <center>
    <div style="background-image: url('Images/StudentHome.jpg'); width: 1200px; height:490px; background-repeat:no-repeat; background-size: cover;">
    <h1>Student Home Page!!</h1>
    	<asp:Label runat="server" ID="Label1"></asp:Label>
        <br /><br /><br /><br />
    </div>
    </center>
</asp:Content>
