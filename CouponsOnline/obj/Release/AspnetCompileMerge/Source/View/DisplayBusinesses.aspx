<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayBusinesses.aspx.cs" Inherits="CouponsOnline.View.DisplayBusinesses" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
        <link href="css/styleMain.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
</head>
<body>
    <header>
        <nav>
            <ul class="nav">
                <li>
                    <a href="AdminHomePage.aspx">Back</a>
                </li>
                
                <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
                </li>
                        <li class="lastTab">
                    <a href="Profile.aspx">Your Profile</a>
                </li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
    <div id="home" class="mainBox" style="max-width:700px">
    <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        </div>
        </form>
</body>
</html>
