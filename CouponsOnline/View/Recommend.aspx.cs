using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CouponsOnline.BusinessLayer.Presenters;
using CouponsOnline.BusinessLayer;


namespace CouponsOnline.View
{
    public partial class Recommend : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void PrintRecommendations()
        {
           GridVresults.DataSource = CouponController.RecommendCoupons();
           GridVresults.DataBind();
        }
        protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            CouponController.SetRecommendationType(RecType.Location);
        }

        protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            CouponController.SetRecommendationType(RecType.Category);
        }

        protected void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            CouponController.SetRecommendationType(RecType.Both);
        }
    }
}