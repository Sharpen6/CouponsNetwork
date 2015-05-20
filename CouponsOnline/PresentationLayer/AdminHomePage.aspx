<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="CouponsOnline.PresentationLayer.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/styleMain.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
    <title></title>
</head>
<body>
    <nav>
        <ul class="nav">
            <li>
                <a href="#!/home" onclick="SwitchTo('home');">Home</a>
            </li>
            <li class="dropdown">
                <a>Manage Businesses</a>
                <ul>
                    <li>
                        <a href="DisplayBusinesses.aspx">Display All</a>
                    </li>
                    <li>
                        <a onclick="SwitchTo('AddBusiness');">Add Business</a>
                    </li>
                </ul>
            </li>
            <li class="dropdown">
                <a>Manage Categories</a>
                <ul>
                    <li>
                        <a onclick="SwitchTo('AddCategory');">Add Category</a>
                    </li>
                </ul>
            </li>
            <li class="dropdown">

            </li>
        </ul>
    </nav>
    <form id="form1" runat="server">
    <div id="home" class="mainBox">
    <h1>welcome!</h1>
    </div>
    <div id="AddBusiness" class="mainBox">
        <asp:TextBox ID="TextBoxBusinessName" runat="server" placeholder="Business Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxAddress" runat="server" placeholder="Address"></asp:TextBox>
        <asp:DropDownList ID="DropDownListOwners" runat="server" placeholder="Pick Owner"></asp:DropDownList>
        <asp:DropDownList ID="DropDownListCategories" runat="server" placeholder="Pick Category"></asp:DropDownList>
        <asp:Button ID="BtnAddBusiness" runat="server" Text="Add Business" onclick="BtnAddBusiness_Click"/>
    </div>
     <div id="AddCategory" class="mainBox">
        <asp:TextBox ID="TextBoxCat" runat="server" placeholder="Category Name"></asp:TextBox>
        <asp:Button ID="BtnAddCategory" runat="server" Text="Add Category" onclick="BtnAddCategory_Click"/>
    </div>
    </form>
</body>
</html>
