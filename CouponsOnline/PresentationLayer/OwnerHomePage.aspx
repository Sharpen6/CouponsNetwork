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
                <li>
                    <a href="#!/home" onclick="SwitchTo('home');">Home</a>
                </li>
                <li class="dropdown">
                    <a href="Manage.aspx">Manage Coupons</a>
                    <ul>
                        <li>
                            <a href="Display.aspx">Display All</a>
                        </li>
                        <li>
                            <a onclick="SwitchTo('CreateCoupon');">Add Coupon</a>
                        </li>
                        <li>
                            <a onclick="SwitchTo('RemoveCoupon');">Remove Coupon</a>
                        </li>
                    </ul>
                </li>
                 <li class="dropdown">
                    <a href="Manage.aspx">Manage Interest</a>
                    <ul>
                   
                        <li>
                            <a onclick="SwitchTo('AddInterest');">Add Interest</a>
                        </li>
                    </ul>
                </li>
                <li class="dropdown">

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
        <asp:TextBox ID="TextBoxOrg" runat="server" TextMode="Number" placeholder="Original Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxDisc" runat="server" TextMode="Number" placeholder="New Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxMPU" runat="server" TextMode="Number" placeholder="Maximum Per User"></asp:TextBox>       
        <asp:TextBox ID="TextBoxExp" runat="server" TextMode="Date" placeholder="Last Parchase Date"></asp:TextBox>
        
        <asp:Button ID="BtnCreateCoupon" runat="server" Text="Add Coupon" OnClick="BtnCreateCoupon_Click" />
    </div>

        <div id="AddInterest" class="mainBox">
       <h1>Choose one of Your Busniess</h1>
         <asp:DropDownList ID="DropDownListCategory" runat="server" placeholder="Pick Your Category" AutoPostBack="false" ></asp:DropDownList>

        <asp:TextBox ID="TextBoxInterest" runat="server" placeholder="Interest Name"></asp:TextBox>
        <asp:Button ID="BtnAddInterest" runat="server" Text="Add Interest" onclick="BtnAddInterest_Click1"/>

    
    </div>
         <div id="RemoveCoupon" class="mainBox">
        <h1>Choose one of Your Busniess</h1>
         <asp:DropDownList id="DropDownList1" runat="server" placeholder="Pick Your Busniess" AutoPostBack="true" OnSelectedIndexChanged="DropDownListBusniess_SelectedIndexChanged"></asp:DropDownList>
        <br />
         <h1>Choose Your Coupon interests</h1>
             <asp:checkboxlist id="Checkboxlist1" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" >
          
        </asp:checkboxlist>
      

        
        <h1>Create New Coupon</h1>
        <asp:TextBox ID="TextBox1" runat="server" placeholder="Name"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" placeholder="Description"></asp:TextBox>
        <asp:TextBox ID="TextBox3" runat="server" TextMode="Number" placeholder="Original Price"></asp:TextBox>
        <asp:TextBox ID="TextBox4" runat="server" TextMode="Number" placeholder="New Price"></asp:TextBox>
        <asp:TextBox ID="TextBox5" runat="server" TextMode="Number" placeholder="Maximum Per User"></asp:TextBox>       
        <asp:TextBox ID="TextBox6" runat="server" TextMode="Date" placeholder="Last Parchase Date"></asp:TextBox>
        
        <asp:Button ID="Button1" runat="server" Text="Add Coupon" OnClick="BtnCreateCoupon_Click" />
    </div>
    </form>
</body>
</html>
