<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="CouponsOnline.View.Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/script.js"></script>
    <link href="css/styleMain.css" rel="stylesheet" />
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
   
     <div id="home" style="display:block" class ="mainBox" runat="server">
        <h1>Your Profile:</h1>

       User Name:
        <asp:TextBox ID="TextBoxUserName" runat="server" placeholder="User Name" Enabled="false" ></asp:TextBox>
      
        Name:
                    <asp:TextBox ID="TextBoxName" runat="server" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
        PhoneNum:
                    <asp:TextBox ID="TextBoxPhoneNum" runat="server" TextMode="SingleLine" placeholder="PhoneNum"></asp:TextBox>
        Email:
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
            <br /><asp:Label ID="LabelInterets" runat="server" Text="Label">Choose Your Interests:</asp:Label>
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" />
         
                    <asp:BulletedList ID="BLerrors" runat="server" ForeColor="Maroon" Font-Size="Small">
                    </asp:BulletedList>
         <asp:Button ID="Button1" runat="server" Text="Change Profile" width="60%" OnClick="Button1_Click"/>
         <h1>Reset Your Password</h1>
         <div>
             <h1>
                 Password:
             </h1>
         <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
         </div>
        <div>
            <h1>
                Repeat Password:
            </h1>
        <asp:TextBox ID="TextBoxPasswordVal" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>    
        </div>
        <div>
            <asp:Button ID="reset" runat="server" Text="Reset Password" width="60%" OnClick="reset_Click"/>           
        </div>  
         <asp:Button ID="delete" runat="server" Text="Delete Account" width="60%" OnClick="delete_Click"/>
                    
    </div>
    <div id="ResetPassword" class ="mainBox" runat="server">
        

    </div>
    </form>
</body>
</html>
