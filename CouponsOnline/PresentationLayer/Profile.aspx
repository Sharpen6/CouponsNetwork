<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CouponsOnline.PresentationLayer.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
    </style>
    <script src="../js/script.js"></script>
     <link href="css/styleMain.css" rel="stylesheet" />
       <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <header>

        <nav>
            <ul class="nav">
                <li>
                  <a id="homeLink" runat="server">Home</a>
                </li>
                
                <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
                </li>
            </ul>
        </nav>
    </header>
    <br />
    <form id="form1" runat="server">
   
     <div class ="login-card" runat="server" id="home" style="display: none">
        <h1>Your Profile:</h1>

       User Name:
        <asp:TextBox ID="TextBoxUserName" runat="server" placeholder="User Name" Enabled="false" ></asp:TextBox>
      
        Name:
                    <asp:TextBox ID="TextBoxName" runat="server" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
        PhoneNum:
                    <asp:TextBox ID="TextBoxPhoneNum" runat="server" TextMode="SingleLine" placeholder="PhoneNum"></asp:TextBox>
        Email:
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            Choose Your Interests:
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" />
         
                    <asp:BulletedList ID="BLerrors" runat="server" ForeColor="Maroon" Font-Size="Small">
                    </asp:BulletedList>
         <asp:Button ID="Button1" runat="server" class="login login-submit" Text="Change Profile" width="60%" OnClick="Button1_Click"/>
         <asp:Button ID="Button2" runat="server" class="login login-submit" Text="Change Profile" width="60%" OnClick="Button2_Click"/>
                
                   
         <asp:Button ID="delete" runat="server" class="login login-submit" Text="Delete Account" width="60%" OnClick="delete_Click"/>
                    
    </div>
    <div class ="login-card" id="ResetPassword" runat="server" style="display: none">
        <h1>Reset Your Password</h1>
         Password:
         <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
        Repeat Password:
                    <asp:TextBox ID="TextBoxPasswordVal" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>    
              <asp:Button ID="reset" runat="server" class="login login-submit" Text="Reset Password!" width="60%" OnClick="reset_Click"/>
              
    </div>

    </form>
</body>
</html>
