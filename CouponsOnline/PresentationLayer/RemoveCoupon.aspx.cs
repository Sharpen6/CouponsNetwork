using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.PresentationLayer
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
            DropDownListBusniess.Items.AddRange(BusinessController.GetAllBusnisesId(ownerName));
        }
        public void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchByBusnies();
        }
        public void SearchByBusnies()
        {
            string Busniess = DropDownListBusniess.SelectedValue;
            GridVresults.DataSource = CouponController.GetCouponsByBusniess(Busniess);
            GridVresults.DataBind();
        }


        protected void GridVresults_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow selectedRow = GridVresults.Rows[index];
            if (e.CommandName == "RemoveCoupon")
            {
                string id = selectedRow.Cells[10].Text;
                bool result = CouponController.removeCoupon(id);
                string Busniess = DropDownListBusniess.SelectedValue;

                if (result)
                    MessageBox.Show("Coupon removed");
                else
                    MessageBox.Show("can't remove coupon- already been Purchase");
                GridVresults.DataSource = null;
                GridVresults.DataBind();
                SearchByBusnies();
            }
            else
            {
                TextBoxExp.Text = CouponController.FindCouponExpDate(selectedRow.Cells[10].Text);
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
                ICollection<Interest> t = CouponController.FindCopInterest(copId.Text);
                foreach (Interest item in t)
                {
                    DropDownListInterests.Items.FindByText(item.Description).Selected = true;


                }


            }
        }
        
        private void LoadInterest()
        {
            DropDownListInterests.Items.Clear();
            string Busniessid = DropDownListBusniess.SelectedValue;
            if (Busniessid != "")
            {
                int Categoryid = BusinessController.FindBusinessCategory(Busniessid);
                //DropDownListInterests.Items.AddRange(BusinessController.GetAllCategoryIntrest(Categoryid));
                DropDownListInterests.DataSource = BusinessController.GetAllCategoryInterests(Categoryid.ToString());
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

            int mdp;
            double orgPrice;
            double newPrice;
            if (!int.TryParse(TextBoxMPU.Text, out mdp))
            {
                MessageBox.Show("Missing Values! ");
                return;
            }
            if (!double.TryParse(TextBoxDisc.Text, out newPrice))
            {
                MessageBox.Show("Discount has to be Number ");
                return;
            }
            if (!double.TryParse(TextBoxOrg.Text, out orgPrice))
            {
                MessageBox.Show("Price has to be Number ");
                return;
            }
            if (TextBoxExp.Text=="" || DateTime.Parse(TextBoxExp.Text) < DateTime.Now)
            {
                MessageBox.Show("Experation Date is Wrong ");
                return;
            }
            List<ListItem> selected = new List<ListItem>();
            foreach (ListItem item in DropDownListInterests.Items)
                if (item.Selected) selected.Add(item);
            CouponController.EditCoupon(Int32.Parse(copId.Text), TextBoxName.Text, orgPrice, newPrice, TextBoxDesc.Text, TextBoxExp.Text, mdp, selected);
            MessageBox.Show("Coupon " + TextBoxName.Text + " Edit successfully!");
            TextBoxName.Text = "";
            TextBoxOrg.Text = "";
            TextBoxDisc.Text = "";
            TextBoxDesc.Text = "";
            TextBoxExp.Text = "";
            TextBoxMPU.Text = "";
            home.Visible = true;
           
            EditCoupon.Visible = false;
            SearchByBusnies();

        }



    }
}