<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchCoupon.aspx.cs" Inherits="CouponsOnline.SearchCoupon" %>

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
                    <a href="CustomerHomePage.aspx">Home</a>
                </li>
                <li class="dropdown">
                    <a href="DisplayBusinesses.aspx">Display Businesses</a>
                </li>
                <li class="dropdown">
                    <a href="#!/Find Coupons" onclick="SwitchTo('FindCoupon');">Find Coupon</a>                   
                </li>
                <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
                </li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
    <div id="home" class="mainBox">
         <h1>Find Coupons</h1>
    </div>
    <div id="FindCoupon" class="mainBox">
        <div>
            <asp:Label ID="Label2" Width="90%"  runat="server" Text="Sorry, Our GPS tracking server is down :("></asp:Label>
            <asp:Label ID="Label1" Width="90%" runat="server" Text="Please enter your location"></asp:Label>
            <asp:TextBox ID="TextBox1" Width="45%" runat="server" placeholder="Latitude"></asp:TextBox>
            <asp:TextBox ID="TextBox2" Width="45%" runat="server" placeholder="Longitude"></asp:TextBox>                    
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Width="45%" Text="OR, Enter location"></asp:Label>
            <asp:TextBox ID="TextBox3" Width="45%" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" Width="45%" runat="server" Text="OR, Select coupon by interests"></asp:Label>
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="90%" >
        </div>
        <asp:Button ID="BtnSearch" runat="server" Width="90%" Text="Scan" OnClick="BtnSearch_Click" />
    </div>
    <div id="ShowBusinesses" class="mainBox">
         
    </div>
    </form>
</body>
</html>
