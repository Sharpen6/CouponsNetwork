using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline
{
    public partial class SearchCoupon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!this.IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo", "SwitchTo('home')", true);
                LoadCategories();
                LoadCities();
            }
        }

        private void LoadCategories()
        {
            DropDownListCategory.Items.Clear();
            DropDownListCategory.Items.Add(new ListItem(""));
            DropDownListCategory.Items.AddRange(BusinessController.GetAllCategories());
        }

        private void SearchByCategory()
        {


        }
        private void Search()
        {
            string city = DropDownListCities.SelectedValue;
            double coordinateX = 0;
            double coordinateY = 0;
            if (TextBox1.Text != "" && !double.TryParse(TextBox1.Text, out coordinateX))
                return;
            if (TextBox2.Text != "" && !double.TryParse(TextBox2.Text, out coordinateY))
                return;
            List<ListItem> selectedInterests = new List<ListItem>();
            foreach (ListItem item in DropDownListInterests.Items)
                if (item.Selected) selectedInterests.Add(item);
            GridVresults.DataSource = CouponController.FindCoupons(city, selectedInterests, coordinateX, coordinateY);
            GridVresults.DataBind();
        }
        private void SearchByCords()
        {
            throw new NotImplementedException();
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

            DropDownListInterests.DataSource = BusinessController.GetAllInterests(DropDownListCategory.SelectedValue);
            DropDownListInterests.DataBind();

        }

        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities.Items.Add(new ListItem(""));
            DropDownListCities.Items.AddRange(BusinessController.GetAllCites());
        }
        
        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInterest();
            Search();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        
    }
}