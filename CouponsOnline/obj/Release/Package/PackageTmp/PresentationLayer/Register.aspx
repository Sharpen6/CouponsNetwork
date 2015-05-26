﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="CouponsOnline.PresentationLayer.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 119px;
        }
    </style>
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
                        <asp:ListItem>Regular Account</asp:ListItem>
                        <asp:ListItem>I'm a Business owner</asp:ListItem>
                    </asp:RadioButtonList>
                    <asp:Button ID="Button1" runat="server" class="login login-submit" Text="Register" width="100%" OnClick="SendButton_Click"/>
                    <asp:Label ID="LabelError" runat="server"></asp:Label>
                    
        <br />
        <br />
        <asp:Button ID="btnCreateAdmin" runat="server" Text="dbg: create admin (usr:admin pass:1234)" OnClick="btnCreateAdmin_Click" />
        <p>
            <asp:Button ID="btnCreateOwner" runat="server" Text="dbg: create owner (usr:owner pass:1234)" OnClick="btnCreateOwner_Click" />
        </p>
        <p>
            <asp:Button ID="btnCreateUser" runat="server" OnClick="btnCreateUser_Click" Text="dbg: create user (usr:user pass:1234)" />
        </p>
            </div>
    </form>
</body>
</html>