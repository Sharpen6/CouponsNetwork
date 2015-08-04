<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminPanel.aspx.cs" Inherits="CouponsOnline.View.AdminPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/styleMain.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
</head>
<body>
    <header>
    <nav>
        <ul class="nav">
            <li>
                <a href="BusinessManage.aspx">Businesses Management</a>            
            </li>
            <li>
                <a href="CategoriesManage.aspx">Categories Management</a>            
            </li>
            <li>
                <a href="CityManage.aspx">Cities Management</a>
            </li>
            <li>
                <a href="CouponManage.aspx">Coupons Management</a>
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
    <div id="home" class="mainBox">
    <h1>welcome!</h1>
    </div>
    </form>
</body>
</html>
