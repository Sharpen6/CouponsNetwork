using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.View
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
                    LoadAllBusiness();
                    LoadInterest();
                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "SwitchTo", "SwitchTo('home')", true);
                }
                else
                    Response.Redirect("Login.aspx");
            }
            else
            {
                //LoadCategories();
                //LoadCities();
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo",
                    "SwitchTo('prevDiv')", true);
            }
        }

        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities1.Items.Clear();
            DropDownListCities.DataTextField = "Text";
            DropDownListCities.DataValueField = "Value";
            DropDownListCities1.DataTextField = "Text";
            DropDownListCities1.DataValueField = "Value";
            DropDownListCities.DataSource = Controller.GetAllCites();
            DropDownListCities.DataBind();
            DropDownListCities1.DataSource = Controller.GetAllCites();
            DropDownListCities1.DataBind();
            GridView1.DataSource = Controller.GetAllCites();
            GridView1.DataBind();
            //DropDownListCities.Items.AddRange(Controller.GetAllCites());
            //DropDownListCities1.Items.AddRange(Controller.GetAllCites());
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
            string fullAddress = TextBoxAddress.Text + " " + DropDownListCities.SelectedItem;
                if (BusinessController.CreateBusiness(adminUser, DropDownListOwnersAdd.SelectedValue, fullAddress,
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
            DropDownListBusniess.DataTextField = "Text";
            DropDownListBusniess.DataValueField = "Value";
            DropDownListBusniess.DataSource= ou.GetBusinesses();
            DropDownListBusniess.DataBind();
            //DropDownListBusniess_SelectedIndexChanged(null, null);
        }
        private void LoadAllBusiness()
        {
            DropDownListAllBusinesses.Items.Clear();
            foreach (ListItem ownerName in DropDownListOwnersAdd.Items)
            {
                Users_Owner ou = UserController.GetOwner(ownerName.Value);
                DropDownListAllBusinesses.Items.AddRange(ou.GetBusinesses());
            }
            
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
                DropDownListCities1.SelectedValue = b.City.Id.ToString();
                DropDownListCategories1.SelectedValue = b.BusinessCategory.Id.ToString();
            }
       
     
        }
        protected void DropDownListBusniessCreateCoupon_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInterest();
        }
        protected void BtnAddInterest_Click1(object sender, EventArgs e)
        {
            if (TextBoxInterest.Text != "")
            {
                Business bus = BusinessController.GetBusiness(DropDownListAllBusinesses.SelectedItem.Value);
                int catID = bus.BusinessCategory.Id;
                Controller.CreateInterest(catID.ToString(), TextBoxInterest.Text);
                LoadInterest();
                Response.Write("<script>alert('Interest added succesfully!')</script>");
                TextBoxInterest.Text = "";
            }
            else
                Response.Write("<script>alert('Fill Interest')</script>");
        
        }

        private void LoadInterest()
        {
            if (DropDownListAllBusinesses.SelectedValue != "")
            {
                DropDownListInterests.Items.Clear();
                Business bus = BusinessController.GetBusiness(DropDownListAllBusinesses.SelectedValue);
                int Categoryid = bus.BusinessCategory.Id;
                //DropDownListInterests.Items.AddRange(BusinessController.GetAllCategoryIntrest(Categoryid));
                DropDownListInterests.DataTextField = "Text";
                DropDownListInterests.DataValueField = "Value";
                DropDownListInterests.DataSource = Controller.GetAllCategoryInterests(Categoryid.ToString());
                DropDownListInterests.DataBind();
            }
        }
        protected void BtnCreateCoupon_Click(object sender, EventArgs e)
        {
            Business bus = BusinessController.GetBusiness(DropDownListAllBusinesses.SelectedValue);

            List<string> selected = new List<string>();
            foreach (ListItem item in DropDownListInterests.Items)
                if (item.Selected) selected.Add(item.Value);

            List<string> err = CouponController.ValidateNewCoupon(TextBoxMPU.Text, TextBoxDisc.Text,
                TextBoxOrg.Text, TextBoxExp.Text, selected);


            if (err.Count > 0)
            {
                BLerrors.Items.Clear();
                foreach (var item in err)
                {
                    BLerrors.Items.Add(new ListItem(item));
                }
            }
            else
            {
                if (bus.CreateCoupon(TextBoxName.Text, TextBoxOrg.Text, TextBoxDisc.Text,
                 TextBoxDesc.Text, TextBoxExp.Text, TextBoxMPU.Text, selected))
                    Response.Write("<script>alert('Coupon " + TextBoxName.Text + " added successfully!')</script>");
                else
                    Response.Write("<script>alert('Coupon " + TextBoxName.Text + " was not added.')</script>");
                TextBoxName.Text = "";
                TextBoxOrg.Text = "";
                TextBoxDisc.Text = "";
                TextBoxDesc.Text = "";
                TextBoxExp.Text = "";
                TextBoxMPU.Text = "";
                DropDownListInterests.ClearSelection();
            }
        }
        

    }
}