<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CouponsOnline.PresentationLayer.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
   
    <link href="css/style.css" rel="stylesheet" type="text/css" />
   
</head>
<body>
    <div class ="login-card">
        <form id="form1" runat="server">
            <h1>Log-in</h1><br />
            <asp:TextBox placeholder="User Name" TextMode="SingleLine" ID="TextBox1" runat="server"></asp:TextBox>
            <asp:TextBox placeholder="Password" ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
            <asp:Button ID="Button1" runat="server" class="login login-submit" OnClick="Button1_Click" Text="Login" />        
        <div class="login-help">
            <asp:LinkButton ID="LinkButton2" runat="server" Enabled="False">Forgot Password</asp:LinkButton><span>/</span>
            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">Register now!</asp:LinkButton>         
        </div>
        </form>
    </div>
</body>
</html>
