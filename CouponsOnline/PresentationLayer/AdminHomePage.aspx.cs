using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class AdminHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {
                LoadCategories();
                LoadUsers();
            }
        }

        private void LoadUsers()
        {
            DropDownListOwners.Items.Clear();
            DropDownListOwners.Items.AddRange(UserController.GetAllOwners());
        }

        private void LoadCategories()
        {
            DropDownListCategories.Items.Clear();
            DropDownListCategories.Items.AddRange(BusinessController.GetAllCategories());
        }

        protected void BtnAddBusiness_Click(object sender, EventArgs e)
        {
            string adminUser=Request.Cookies["ActiveUserName"].Value;
            BusinessController.CreateBusiness(adminUser, DropDownListOwners.SelectedValue, TextBoxAddress.Text,
                TextBoxBusinessName.Text, DropDownListCategories.SelectedValue);
        }
        protected void BtnAddCategory_Click(object sender, EventArgs e)
        {
            BusinessController.CreateCategory(TextBoxCat.Text);          
            LoadCategories();
            
        }
        
    }
}