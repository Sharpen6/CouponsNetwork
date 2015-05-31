using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Controllers
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
            return BusinessDataAccess.GetBusinessByID(Int32.Parse(businessID));
        }

        //not approved
        public static void EditBusniess(string ad, int businessId, string address, string name, string category, string city)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            admin.EditBusiness(businessId, address, name, category, city);
        } 

        public static ListItem[] GetAllBusnisesCategory(string ownerName)
        {
            return BusinessDataAccess.GetAllBusnisesCategory(ownerName);
        }


        public static int FindBusinessCategory(string Busniessid)
        {
            return BusinessDataAccess.FindCategorybyBusinessId(Int32.Parse(Busniessid)).Id;
        }

        public static ListItem[] GetAllCategoryInterests(string Categoryid)
        {
            return BusinessDataAccess.GetAllIntrestOfCategory(Categoryid);
        }
      

           
    }

}