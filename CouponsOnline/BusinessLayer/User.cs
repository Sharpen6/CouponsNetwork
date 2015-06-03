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
        //all tested
        public bool ChangeDetails(string name, string phone, 
            string email ,List<string> interests=null)
        {
            if (!UserDataAccess.UpdateInfo(UserName, name, phone, email))
                return false;
            if (interests != null)
            {
                if (!UserDataAccess.UpdateInterestsToUser(UserName, interests))
                    return false;
            }
            return true;
        }            
        public bool AddAuthentication(UserType type)
        {
            return UserDataAccess.AddAuthentication(UserName, type);
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