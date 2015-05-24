using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.PresentationLayer
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string ownerName = Request.Cookies["ActiveUserName"].Value;
                User u = UserController.GetUser(ownerName);
                TextBoxUserName.Text = u.UserName;
                TextBoxPassword.Text = u.Password;
                TextBoxPasswordVal.Text = u.Password;
                TextBoxName.Text = u.Name;
                TextBoxPhoneNum.Text = "0"+u.PhoneKidomet.ToString() + "-" + u.PhoneNum.ToString();
                TextBoxEmail.Text = u.Email;
                UserType type = UserController.GetUserType(ownerName);
                HttpCookie activeUser = new HttpCookie("ActiveUserName", ownerName);
                activeUser.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(activeUser);
                HttpCookie activeDiv = new HttpCookie("ActiveDiv", "home");
                activeDiv.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(activeDiv);

                switch (type)
                {
                    case UserType.Customer:
                        homeLink.HRef = "CustomerHomePage.aspx";
                        break;
                    case UserType.Owner:
                           homeLink.HRef ="OwnerHomePage.aspx";
                        break;
                    case UserType.Admin:
                          homeLink.HRef ="AdminHomePage.aspx";
                        break;
                    default:
                        break;
                }
            }
        }

        //change
        protected void Button1_Click(object sender, EventArgs e)
        {
          
             
                   bool ans= UserController.EditProfile(TextBoxUserName.Text, TextBoxName.Text,
                         TextBoxPhoneNum.Text, TextBoxEmail.Text);
                   if (ans)
                       MessageBox.Show("Profile changed!");
                   else
                       MessageBox.Show("something went wrong :(");
                 
             
            }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ResetPassword.Visible = true;
            profileData.Visible = false;
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxPasswordVal.Text)
            {
                LabelError.Text = "Passwords doesnt match";
                return;
            }
            bool ans = UserController.EditProfile(TextBoxPassword.Text,TextBoxUserName.Text);
            if (ans)
                MessageBox.Show("Password was reset");
            else
                MessageBox.Show("something went wrong :(");
            ResetPassword.Visible = false;
            profileData.Visible = true;
        }
        }
    }
