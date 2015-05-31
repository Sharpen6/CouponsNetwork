using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class CustomerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string username = Request.Cookies["ActiveUserName"].Value;
                string password = Request.Cookies["ActivePassword"].Value;
                User user = UserController.GetUser(username);
                if (user != null && user.AuthenticateUser(password) &&
                    user.GetUserType()==UserType.Customer)
                {

                    ScriptManager.RegisterStartupScript(this, GetType(),
                        "SwitchTo", "SwitchTo('home')", true);
                }
                else
                    Response.Redirect("Login.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(),
                    "SwitchTo", "SwitchTo('prevDiv')", true);
            }
        }
    }
}