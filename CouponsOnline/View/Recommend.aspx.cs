using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using CouponsOnline.BusinessLayer.Presenters;
using CouponsOnline.BusinessLayer;


namespace CouponsOnline.View
{
    public partial class Recommend : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string username = Request.Cookies["ActiveUserName"].Value;
                string password = Request.Cookies["ActivePassword"].Value;
                
                User user = UserController.GetUser(username);
                if (user != null && user.AuthenticateUser(password) &&
                    user.GetUserType() != UserType.Admin)
                {
                    CouponController.SetRecommendationType(RecType.Location);
                }
                else
                    Response.Redirect("Login.aspx");
            }
            
        }

        public void PrintRecommendations(object sender, EventArgs e)
        {
            double longtitude;
            double latitude;

            string valLong = hidden1.Value;
            string valLat = hidden2.Value;

            if (!double.TryParse(valLong, out longtitude))
                longtitude = 0;
            if (!double.TryParse(valLat, out latitude))
                latitude = 0;

            string[] args = new string[3];
            args[0] = longtitude.ToString();
            args[1] = latitude.ToString();
            args[2] = Request.Cookies["ActiveUserName"].Value;

           GridVresults.DataSource = CouponController.RecommendCoupons(args);
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