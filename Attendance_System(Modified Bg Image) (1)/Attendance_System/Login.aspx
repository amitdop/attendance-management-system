<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Attendance_System.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Viva Institute of Technology - Login</title>

    <style>
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
            font-family: Arial, sans-serif;
        }

        body {
            height: 100vh;
            background: linear-gradient(120deg, #1d2671, #c33764);
            display: flex;
            justify-content: center;
            align-items: center;
        }

        .main-container {
            width: 90%;
            height: 90vh;
            background: #fff;
            display: flex;
            border-radius: 18px;
            overflow: hidden;
            box-shadow: 0 0 30px rgba(0,0,0,0.4);
        }

        /* LEFT SIDE (INSTITUTE SECTION) */
        .left-panel {
            width: 55%;
            background: linear-gradient(135deg, #0f2027, #203a43, #2c5364);
            color: white;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 40px;
            text-align: center;
        }

        .left-panel img {
            width: 160px;
            margin-bottom: 20px;
        }

        .left-panel h1 {
            font-size: 36px;
            margin-bottom: 10px;
        }

        .left-panel p {
            font-size: 16px;
            opacity: 0.9;
            line-height: 1.6;
        }

        /* RIGHT SIDE (LOGIN SECTION) */
        .right-panel {
            width: 45%;
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            background: #f5f7fa;
            padding: 40px;
        }

        .login-card {
            width: 100%;
            max-width: 380px;
            background: white;
            padding: 35px;
            border-radius: 15px;
            box-shadow: 0 0 20px rgba(0,0,0,0.2);
            text-align: center;
        }

        .login-card h2 {
            margin-bottom: 25px;
            color: #333;
        }

        .roles button {
            margin: 5px;
            padding: 8px 22px;
            border: none;
            border-radius: 25px;
            background: #ddd;
            cursor: pointer;
            font-weight: bold;
        }

        .roles button.active {
            background: #1d2671;
            color: #fff;
        }

        .input-box {
            margin-top: 18px;
        }

        .input-box input {
            width: 100%;
            padding: 11px;
            border-radius: 10px;
            border: 1px solid #ccc;
            outline: none;
        }

        .btn-login {
            margin-top: 25px;
            padding: 12px;
            width: 100%;
            border-radius: 25px;
            border: none;
            background: #1d2671;
            color: white;
            font-size: 15px;
            cursor: pointer;
        }

        .btn-login:hover {
            background: #131b4d;
        }

        .error {
            margin-top: 10px;
            font-size: 14px;
            color: red;
        }

        @media(max-width: 900px) {
            .main-container {
                flex-direction: column;
                height: auto;
            }

            .left-panel, .right-panel {
                width: 100%;
            }
        }
    </style>

    <script>
        function setRole(role) {
            document.getElementById('<%= hfRole.ClientID %>').value = role;

            let btns = document.querySelectorAll(".roles button");
            btns.forEach(b => b.classList.remove("active"));
            document.getElementById(role + "Btn").classList.add("active");
        }
    </script>

</head>
<body>

<form id="form1" runat="server">

    <div class="main-container">

        <!-- LEFT PANEL -->
        <div class="left-panel">
          <img src="Images/VivaLogo.jpg" alt="Viva Institute Logo" style="width:160px; margin-bottom:20px;" />

            <h1>Viva Institute of Technology</h1>
            <p>
                Welcome to the official Attendance Management System.<br />
                Please login with your authorized credentials to continue.
            </p>
        </div>

        <!-- RIGHT PANEL -->
        <div class="right-panel">

            <div class="login-card">
                <h2>Login</h2>

                <div class="roles">
                    <button type="button" id="adminBtn" onclick="setRole('admin')">Admin</button>
                    <button type="button" id="teacherBtn" class="active" onclick="setRole('teacher')">Teacher</button>
                    <button type="button" id="studentBtn" onclick="setRole('student')">Student</button>
                </div>

                <asp:HiddenField ID="hfRole" runat="server" Value="teacher" />

                <div class="input-box">
                    <asp:TextBox ID="TextBox1" runat="server" Placeholder="Username / Email"></asp:TextBox>
                </div>

                <div class="input-box">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Placeholder="Password"></asp:TextBox>
                </div>

                <asp:Button ID="Button1" runat="server" Text="Login" CssClass="btn-login" OnClick="Button1_Click" />

                <div class="error">
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                </div>

            </div>

        </div>

    </div>

</form>

</body>
</html>
