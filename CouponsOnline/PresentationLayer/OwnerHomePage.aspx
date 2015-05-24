<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OwnerHomePage.aspx.cs" Inherits="CouponsOnline.PresentationLayer.OwnerHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link href="css/styleMain.css" rel="stylesheet" />
    <title></title>
    <script src="../js/script.js"></script>
</head>
<body>
     <header>

        <nav>
            <ul class="nav">
                <ul class="nav">
                <li>
                    <a href="#!/home" onclick="SwitchTo('home');">Home</a>
                </li>
                  <li class="dropdown">
                <a>Manage Coupons</a>
                <ul>
                <li>

                    <a href="#!/AddCoupon" onclick="SwitchTo('CreateCoupon');">Add Coupon</a>
                </li>
                    <li >
                    <a href="RemoveCoupon.aspx">Remove Coupon</a>
            </li>
                    </ul>
                      </li>
                <li>
                    <a href="#!/AddInterest" onclick="SwitchTo('AddInterest');">Add Interest</a>
                </li>
                <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
                </li>
            </ul>
        </nav>
    </header>
    <form id="form1" runat="server">

    <div id="CreateCoupon" class="mainBox">
        <h1>Choose one of Your Busniess</h1>
         <asp:DropDownList id="DropDownListBusniess" runat="server" placeholder="Pick Your Busniess" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBusniess_SelectedIndexChanged"></asp:DropDownList>
        <br />
         <h1>Choose Your Coupon interests</h1>
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" >
          
        </asp:checkboxlist>
      

        
        <h1>Create New Coupon</h1>
        <asp:TextBox ID="TextBoxName" runat="server" placeholder="Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxDesc" runat="server" placeholder="Description"></asp:TextBox>
        <asp:TextBox ID="TextBoxOrg" runat="server"  placeholder="Original Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxDisc" runat="server" placeholder="New Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxMPU" runat="server" TextMode="Number" placeholder="Maximum Per User"></asp:TextBox>       
        <asp:TextBox ID="TextBoxExp" runat="server" TextMode="Date" placeholder="Last Parchase Date"></asp:TextBox>
        <%--<asp:RangeValidator ID="rgvStartDate" runat="server" ErrorMessage="Expiration date must be greater than today"
                text="*" ValidationGroup="AddEvent" ControlToValidate="TextBoxExp" Type="Date"></asp:RangeValidator>
        --%><asp:Button ID="BtnCreateCoupon" runat="server" Text="Add Coupon" OnClick="BtnCreateCoupon_Click" />
    </div>

        <div id="AddInterest" class="mainBox">
       <h1>Choose one of Your Busniess</h1>
         <asp:DropDownList ID="DropDownListCategory" runat="server" placeholder="Pick Your Category" AutoPostBack="false" ></asp:DropDownList>

        <asp:TextBox ID="TextBoxInterest" runat="server" placeholder="Interest Name"></asp:TextBox>
        <asp:Button ID="BtnAddInterest" runat="server" Text="Add Interest" onclick="BtnAddInterest_Click1"/>

    
    </div>
    
    </form>
</body>
</html>
