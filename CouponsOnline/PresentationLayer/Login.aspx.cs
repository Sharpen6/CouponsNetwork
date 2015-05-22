using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)     
        {
            if (UserController.AuthenticateUser(TextBox1.Text, TextBox2.Text))
            {
                UserType type = UserController.GetUserType(TextBox1.Text);
                HttpCookie activeUser = new HttpCookie("ActiveUserName", TextBox1.Text);
                activeUser.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(activeUser);
                HttpCookie activeDiv = new HttpCookie("ActiveDiv", "home");
                activeDiv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(activeDiv);

                switch (type)
                {
                    case UserType.Customer:
                        Response.Redirect("CustomerHomePage.aspx");
                        break;
                    case UserType.Owner:
                        Response.Redirect("OwnerHomePage.aspx");
                        break;
                    case UserType.Admin:
                        Response.Redirect("AdminHomePage.aspx");
                        break;
                    default:
                        break;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}