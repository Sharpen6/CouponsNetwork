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

        protected void btnLogin_Click(object sender, EventArgs e)     
        {
            string username = TextBox1.Text;
            string password = TextBox2.Text;
            User user = UserController.GetUser(username);

            if (user!=null && user.AuthenticateUser(password))
            {
                UserType type = user.GetUserType();

                //Add login information for this user

                HttpCookie activeUser = new HttpCookie("ActiveUserName", username);
                HttpCookie activePassword = new HttpCookie("ActivePassword", password);
                HttpCookie activeDiv = new HttpCookie("ActiveDiv", "home");
                              
                activeUser.Expires = DateTime.Now.AddDays(30);
                activePassword.Expires = DateTime.Now.AddDays(30);
                activeDiv.Expires = DateTime.Now.AddDays(1);

                Response.Cookies.Add(activePassword);
                Response.Cookies.Add(activeUser);
                Response.Cookies.Add(activeDiv);
                 
                //
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
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", 
                    "alert('User name/Password is wrong');", true);
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}