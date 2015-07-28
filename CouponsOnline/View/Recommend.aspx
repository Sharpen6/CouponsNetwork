<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Recommend.aspx.cs" Inherits="CouponsOnline.View.Recommend" %>

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
            <h1>Recommend:</h1>
            <asp:RadioButton ID="RadioButton1" Text="By Location" runat="server" GroupName="type" OnCheckedChanged="RadioButton1_CheckedChanged"/><br />
            <asp:RadioButton ID="RadioButton2" Text="By Category" runat="server" GroupName="type" OnCheckedChanged="RadioButton1_CheckedChanged"/><br />
            <asp:RadioButton ID="RadioButton3" Text="By Both" runat="server" GroupName="type" OnCheckedChanged="RadioButton1_CheckedChanged"/><br />
        </div>
        <div>
            <h1>Results:</h1>
        </div>
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