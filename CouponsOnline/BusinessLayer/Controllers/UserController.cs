using CouponsOnline.DataLayer;
using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Controllers
{
    public class UserController
    {
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
                var items = from b in be.Users_Customer
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
                var items = from b in be.Users_Owner
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
    }
}