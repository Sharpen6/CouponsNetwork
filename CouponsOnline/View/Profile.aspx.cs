using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CouponsOnline.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["ActiveUserName"].Value;
            User u = UserController.GetUser(currentUser);
            UserType type = u.GetUserType();
            
            if (!IsPostBack)
            {                
                TextBoxUserName.Text = u.UserName;
                TextBoxPassword.Text = u.Password;
                TextBoxPasswordVal.Text = u.Password;
                TextBoxName.Text = u.Name;
                TextBoxPhoneNum.Text = u.PhoneNum;
                TextBoxEmail.Text = u.Email;

                if (type == UserType.Customer)
                {
                    DropDownListInterests.Items.Clear();
                    Users_Customer uc = UserController.GetCustomer(u.UserName);
                    ListItem[] items = new ListItem[uc.Interests.Count];
                    int i = 0;
                    foreach (var item in uc.Interests)
                    {
                        items[i++] = new ListItem(item.Description, item.Id.ToString());
                    }
                    DropDownListInterests.DataSource = items;
                    DropDownListInterests.DataTextField = "Text";
                    DropDownListInterests.DataValueField = "Value";
                    DropDownListInterests.DataBind();
                }



                HttpCookie activeUser = new HttpCookie("ActiveUserName", currentUser);
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
                        homeLink.HRef = "OwnerHomePage.aspx";
                        break;
                    case UserType.Admin:
                        homeLink.HRef = "AdminHomePage.aspx";
                        break;
                    default:
                        break;
                }
            }
        }
        //change
        protected void Button1_Click(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["ActiveUserName"].Value;
            User u = UserController.GetUser(currentUser);

            UserType type = u.GetUserType();
            List<string> err = null;
            List<string> selectedInterests = new List<string>();

            if (type == UserType.Customer)
            {

                foreach (ListItem item in DropDownListInterests.Items)
                {
                    if (item.Selected) selectedInterests.Add(item.Value);
                }
                err = UserController.ValidateInformationChanges(TextBoxPhoneNum.Text, TextBoxEmail.Text, selectedInterests);
            }
            else
            {
                err = UserController.ValidateInformationChanges(TextBoxPhoneNum.Text, TextBoxEmail.Text);
            }



            if (err.Count > 0)
            {
                BLerrors.Items.Clear();
                foreach (var item in err)
                {
                    BLerrors.Items.Add(new ListItem(item));
                }
            }
            else
            {
                if (type == UserType.Customer)
                {
                    if (u.ChangeDetails(TextBoxName.Text,TextBoxPhoneNum.Text,
                        TextBoxEmail.Text,selectedInterests))
                    {
                        ClientScript.RegisterStartupScript(
                           this.GetType(), "myalert", "alert('Your account has been edited!');", true);
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(
                           this.GetType(), "myalert", "alert('Could not edit your account.');", true);
                    }
                }
                else if (u.ChangeDetails(TextBoxName.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text))
                {
                    ClientScript.RegisterStartupScript(
                       this.GetType(), "myalert", "alert('Your account has been edited!');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(
                       this.GetType(), "myalert", "alert('Could not edit your account.');", true);
                }
            }
        }
        protected void reset_Click(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["ActiveUserName"].Value;
            User u = UserController.GetUser(currentUser);
            if (TextBoxPassword.Text=="" || (TextBoxPassword.Text != TextBoxPasswordVal.Text))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Passwords doesnt match');", true);
                return;
            }
            else if (u.ChangePassword(TextBoxPassword.Text))
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Your password has been changed');", true);
                Response.Redirect("Login.aspx");
            }
            else
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Could not change your password');", true);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["ActiveUserName"].Value;
            User u = UserController.GetUser(currentUser);
            if (u.Deactivate()) {
                    ClientScript.RegisterStartupScript(
                this.GetType(), "myalert", "alert('You account has been deleted.');", true);
                Response.Redirect("Login.aspx");
            }
            else
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Could not delete your account.');", true);
        }
    }
}
