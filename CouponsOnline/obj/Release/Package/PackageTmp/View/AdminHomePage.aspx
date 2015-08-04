<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="CouponsOnline.View.AdminHomePage" %>

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
                <a href="#!/home" onclick="SwitchTo('home');">Homellll</a>
            </li>
            <li class="dropdown">
                <a href="#!/Manage Businesses">Manage Businesses</a>
                <ul>
                    <li>
                        <a href="DisplayBusinesses.aspx">Display All</a>
                    </li>
                    <li>
                        <a href="#!/Add Business" onclick="SwitchTo('AddBusiness');">Add Business</a>
                    </li>
                    <li>
                        <a href="#!/Delete Business" onclick="SwitchTo('DeleteBusiness');">Delete Business</a>
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
                <a onclick="SwitchTo('AddCity');">Add City</a>
              
            </li>
            <li class="dropdown">
                <a onclick="SwitchTo('CreateCoupon');">Add Coupon</a>
              
            </li>
            <li class="dropdown">

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
    <div id="home" class="mainBox">
    <h1>welcome!</h1>
    </div>
    <div id="AddBusiness" class="mainBox">
        <asp:TextBox ID="TextBoxBusinessName" runat="server" placeholder="Business Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxAddress" Width="45%" runat="server" placeholder="Address"></asp:TextBox>
            <br />Choose City:<asp:DropDownList ID="DropDownListCities" runat="server" placeholder="City"></asp:DropDownList>        
           <br /> Choose Owner: <asp:DropDownList ID="DropDownListOwnersAdd" runat="server" placeholder="Pick Owner"></asp:DropDownList>
          <br />  Choose Category:<asp:DropDownList ID="DropDownListCategories" runat="server" placeholder="Pick Category"></asp:DropDownList>
          <br />  <asp:Button ID="BtnAddBusiness" runat="server" Text="Add Business" onclick="BtnAddBusiness_Click"/>
    </div>
     <div id="AddCategory" class="mainBox">
        <asp:TextBox ID="TextBoxCat" runat="server" placeholder="Category Name"></asp:TextBox>
        <asp:Button ID="BtnAddCategory" runat="server" Text="Add Category" onclick="BtnAddCategory_Click"/>
    </div>
    
        
    <div id="AddCity" class="mainBox">
        <asp:TextBox ID="TextBoxCity" runat="server" placeholder="City Name"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Add City" onclick="BtnAddCity_Click"/>
        <h1>Current Cities in DB:</h1>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
           
        
     <div id="DeleteBusiness" class="mainBox">
          <<asp:DropDownList ID="DropDownListOwnersDelete" runat="server" placeholder="Pick Owner" AutoPostBack="true" OnSelectedIndexChanged="DropDownListOwner_SelectedIndexChanged"></asp:DropDownList>
           <asp:DropDownList id="DropDownListBusniess" runat="server" placeholder="Pick Busniess" autoPostBack="true" OnSelectedIndexChanged="DropDownListBusniess_SelectedIndexChanged"></asp:DropDownList>
              
    <div id="editBus">
                     <asp:TextBox ID="TextBoxBusinessName1" runat="server" placeholder="Business Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxAddress1" Width="45%" runat="server" placeholder="Address"></asp:TextBox>
        <br />Change City:<asp:DropDownList ID="DropDownListCities1" runat="server" placeholder="City"></asp:DropDownList>        
           
            <br />Change Category:<asp:DropDownList ID="DropDownListCategories1" runat="server" placeholder="Pick Category"></asp:DropDownList>
     
    </div>
            <br />  <asp:Button ID="BtnBusiness" runat="server" Text="Delete Business" onclick="BtnBusiness_Click"/>
                  <asp:Button ID="BtnEditBusiness" runat="server" Text="Edit Business" onclick="BtnEditBusiness_Click"/>
    </div>
        <div id="CreateCoupon" class="mainBox">
        
      

        
        <h1>Create New Coupon</h1>
        <h1>Choose Busniess: </h1>
         <asp:DropDownList id="DropDownListAllBusinesses" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="DropDownListBusniessCreateCoupon_SelectedIndexChanged"></asp:DropDownList>
        
        <asp:TextBox ID="TextBoxName" runat="server" placeholder="Name"></asp:TextBox>
        <asp:TextBox ID="TextBoxDesc" runat="server" placeholder="Description"></asp:TextBox>
        <asp:TextBox ID="TextBoxOrg" runat="server"  placeholder="Original Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxDisc" runat="server" placeholder="New Price"></asp:TextBox>
        <asp:TextBox ID="TextBoxMPU" runat="server" TextMode="Number" placeholder="Maximum Per User"></asp:TextBox>       
        <asp:TextBox ID="TextBoxExp" runat="server" TextMode="Date" placeholder="Last Parchase Date"></asp:TextBox>
        <br />
         <h1>Choose Coupon interests: </h1>
             <asp:checkboxlist id="DropDownListInterests" SelectMethod="" runat="server" SelectionMode="Multiple" Width="500" >
         </asp:checkboxlist>
        <h1>Add New Interest:</h1>
        <asp:TextBox ID="TextBoxInterest" runat="server" placeholder="Interest Name"></asp:TextBox>
        <asp:Button ID="BtnAddInterest" runat="server" Text="Add Interest" onclick="BtnAddInterest_Click1"/>
        <br />                            
        <asp:BulletedList ID="BLerrors" runat="server" ForeColor="Maroon" Font-Size="Small">
        </asp:BulletedList>
        <br />
        <asp:Button ID="BtnCreateCoupon" runat="server" Text="Add Coupon" OnClick="BtnCreateCoupon_Click" />
        
    </div>
    </form>
</body>
</html>
