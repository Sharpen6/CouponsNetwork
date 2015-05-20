using CouponsOnline.BusinessLayer.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        protected void SendButton_Click(object sender, EventArgs e)
        {
            if (TextBoxPassword.Text != TextBoxPasswordVal.Text)
            {
                LabelError.Text = "Passwords doesnt match";
                return;
            }
            switch (radioBtnUserType.SelectedIndex)
            {
                case 0:
                    if (UserController.CreateNewCustomer(TextBoxUserName.Text, TextBoxName.Text,
                        TextBoxPassword.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text))
                    {
                        Response.Redirect("Login.aspx");
                    }
                    break;
                case 1:
                    if (UserController.CreateNewOwner(TextBoxUserName.Text, TextBoxName.Text,
                        TextBoxPassword.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text))
                    {
                        Response.Redirect("Login.aspx");
                    }
                    break;
                default:
                    break;
            }
            
        }

        protected void btnCreateAdmin_Click(object sender, EventArgs e)
        {
            if (UserController.CreateNewAdmin("admin", "sagi", "1234", "054-3134195", "sagibaz@post.bgu.ac.il"))
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCreateOwner_Click(object sender, EventArgs e)
        {
            if (UserController.CreateNewOwner("owner", "sagi", "1234", "054-3134195", "sagibaz@post.bgu.ac.il"))
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            if (UserController.CreateNewCustomer("user", "sagi", "1234", "054-3134195", "sagibaz@post.bgu.ac.il"))
            {
                Response.Redirect("Login.aspx");
            }

        }
    }
}