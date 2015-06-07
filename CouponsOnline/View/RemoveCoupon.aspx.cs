using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.View
{
    public partial class AddCoupon : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", "SwitchTo('home')", true);
                LoadBusiness();
                EditCoupon.Visible = false;

            }
        }

        private void LoadBusiness()
        {
            DropDownListBusniess.Items.Clear();
            string ownerName = Request.Cookies["ActiveUserName"].Value;
            Users_Owner ou = UserController.GetOwner(ownerName);
            DropDownListBusniess.Items.AddRange(ou.GetBusinesses());
        }

        public void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchByBusiness();
        }
        
        public void SearchByBusiness()
        {
            Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);
            GridVresults.DataSource = bus.GetCoupons();
            GridVresults.DataBind();
        }


        protected void GridVresults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridVresults.Rows[index];
            string id = selectedRow.Cells[10].Text;
            Coupon cop = CouponController.GetCoupon(id);
            if (e.CommandName == "RemoveCoupon")
            {
                
                bool result = cop.DeleteCoupon();
                string Busniess = DropDownListBusniess.SelectedValue;

                if (result)
                    MessageBox.Show("Coupon removed");
                else
                    MessageBox.Show("can't remove coupon- already been Purchase");
                GridVresults.DataSource = null;
                GridVresults.DataBind();
                SearchByBusiness();
            }
            else
            {


                TextBoxExp.Text = cop.ExperationDate;
                EditCoupon.Visible = true;
                home.Visible = false;
                TextBoxName.Text = selectedRow.Cells[2].Text;
                TextBoxOrg.Text = selectedRow.Cells[4].Text;
                TextBoxDisc.Text = selectedRow.Cells[5].Text;
                TextBoxDesc.Text = selectedRow.Cells[3].Text;
               // TextBoxExp.Text = selectedRow.Cells[6].Text;
                TextBoxMPU.Text = selectedRow.Cells[9].Text;
                copId.Text = selectedRow.Cells[10].Text;
                DropDownListInterests.Items.Clear();
                LoadInterest();
                ICollection<Interest> t = cop.Interests;
                foreach (Interest item in t)
                {
                    DropDownListInterests.Items.FindByText(item.Description).Selected = true;
                }


            }
        }
        
        private void LoadInterest()
        {
            if (DropDownListBusniess.SelectedValue != "")
            {
                DropDownListInterests.Items.Clear();
                Business bus = BusinessController.GetBusiness(DropDownListBusniess.SelectedValue);
                int Categoryid = bus.BusinessCategory.Id;
                //DropDownListInterests.Items.AddRange(BusinessController.GetAllCategoryIntrest(Categoryid));
                DropDownListInterests.DataTextField = "Text";
                DropDownListInterests.DataValueField = "Value";
                DropDownListInterests.DataSource = Controller.GetAllCategoryInterests(Categoryid.ToString());
                DropDownListInterests.DataBind();
            }
        }

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridVresults.DataSource = null;
            GridVresults.DataBind();
        }

        protected void BtnEditCoupon_Click(object sender, EventArgs e)
        {
            HttpCookie usernameCookie = Request.Cookies["ActiveUserName"];
            string selectedBusiness = DropDownListBusniess.SelectedItem.Text;
            List<ListItem> selectedItems = new List<ListItem>();
            List<string> selected = new List<string>();
            foreach (ListItem item in DropDownListInterests.Items)
            {
                if (item.Selected) selected.Add(item.Value);
                if (item.Selected) selectedItems.Add(item);
            }

            List<string> errors = (CouponController.ValidateNewCoupon(TextBoxMPU.Text, TextBoxDisc.Text, TextBoxOrg.Text, TextBoxExp.Text, selected));
            if (errors.Count > 0)
            {
                BLerrors.Items.Clear();
                foreach (var item in errors)
                {
                    BLerrors.Items.Add(item);
                }
                return;
            }
            int mdp = int.Parse(TextBoxMPU.Text);
            double newPrice = double.Parse(TextBoxDisc.Text);
            double orgPrice = double.Parse(TextBoxOrg.Text);
            
            Coupon cop = CouponController.GetCoupon(copId.Text);
            cop.EditCoupon(TextBoxName.Text, orgPrice, newPrice, TextBoxDesc.Text, TextBoxExp.Text, mdp, selectedItems);
            Response.Write("<script>alert('Coupon " + TextBoxName.Text + " Edit successfully!'</script>");
            TextBoxName.Text = "";
            TextBoxOrg.Text = "";
            TextBoxDisc.Text = "";
            TextBoxDesc.Text = "";
            TextBoxExp.Text = "";
            TextBoxMPU.Text = "";
            home.Visible = true;
           
            EditCoupon.Visible = false;
            SearchByBusiness();

        }



    }
}