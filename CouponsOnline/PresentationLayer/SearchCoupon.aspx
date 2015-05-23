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
                    <a href="CustomerHomePage.aspx">Back</a>
                </li>
                <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
                </li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
    <div id="home" class="mainBox large" style="display:block">
        <div>
            <asp:Label ID="Label2" Width="90%"  runat="server" Text="Sorry, Our GPS tracking server is down :("></asp:Label>
            <asp:Label ID="Label1" Width="90%" runat="server" Text="Please enter your location"></asp:Label>
            <asp:TextBox ID="TextBox1" Width="45%" runat="server" placeholder="Latitude"></asp:TextBox>
            <asp:TextBox ID="TextBox2" Width="45%" runat="server" placeholder="Longitude"></asp:TextBox>                    
        </div>
        <div>
            <asp:Label ID="Label4" runat="server" Width="45%" Text="OR, Enter City"></asp:Label>
            <asp:DropDownList ID="DropDownListCities" runat="server"></asp:DropDownList>
        </div>
        <div>
            <asp:Label ID="Label3" Width="45%" runat="server" Text="OR, Select coupon by interests"></asp:Label>
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" Width="45%" runat="server" SelectionMode="Multiple" />
        </div>
        <asp:Button ID="BtnSearch" runat="server" Width="90%" Text="Scan" OnClick="BtnSearch_Click" />
        <asp:GridView ID="GridVresults" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Purchase" ShowHeader="True" Text="Buy" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
