﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayBusinesses.aspx.cs" Inherits="CouponsOnline.View.DisplayBusinesses" %>

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
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" CellPadding="20" GridLines="Vertical" Width="670px">
            <AlternatingRowStyle BackColor="#DCDCDC" />
            <Columns>
                <asp:BoundField DataField="Business ID" HeaderText="Business ID" InsertVisible="False" ReadOnly="True" SortExpression="Business ID" />
                <asp:BoundField DataField="Business name" HeaderText="Business name" SortExpression="Business name" />
                <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:CheckBoxField DataField="Is Blocked" HeaderText="Is Blocked" SortExpression="Is Blocked" />
                <asp:BoundField DataField="Category" HeaderText="Category" SortExpression="Category" />
                <asp:BoundField DataField="Creator" HeaderText="Creator" SortExpression="Creator" />
                <asp:BoundField DataField="Owner" HeaderText="Owner" SortExpression="Owner" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
            <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#0000A9" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#000065" />
        </asp:GridView>
        <asp:EntityDataSource ID="EntityDataSource1" runat="server">
        </asp:EntityDataSource>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:basicConnectionString %>" SelectCommand="SELECT Businesses.BusinessID AS [Business ID], Businesses.Name AS [Business name], Businesses.Address, Cities.Name AS City, Businesses.Blocked AS [Is Blocked], BusinessCategories.Description AS Category, Users_Admin.UserName AS Creator, Users_Owner.UserName AS Owner FROM Businesses INNER JOIN Users_Admin ON Businesses.Users_Admin_UserName = Users_Admin.UserName INNER JOIN Users_Owner ON Businesses.Users_Owner_UserName = Users_Owner.UserName INNER JOIN BusinessCategories ON Businesses.BusinessCategory_id = BusinessCategories.Id INNER JOIN Cities ON Businesses.City_Id = Cities.Id ORDER BY [Business ID]"></asp:SqlDataSource>
    
    </div>
        </form>
</body>
</html>