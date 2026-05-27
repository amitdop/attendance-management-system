<%@ Page Title="" Language="C#" MasterPageFile="~/Student.Master" AutoEventWireup="true" CodeBehind="Student_Defaulter.aspx.cs" Inherits="Attendance_System.Student_Defaulter" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <center>
    <div style="background-image: url('Images/Defaulter.jpg'); width: 1200px; height:520px; background-repeat:no-repeat; background-size: cover;">
    <table align="center" style="width: 386px">
        <tr>
            <td align="center">
                <h3>Select:</h3>
                
            </td>
            <td align="center">
            <input name="startDate" id="Text1" class="date-picker" runat="server" value=""/>

            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Button ID="Button1" runat="server" Text="Select" Font-Bold="True" 
                    Font-Size="Large" Height="44px"  Width="103px" OnClick="Button1_Click"  />
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#9900CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#9900CC"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="center">
                <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Large" 
                    ></asp:Label>
            </td>
        </tr>
        </table>
        </div>
     </center>
</asp:Content>
