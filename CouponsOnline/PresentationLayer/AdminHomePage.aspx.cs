using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.PresentationLayer
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                string username = Request.Cookies["ActiveUserName"].Value;
                string password = Request.Cookies["ActivePassword"].Value;
                User user = UserController.GetUser(username);
                if (user != null && user.AuthenticateUser(password) &&
                    user.GetUserType() == UserType.Admin)
                {
                    LoadCategories();
                    LoadUsers();
                    LoadCities();
                    LoadBusiness();

                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "SwitchTo", "SwitchTo('home')", true);
                }
                else
                    Response.Redirect("Login.aspx");
            }
            else
            {
                LoadCategories();
                LoadCities();
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo",
                    "SwitchTo('prevDiv')", true);
            }
        }

        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities1.Items.Clear();
            DropDownListCities.Items.AddRange(Controller.GetAllCites());
            DropDownListCities1.Items.AddRange(Controller.GetAllCites());
        }

        private void LoadUsers()
        {

            DropDownListOwnersAdd.Items.Clear();
            DropDownListOwnersDelete.Items.Clear();
            Dictionary<User, UserType> allUsers = UserController.GetAllUsers();
            foreach (var item in allUsers)
            {
                if (item.Value==UserType.Owner)
                {
                    DropDownListOwnersAdd.Items.Add(new ListItem(item.Key.UserName));
                    DropDownListOwnersDelete.Items.Add(new ListItem(item.Key.UserName));
                }
            }
        }

        private void LoadCategories()
        {
            DropDownListCategories.Items.Clear();
            DropDownListCategories1.Items.Clear();
            DropDownListCategories.Items.AddRange(Controller.GetAllCategories());
            DropDownListCategories1.Items.AddRange(Controller.GetAllCategories());
        }

        protected void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            string adminUser=Request.Cookies["ActiveUserName"].Value;
            if (BusinessController.CreateBusiness(adminUser, DropDownListOwnersAdd.SelectedValue, TextBoxAddress.Text,
                TextBoxBusinessName.Text, DropDownListCategories.SelectedValue, DropDownListCities.SelectedValue))
                Response.Write("<script>alert('Business Successfully created!')</script>");
            else
                Response.Write("<script>alert('Could not create business.')</script>");
                           
            LoadBusiness();
        }
        protected void BtnAddCategory_Click(object sender, EventArgs e)
        {
            Controller.CreateCategory(TextBoxCat.Text);          
            LoadCategories();
            
        }
        protected void BtnAddCity_Click(object sender, EventArgs e)
        {
            Controller.CreateCity(TextBoxCity.Text);          
            LoadCities();
            
        }

        protected void DropDownListOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBusiness();
            //DropDownListBusniess_SelectedIndexChanged(null, null);

        }
        private void LoadBusiness()
        {
            DropDownListBusniess.Items.Clear();
            string ownerName = DropDownListOwnersAdd.SelectedValue;
            Users_Owner ou = UserController.GetOwner(ownerName);
            DropDownListBusniess.Items.AddRange(ou.GetBusinesses());
            //DropDownListBusniess_SelectedIndexChanged(null, null);
        }

        protected void BtnBusiness_Click(object sender, EventArgs e)
        {
            Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedItem.Value);
            if (bus.Deactivate())
                Response.Write("<script>alert('Busniess has been deleted!')</script>");
            else
                Response.Write("<script>alert('Could not delete your business.')</script>");              
            LoadBusiness();
        }

        protected void BtnEditBusiness_Click(object sender, EventArgs e)
        {
            Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedItem.Value);
            bus.ChangeDetails(TextBoxAddress1.Text, TextBoxBusinessName1.Text, 
                DropDownListCategories.SelectedValue, DropDownListCities.SelectedValue);
        }

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListBusniess.Items.Count != 0)
            {

                Business b = BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);
                TextBoxAddress1.Text = b.Address;
                TextBoxBusinessName1.Text = b.Name;
                DropDownListCities1.SelectedValue = b.GetCity().ToString();
                DropDownListCategories1.SelectedValue = b.GetCategory().ToString();
            }
       
     
        }

    }
}