using CouponsOnline.DataLayer;
using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class User
    {
        public bool ChangeDetails(string name, string phone, string email ,List<string> interests=null)
        {
            if (!UserDataAccess.changeUser(UserName, name, phone, email))
                return false;
            if (interests != null)
            {
                if (!UserDataAccess.UpdateInterestsToUser(UserName, interests))
                    return false;
            }
            return true;
        }       
        //tested
        public bool AddAuthentication(UserType type)
        {
            using (basicEntities be = new basicEntities())
            {
                User baseUser = be.Users.Find(UserName);
                if (baseUser == null)
                    return false;
                switch (type)
                {
                    case UserType.Customer:
                        Users_Customer uc = new Users_Customer();
                        uc.User = baseUser;
                        uc.UserName = UserName;
                        be.Users_Customer.Add(uc);
                        break;
                    case UserType.Owner:
                        Users_Owner uo = new Users_Owner();
                        uo.User = baseUser;
                        uo.UserName = UserName;
                        be.Users_Owner.Add(uo);
                        break;
                    case UserType.Admin:
                        Users_Admin ua = new Users_Admin();
                        ua.User = baseUser;
                        ua.UserName = UserName;
                        be.Users_Admin.Add(ua);
                        break;
                    default:
                        break;
                }
                be.SaveChanges();
            }
            return true;
        }
        public bool AuthenticateUser(string pass)
        {
            return UserDataAccess.CheckCredentials(UserName, pass);
        }       
        public UserType GetUserType()
        {
            return UserDataAccess.GetAuthentication(UserName);
        }
        public bool Deactivate()
        {
            UserType t = GetUserType();
            if (t == UserType.Owner)
            {
                List<Business> businesses = BusinessDataAccess.GetAllBusnisesOfOwner(UserName);
                foreach (Business bus in businesses)
                {
                    bus.Deactivate();
                }
            }
            return UserDataAccess.RemoveUser(UserName);
        }       
        public bool ChangePassword(string newPassword)
        {
            return UserDataAccess.ChangePassword(UserName, newPassword);
        }
    }
}