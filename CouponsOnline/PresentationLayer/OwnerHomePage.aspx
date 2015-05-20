<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OwnerHomePage.aspx.cs" Inherits="CouponsOnline.PresentationLayer.OwnerHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/styleMain.css" rel="stylesheet" />
</head>
<body>
     <header>

        <nav>
            <ul class="nav">
                <li>
                    <a href="#!/home" onclick="SwitchTo('home');">Home</a>
                </li>
                <li class="dropdown">
                    <a href="Manage.aspx">Manage</a>
                    <ul>
                        <li>
                            <a href="Display.aspx">Display All</a>
                        </li>
                        <li>
                            <a onclick="SwitchTo('CreateCoupon');">Add Coupon</a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">

                </li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">
    <div>
    <div id="CreateCoupon" class="mainBox">
        <h1>Create New Coupon</h1>
        <asp:TextBox ID="TextBoxName" runat="server" placeholder="Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxDesc" runat="server" placeholder="Description"></asp:TextBox>
        <asp:TextBox ID="TextBoxOrg" runat="server" TextMode="Number" placeholder="Original Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxDisc" runat="server" TextMode="Number" placeholder="New Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxMPU" runat="server" TextMode="Number" placeholder="Maximum Per User"></asp:TextBox>       
        <asp:TextBox ID="TextBoxExp" runat="server" TextMode="Date" placeholder="Last Parchase Date"></asp:TextBox>
        
        <asp:Button ID="BtnCreateCoupon" runat="server" Text="Add Coupon" OnClick="BtnCreateCoupon_Click" />
    </div>
    </div>
    </form>
</body>
</html>
