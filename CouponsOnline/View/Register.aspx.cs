using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.View
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadInterest();
        }
        protected void SendButton_Click(object sender, EventArgs e)
        {
            List<string> selectedInterests = new List<string>();
            foreach (ListItem item in DropDownListInterests.Items)
            {
                if (item.Selected) selectedInterests.Add(item.Value);
            }


           List<string> err = UserController.ValidateRegisteration(TextBoxUserName.Text, TextBoxPassword.Text,
                TextBoxPasswordVal.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text, selectedInterests);


           if (err.Count>0) {
               BLerrors.Items.Clear();
                foreach (var item in err)
	            {
                    BLerrors.Items.Add(new ListItem(item));
	            }
           }
           else
           {
               switch (radioBtnUserType.SelectedIndex)
               {
                   case 0:
                       if (UserController.CreateNewCustomer(TextBoxUserName.Text, TextBoxName.Text,
                           TextBoxPassword.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text, selectedInterests))
                       {
                           ClientScript.RegisterStartupScript(
                   this.GetType(), "myalert", "alert('Your account has been created!');", true);
                           Response.Redirect("Login.aspx");

                       }
                       else
                       {
                           ClientScript.RegisterStartupScript(
                   this.GetType(), "myalert", "alert('Could not create your account.');", true);
                       }
                       break;
                   case 1:
                       if (UserController.CreateNewOwner(TextBoxUserName.Text, TextBoxName.Text,
                           TextBoxPassword.Text, TextBoxPhoneNum.Text, TextBoxEmail.Text))
                       {
                           ClientScript.RegisterStartupScript(
                   this.GetType(), "myalert", "alert('Your account has been created!');", true);
                           Response.Redirect("Login.aspx");
                       }
                       else
                       {
                           ClientScript.RegisterStartupScript(
                   this.GetType(), "myalert", "alert('Could not create your account.');", true);
                       }
                       break;
                   default:
                       break;
               }
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
            if (UserController.CreateNewCustomer("user", "sagi", "1234", "054-3134195", "sagibaz@post.bgu.ac.il",new List<string>{"1"}))
            {
                Response.Redirect("Login.aspx");
            }
        }
        protected void btnAddInformation_Click(object sender, EventArgs e)
        {
            Controller.CreateCategory("Pets");
            Controller.CreateCategory("Cars");
            Controller.CreateCategory("Food");

            Controller.CreateInterest(Controller.GetAllCategories().First().Value , "Dogs");
            Controller.CreateInterest(Controller.GetAllCategories().First().Value, "Cats");
            Controller.CreateInterest(Controller.GetAllCategories().ElementAt(2).Value, "Pizza");
            UserController.CreateNewCustomer("sagi", "Sagi Bazinin", "123", "054-3391405", "sag@gmail.com", new List<string> { Controller.GetAllInterests().ElementAt(0).Value, Controller.GetAllInterests().ElementAt(1).Value });
            UserController.CreateNewOwner("sveta", "Sveta Itskovich", "123", "050-5242142", "its@gmail.com");
            UserController.CreateNewCustomer("yossi", "Yossi Zaltsman", "123", "057-7343412", "yos@gmail.com", new List<string> { Controller.GetAllInterests().ElementAt(1).Value });
            UserController.CreateNewAdmin("dorin", "Dorin Shmaryahu", "123", "057-3441252", "dorin@gmail.com");
            Controller.CreateCity("Beer Sheva");
            Controller.CreateCity("Tel Aviv");
            Controller.CreateCity("Rehovot");
            ListItem[] cities = Controller.GetAllCites();
            ListItem[] categories = Controller.GetAllCategories();
            
            foreach (var item in cities)
            {
                if (item.Text=="Beer Sheva") {
                    BusinessController.CreateBusiness("dorin", "sveta", "Ben gurion 24", "PetSheva shop", categories.First().Value, item.Value);
                    BusinessController.CreateBusiness("dorin", "sveta", "Ben gurion 23", "Dogs For All", categories.First().Value, item.Value);

                }
                else if (item.Text == "Tel Aviv")
                {
                    BusinessController.CreateBusiness("dorin", "sveta", "Rager 5", "Cars Inc.", categories.ElementAt(1).Value, item.Value);
                    BusinessController.CreateBusiness("dorin", "sveta", "bialik", "Cofix", categories.ElementAt(2).Value, item.Value);
                }
            

            }
            ListItem[] interests = Controller.GetAllInterests();
            Business b = BusinessController.GetBusiness(UserController.GetOwner("sveta").GetBusinesses().First().Value);
            b.CreateCoupon("Cheap food for cats!", "30.4", "24.5","Cheap Food buy now!","20/10/2015","2", new List<string> { interests.First().Value});
            b = BusinessController.GetBusiness(UserController.GetOwner("sveta").GetBusinesses().ElementAt(3).Value);
            b.CreateCoupon("Cofix Coupon", "7.4", "5", "all for 5 nis!", "15/10/2015", "100", new List<string> { interests.ElementAt(2).Value });
            
            Response.Redirect("Login.aspx");
        }

        private void LoadInterest()
        {
            DropDownListInterests.Items.Clear();
            DropDownListInterests.DataSource = Controller.GetAllInterests();
            DropDownListInterests.DataTextField = "Text";
            DropDownListInterests.DataValueField = "Value";
            DropDownListInterests.DataBind();          
        }
    }
}