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
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo",
              "SwitchTo('home')", true);
                string currentUser = Request.Cookies["ActiveUserName"].Value;
                User u = UserController.GetUser(currentUser);
                TextBoxUserName.Text = u.UserName;
                TextBoxPassword.Text = u.Password;
                TextBoxPasswordVal.Text = u.Password;
                TextBoxName.Text = u.Name;
                TextBoxPhoneNum.Text = "0"+u.PhoneKidomet.ToString() + "-" + u.PhoneNum.ToString();
                TextBoxEmail.Text = u.Email;

                UserType type = u.GetUserType();
                
                if (type == UserType.Customer)
                {
                    DropDownListInterests.Items.Clear();
                    DropDownListInterests.DataSource = BusinessController.GetAllUserInterests(u.UserName);
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
                           homeLink.HRef ="OwnerHomePage.aspx";
                        break;
                    case UserType.Admin:
                          homeLink.HRef ="AdminHomePage.aspx";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "SwitchTo",
              "SwitchTo('prevDiv')", true);
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
                err = UserController.ValidateRegisteration(TextBoxUserName.Text, TextBoxPassword.Text,
                TextBoxPasswordVal.Text, TextBoxPhoneNum.Text,
                TextBoxEmail.Text, TextBoxName.Text, selectedInterests);
            }
            else
            {
                err = UserController.ValidateRegisteration(TextBoxUserName.Text, TextBoxPassword.Text,
                TextBoxPasswordVal.Text, TextBoxPhoneNum.Text,
                TextBoxEmail.Text, TextBoxName.Text);
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
                if (UserController.EditProfile(TextBoxUserName.Text, TextBoxName.Text,
                          TextBoxPhoneNum.Text, TextBoxEmail.Text, selectedInterests))
                {
                    ClientScript.RegisterStartupScript(
                       this.GetType(), "myalert", "alert('Your account has been edited!');", true);
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    ClientScript.RegisterStartupScript(
                       this.GetType(), "myalert", "alert('Could not edit your account.');", true);
                }
            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(
                                   this.GetType(), "myalert", "SwitchTo('ResetPassword');", true);
        }

        protected void reset_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxPasswordVal.Text)
            {
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Passwords doesnt match');", true);
                return;
            }
            if (UserController.EditProfile(TextBoxPassword.Text,TextBoxUserName.Text))
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Your password has been changed');", true);
            else
                ClientScript.RegisterStartupScript(
                    this.GetType(), "myalert", "alert('Could not change your password');", true);

            ClientScript.RegisterStartupScript(
    this.GetType(), "myalert", "SwitchTo('home');", true);
        }

        protected void delete_Click(object sender, EventArgs e)
        {
          DialogResult result=     MessageBox.Show("Are you sure ypu want to delete your account?",
		"Critical Warning",
		MessageBoxButtons.YesNo,
		MessageBoxIcon.Warning,
		MessageBoxDefaultButton.Button1,
		MessageBoxOptions.RightAlign,
		true);
	  
	        if (result == DialogResult.Yes)
            {
                bool ans = UserController.deleteProfile( TextBoxUserName.Text);
                if (ans)
                    MessageBox.Show("your account has been deleted");
                else
                    MessageBox.Show("something went wrong :(");
                Response.Redirect("Login.aspx");
            }
        }
        }
    }
