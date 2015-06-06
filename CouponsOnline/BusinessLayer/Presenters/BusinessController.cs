using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Presenters
{
    public class BusinessController
    {        
        //approved

        public static bool CreateBusiness(string ad, string owner, string address,
            string name, string category, string cityName)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            return admin.CreateBusiness(owner, address, name, category, cityName);
        }

        public static Business GetBusiness(string businessID)
        {
            return BusinessDataAccess.GetBusiness(Int32.Parse(businessID));
        }


      

           
    }

}