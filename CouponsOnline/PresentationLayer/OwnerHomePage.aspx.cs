using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class OwnerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie usernameCookie = Request.Cookies["ActiveUserName"];
            string userName = usernameCookie.Value;
            if (!this.IsPostBack)
            {
                if (Request.Cookies["ActiveUserName"] != null)
                    Response.Redirect("Login.aspx");
            }

            if (BusinessController.UserHasBusiness(userName))
                Response.Redirect("CreateBusiness.aspx");
        }

        protected void BtnCreateCoupon_Click(object sender, EventArgs e)
        {
            string activeUser = HttpContext.Current.User.Identity.Name;
            int mdp;
            if (!int.TryParse(TextBoxMPU.Text, out mdp))
                return;
            BusinessController.CreateCoupon(TextBoxName.Text, TextBoxOrg.Text, TextBoxDisc.Text,
                activeUser, TextBoxDesc.Text, TextBoxExp.Text, mdp);
        }
    }
}