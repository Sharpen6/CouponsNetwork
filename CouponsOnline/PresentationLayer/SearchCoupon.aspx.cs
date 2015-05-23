using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class SearchCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", "SwitchTo('home')", true);
            LoadInterest();
            LoadCities();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchByCity();
        }
        public void SearchByCity()
        {
            string city = DropDownListCities.SelectedValue;
            GridVresults.DataSource = CouponController.GetCouponsByCity(city);
            GridVresults.DataBind();
        }
        private void LoadInterest()
        {
            DropDownListInterests.Items.Clear();
            DropDownListInterests.DataSource = BusinessController.GetAllCategories();
            DropDownListInterests.DataBind();

        }
        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities.Items.AddRange(BusinessController.GetAllCites());
        }
    }
}