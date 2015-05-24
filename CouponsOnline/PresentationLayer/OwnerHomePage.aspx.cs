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
    public partial class OwnerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // 

            ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", "SwitchTo('prevDiv')", true);

            

            if (!this.IsPostBack)
            {
                LoadBusiness();
                DropDownListBusniess.SelectedIndex = 0;
                LoadCategory();
                LoadInterest();
                
                HttpCookie usernameCookie = Request.Cookies["ActiveUserName"];
                string userName = usernameCookie.Value;
                //if (Request.Cookies["ActiveUserName"] != null)
                //    Response.Redirect("Login.aspx");
            }            
          //  if (BusinessController.UserHasBusiness(userName))
             //   Response.Redirect("CreateBusiness.aspx");
        }

        protected void BtnCreateCoupon_Click(object sender, EventArgs e)
        {
            HttpCookie usernameCookie = Request.Cookies["ActiveUserName"];
            string activeUser = DropDownListBusniess.SelectedItem.Text;
     
            int mdp;
            if (!int.TryParse(TextBoxMPU.Text, out mdp))
            {
                MessageBox.Show("Missing Values! ");
                return;
            }
            List<ListItem> selected = new List<ListItem>();
            foreach (ListItem item in DropDownListInterests.Items)
                if (item.Selected) selected.Add(item);
            BusinessController.CreateCoupon(TextBoxName.Text, TextBoxOrg.Text, TextBoxDisc.Text,
                activeUser, TextBoxDesc.Text, TextBoxExp.Text, mdp, selected);
            MessageBox.Show("Coupon " + TextBoxName.Text + " added successfully! ");
        }
        
    
        private void LoadBusiness()
        {
            DropDownListBusniess.Items.Clear();
            string ownerName = Request.Cookies["ActiveUserName"].Value;
            
            DropDownListBusniess.Items.AddRange(BusinessController.GetAllBusnisesId(ownerName));
            LoadCategory();
        }

        private void LoadCategory()
        {
            string ownerName = Request.Cookies["ActiveUserName"].Value;
            DropDownListCategory.Items.Clear();
        
            DropDownListCategory.Items.AddRange(BusinessController.GetAllBusnisesCategory(ownerName).Distinct().ToArray());
        }
        private void LoadInterest()
        {
            DropDownListInterests.Items.Clear();
            string Busniessid = DropDownListBusniess.SelectedValue;
            if (Busniessid != "") {
                int Categoryid = BusinessController.FindBusinessCategory(Busniessid);
            //DropDownListInterests.Items.AddRange(BusinessController.GetAllCategoryIntrest(Categoryid));
                DropDownListInterests.DataSource = BusinessController.GetAllCategoryIntrest(Categoryid);
                DropDownListInterests.DataBind();
                }
        }

     

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInterest();
        }

        protected void BtnAddInterest_Click1(object sender, EventArgs e)
        {
            BusinessController.createInterest(DropDownListCategory.SelectedValue, TextBoxInterest.Text);
        }
    }
}