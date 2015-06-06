<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerHomePage.aspx.cs" Inherits="CouponsOnline.View.CustomerHomePage" %>

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
                    <a href="#!/home" onclick="SwitchTo('home');">Home</a>
                </li>
                <li class="dropdown">
                    <a href="SearchCoupon.aspx">Search</a>
                    <ul>
                        <li>
                            <a href="SearchCoupon.aspx">Coupons</a>  
                        </li>
                        <li>
                            <a href="DisplayBusinesses.aspx">Business</a>  
                        </li>
                    </ul>                 
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
    <br />
    <form id="form1" runat="server">
    <div id="home" class="mainBox">
    home
    </div>
    <div id="ManageCoupons" class="mainBox">
    managecoupon
    </div>
    <div id="FindCoupons" class="mainBox">
        <h1>Create New Coupon</h1>
        <asp:TextBox ID="TextBoxName" runat="server" placeholder="Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxDesc" runat="server" placeholder="Description"></asp:TextBox>
        <asp:Button ID="BtnCreateCoupon" runat="server" Text="Add Coupon"/>
    </div>
    <div id="ActiveCoupons" class="mainBox">
    active coupons
    </div>
    <div id="Purchased" class="mainBox">
    purchased
    </div>
    </form>
</body>
</html>
