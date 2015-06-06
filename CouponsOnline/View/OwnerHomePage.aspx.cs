using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.View
{
    public partial class OwnerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {                
                string username = Request.Cookies["ActiveUserName"].Value;
                string password = Request.Cookies["ActivePassword"].Value;
                User user = UserController.GetUser(username);
                if (user != null && user.AuthenticateUser(password) &&
                    user.GetUserType() == UserType.Owner)
                {
                    LoadBusiness();
                    DropDownListBusniess.SelectedIndex = 0;
                    LoadInterest();
                    ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo",
                   "SwitchTo('home')", true);
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            else
            {
                LoadInterest();
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", 
                    "SwitchTo('prevDiv')", true);
            }
        }

        protected void BtnCreateCoupon_Click(object sender, EventArgs e)
        {
            Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);

            List<string> selected = new List<string>();
            foreach (ListItem item in DropDownListInterests.Items)
                if (item.Selected) selected.Add(item.Value);

            List<string> err = CouponController.ValidateNewCoupon(TextBoxMPU.Text, TextBoxDisc.Text,
                TextBoxOrg.Text, TextBoxExp.Text);


           if (err.Count>0) {
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
           
        private void LoadBusiness()
        {
            DropDownListBusniess.Items.Clear();
            string ownerName = Request.Cookies["ActiveUserName"].Value;
            Users_Owner ou = UserController.GetOwner(ownerName);
            DropDownListBusniess.Items.AddRange(ou.GetBusinesses());
            //LoadCategory();
        }
        private void LoadInterest()
        {
            if (DropDownListBusniess.SelectedValue != "")
            {
                DropDownListInterests.Items.Clear();
                Business bus =  BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);
                int Categoryid = bus.BusinessCategory.Id;
            //DropDownListInterests.Items.AddRange(BusinessController.GetAllCategoryIntrest(Categoryid));
                DropDownListInterests.DataSource = Controller.GetAllCategoryInterests(Categoryid.ToString());
                DropDownListInterests.DataBind();
            }
        }

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInterest();
        }

        protected void BtnAddInterest_Click1(object sender, EventArgs e)
        {
            if (TextBoxInterest.Text != "")
            {
                Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedItem.Value);
                int catID = bus.BusinessCategory.Id;
                Controller.CreateInterest(catID.ToString(), TextBoxInterest.Text);
                LoadInterest();
                Response.Write("<script>alert('Interest added succesfully!')</script>");      
                TextBoxInterest.Text = "";
            }
            else
                Response.Write("<script>alert('Fill Interest')</script>");
        }
    }
}