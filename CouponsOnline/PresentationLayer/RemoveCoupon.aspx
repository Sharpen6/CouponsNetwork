<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveCoupon.aspx.cs" Inherits="CouponsOnline.PresentationLayer.AddCoupon" %>


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
                    <a href="OwnerHomePage.aspx">Back</a>
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
              <asp:Label ID="Label2" Width="90%"  runat="server" Text="Choose one of Your Busniess"></asp:Label>
            <br />
            <asp:DropDownList id="DropDownListBusniess" runat="server" placeholder="Pick Your Busniess" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBusniess_SelectedIndexChanged"></asp:DropDownList>
              <br />
       
        <asp:Button ID="BtnSearch" runat="server" Width="90%" Text="Scan" OnClick="BtnSearch_Click" />
        <asp:GridView ID="GridVresults" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridVresults_RowCommand">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775"  />
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="RemoveCoupon" ShowHeader="True" Text="Remove"/>
             
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
     </div>
    </form>
</body>
</html>

