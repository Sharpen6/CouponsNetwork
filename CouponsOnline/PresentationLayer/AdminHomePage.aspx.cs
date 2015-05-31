﻿using CouponsOnline.BusinessLayer.Controllers;
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
            DropDownListCities.Items.AddRange(BusinessController.GetAllCites());
            DropDownListCities1.Items.AddRange(BusinessController.GetAllCites());
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
            DropDownListCategories.Items.AddRange(BusinessController.GetAllCategories());
            DropDownListCategories1.Items.AddRange(BusinessController.GetAllCategories());
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
            BusinessController.CreateCategory(TextBoxCat.Text);          
            LoadCategories();
            
        }
        protected void BtnAddCity_Click(object sender, EventArgs e)
        {
            BusinessController.AddCity(TextBoxCity.Text);          
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
            DropDownListBusniess.Items.AddRange(BusinessController.GetAllBusnisesId(ownerName));
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
            string adminUser = Request.Cookies["ActiveUserName"].Value;
            int selectedBusinessID = int.Parse(DropDownListBusniess.SelectedItem.Value);
            BusinessController.EditBusniess(adminUser,Int32.Parse(DropDownListBusniess.SelectedItem.Value), TextBoxAddress1.Text,
                TextBoxBusinessName1.Text, DropDownListCategories.SelectedValue, DropDownListCities.SelectedValue);
        }

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownListBusniess.Items.Count != 0)
            {

                Business b = BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);
                TextBoxAddress1.Text = b.Address;
                TextBoxBusinessName1.Text = b.Name;
                DropDownListCities1.SelectedValue = BusinessController.Getcity(b.BusinessID);
                DropDownListCategories1.SelectedValue = BusinessController.GetCategoty(b.BusinessID);
            }
       
     
        }

    }
}