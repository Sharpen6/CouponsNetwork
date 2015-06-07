using CouponsOnline.BusinessLayer.Presenters;
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



        private void SearchByCategory()
        {


        }
        private void Search()
        {
            GridVresults.DataSource = null;
            GridVresults.DataBind();
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
            // this function applies all the fields togather
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

        
        protected void DropDownListCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadInterest();
            Search();
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void DropDownListInterests_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        protected void DropDownListCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridVresults.DataSource = null;           
            GridVresults.DataBind();
            
            Search();
         // DropDownListCategory.ClearSelection();
          //  DropDownListInterests.Items.Clear();
        }
        private void LoadInterest()
        {
            DropDownListInterests.Items.Clear();
            DropDownListInterests.DataTextField = "Text";
            DropDownListInterests.DataValueField = "Value";
            DropDownListInterests.DataSource =
            Controller.GetAllCategoryInterests(DropDownListCategory.SelectedValue);

            DropDownListInterests.DataBind();
            foreach (ListItem item in DropDownListInterests.Items)
            {
                item.Selected = true;
            }
        }
        private void LoadCities()
        {
            DropDownListCities.Items.Clear();
            DropDownListCities.Items.Add(new ListItem(""));
            DropDownListCities.DataTextField = "Text";
            DropDownListCities.DataValueField = "Value";
            DropDownListCities.Items.AddRange(Controller.GetAllCites());

        }
        private void LoadCategories()
        {
            DropDownListCategory.Items.Clear();
            DropDownListCategory.Items.Add(new ListItem(""));
            DropDownListCategory.Items.AddRange(Controller.GetAllCategories());
            DropDownListCategory.DataTextField = "Text";
            DropDownListCategory.DataValueField = "Value";
        }
        
    }
}