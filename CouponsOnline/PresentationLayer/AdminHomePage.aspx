<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminHomePage.aspx.cs" Inherits="CouponsOnline.PresentationLayer.AdminHomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/styleMain.css" rel="stylesheet" />
    <script src="../js/script.js"></script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <nav>
        <ul class="nav">
            <li>
                <a href="#!/home" onclick="SwitchTo('home');">Home</a>
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

            </li>
            <li class="lastTab">
                    <a href="Login.aspx">Logout</a>
            </li>
                    <li class="lastTab">
                    <a href="Profile.aspx">Your Profile</a>
                </li>
        </ul>
    </nav>
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
        <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Id">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                        <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:basicConnectionString %>" SelectCommand="SELECT [Name], [Id] FROM [Cities]"></asp:SqlDataSource>
    </div>
           
        
     <div id="DeleteBusiness" class="mainBox">
           <asp:DropDownList ID="DropDownListOwnersDelete" runat="server" placeholder="Pick Owner" AutoPostBack="true" OnSelectedIndexChanged="DropDownListOwner_SelectedIndexChanged"></asp:DropDownList>
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
    </form>
</body>
</html>
