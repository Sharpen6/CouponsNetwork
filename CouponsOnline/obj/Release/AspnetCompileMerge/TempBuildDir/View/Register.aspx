<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CouponsOnline.View.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        
       
        <div class ="login-card">
                    <h1>Register</h1><br />
                    <asp:TextBox ID="TextBoxUserName" runat="server" placeholder="User Name" ></asp:TextBox>
                    <asp:TextBox ID="TextBoxPassword" runat="server" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:TextBox ID="TextBoxPasswordVal" runat="server" TextMode="Password" placeholder="Repeat Password"></asp:TextBox>    
                    <asp:TextBox ID="TextBoxName" runat="server" TextMode="SingleLine" placeholder="Name"></asp:TextBox>
                    <asp:TextBox ID="TextBoxPhoneNum" runat="server" TextMode="SingleLine" placeholder="PhoneNum"></asp:TextBox> 
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" placeholder="Email"></asp:TextBox>
                    <asp:RadioButtonList ID="radioBtnUserType" runat="server">
                        <asp:ListItem Selected="True">Regular Account</asp:ListItem>
                        <asp:ListItem>I'm a Business owner</asp:ListItem>
                    </asp:RadioButtonList>
                    
                    
                    <asp:BulletedList ID="BLerrors" runat="server" ForeColor="Maroon" Font-Size="Small">
                    </asp:BulletedList>
                    
                    Choose Your Interests:
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" />
         
        <br />
                    <asp:Button ID="Button1" runat="server" class="login login-submit" Text="Register" width="100%" OnClick="SendButton_Click"/>
                    
                    
        <br />
        <asp:Button ID="btnCreateAdmin" runat="server" Text="dbg: create admin (usr:admin pass:1234)" OnClick="btnCreateAdmin_Click" />
            <p>
                <asp:Button ID="btnCreateOwner" runat="server" Text="dbg: create owner (usr:owner pass:1234)" OnClick="btnCreateOwner_Click" />
            </p>
            <p>
                <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="dbg: create user (usr:user pass:1234)" />
            </p>
            <p>
                <asp:Button ID="btnAddInformation" runat="server" OnClick="btnAddInformation_Click" Text="dbg: Add demonstration information" />
            </p>
            </div>
    </form>
</body>
</html>
