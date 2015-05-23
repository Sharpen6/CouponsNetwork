using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            SearchByCity();
        }
        public void SearchByCity()
        {
            string Busniess = DropDownListBusniess.SelectedValue;
            GridVresults.DataSource = CouponController.GetCouponsByBusniess(Busniess);
            GridVresults.DataBind();
        }
      
  
    }
}