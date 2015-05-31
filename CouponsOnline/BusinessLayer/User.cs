using CouponsOnline.DataLayer;
using CouponsOnline.PresentationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class User
    {
        public bool AuthenticateUser(string pass)
        {
            return UserDataAccess.CheckCredentials(UserName, pass);
        }
        public UserType GetUserType()
        {
            return UserDataAccess.GetAuthentication(UserName);
        }
    }
}