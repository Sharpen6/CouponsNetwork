using CouponsOnline.DataLayer;
using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Controllers
{
    public class UserController
    {
        public static List<string> ValidateRegisteration(string username,string password,string passwordval,
            string phone, string email,string name)
        {
            List<string> errors = new List<string>();
            //username validation
            if (username == "") errors.Add("You must enter a Username.");
            else if (UserDataAccess.getUser(username) != null)
                errors.Add("Username is already taken.");

            //password validation
            if (password == "" && passwordval == "") errors.Add("You must enter a password.");
            else if (passwordval != password) errors.Add("Passwords do not match.");

            //phone validation
            Regex rxPhone = new Regex(@"^0\d([\d]{0,1})([-]{0,1})\d{7}$");
            if (phone == "") errors.Add("You must enter a phone number.");
            else if (!rxPhone.IsMatch(phone)) errors.Add("Enter phone number by the format: 0xx-xxxxxxx.");

            //email validation
            Regex rxEmail = new Regex(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$");
            if (email == "") errors.Add("You must enter your email address.");
            else if (!rxEmail.IsMatch(email)) errors.Add("Email address is incorrect.");

            return errors;
        }
        public static bool AuthenticateUser(string username,string password)
        {
            if (username == "" || password == "") return false;
            return UserDataAccess.isUserPassValid(username,password);
        }

        public static UserType GetUserType(string username)
        {
            return UserDataAccess.GetAuthentication(username);
        }
        public static bool CreateNewCustomer(string UserName, string Name, string Password, string Phone, string Email)
        {
            int PhoneKidumet;
            if (!int.TryParse(Phone.Substring(0, 3), out PhoneKidumet))
                return false;
            int PhoneNum = int.Parse(Phone.Substring(4, Phone.Length - 4));
            bool ans = UserDataAccess.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
            if (ans==false)
                return false;
            return UserDataAccess.AddAuthentication(UserName, UserType.Customer);

        }

        public static bool CreateNewAdmin(string UserName, string Name, string Password, string Phone, string Email)
        {
            int PhoneKidumet;
            if (!int.TryParse(Phone.Substring(0, 3), out PhoneKidumet))
                return false;
            int PhoneNum = int.Parse(Phone.Substring(4, Phone.Length - 4));
            bool ans = UserDataAccess.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
            if (ans == false)
                return false;
            return UserDataAccess.AddAuthentication(UserName, UserType.Admin);

        }

        public static bool CreateNewOwner(string UserName, string Name, string Password, string Phone, string Email)
        {
            int PhoneKidumet;
            if (!int.TryParse(Phone.Substring(0, 3), out PhoneKidumet))
                return false;
            int PhoneNum = int.Parse(Phone.Substring(4, Phone.Length - 4));
            bool ans = UserDataAccess.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
            if (ans == false)
                return false;
            return UserDataAccess.AddAuthentication(UserName, UserType.Owner);
        }

        public static ListItem[] GetAllCustomers()
        {
            ListItem[] ans;
            int i = 0;
            List<Users_Customer> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Users_Customer where b.User.Block==false
                            select b;
                bItems = new List<Users_Customer>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.UserName);
            }
            return ans;
        }

        internal static ListItem[] GetAllOwners()
        {
            ListItem[] ans;
            int i = 0;
            List<Users_Owner> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Users_Owner where b.User.Block==false
                            select b;
                bItems = new List<Users_Owner>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.UserName);
            }
            return ans;
        }

        internal static User GetUser(string ownerName)
        {
          return  UserDataAccess.getUser(ownerName);
        }

        internal static bool EditProfile(string UserName, string Name, string Phone, string Email)
        {
            int PhoneKidumet;
            if (!int.TryParse(Phone.Substring(0, 3), out PhoneKidumet))
                return false;
            int PhoneNum = int.Parse(Phone.Substring(4, Phone.Length - 4));
            bool ans = UserDataAccess.changeUser(UserName, Name, PhoneKidumet, PhoneNum, Email);
            return ans;
           
        }

        internal static bool EditProfile(string password,string user)
        {
            bool ans = UserDataAccess.changeUser(password,user);
            return ans;
        }

        internal static bool deleteProfile(string p)
        {
            bool ans = UserDataAccess.deletePassword(p);
            return ans;
        }
    }
}