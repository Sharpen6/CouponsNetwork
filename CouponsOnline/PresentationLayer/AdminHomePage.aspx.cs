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
            ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", "SwitchTo('prevDiv')", true);
            if (!IsPostBack) {
                LoadCategories();
                LoadUsers();
                LoadCities();
            }
        }

        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities.Items.AddRange(BusinessController.GetAllCites());
        }

        private void LoadUsers()
        {

            DropDownListOwners.Items.Clear(); 
            DropDownListOwner.Items.Clear();
            DropDownListOwner.Items.Add("");
            DropDownListOwners.Items.Add("");
            DropDownListOwners.Items.AddRange(UserController.GetAllOwners());
           
            DropDownListOwner.Items.AddRange(UserController.GetAllOwners());
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
                TextBoxBusinessName.Text, DropDownListCategories.SelectedValue, DropDownListCities.SelectedValue);
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

        }
        private void LoadBusiness()
        {
            DropDownListBusniess.Items.Clear();
            string ownerName = DropDownListOwner.SelectedValue;
            DropDownListBusniess.Items.AddRange(BusinessController.GetAllBusnisesId(ownerName));
        }

        protected void BtnBusiness_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this Business ?",
      "Critical Warning",
      MessageBoxButtons.YesNo,
      MessageBoxIcon.Warning,
      MessageBoxDefaultButton.Button1,
      MessageBoxOptions.RightAlign,
      true);

            if (result == DialogResult.Yes)
            {
                bool ans = BusinessController.deleteBusiness( Int32.Parse(  DropDownListBusniess.SelectedItem.Value));
                if (ans)
                    MessageBox.Show("Busniess has been deleted");
                else
                    MessageBox.Show("something went wrong :(");

            }
        }

    }
}