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
            string id = selectedRow.Cells[9].Text;
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

        protected void DropDownListBusniess_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridVresults.DataSource = null;
            GridVresults.DataBind();
        }
      
  
    }
}