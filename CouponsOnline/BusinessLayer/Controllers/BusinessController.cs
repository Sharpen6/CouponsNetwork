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
        

        private static Interest getinterest(Business catrgory, string interestt)
        {
            return CouponDataAccess.FindInterest(catrgory, interestt);
        }


        public static bool CreateBusiness(string ad, string owner, string address, 
            string name, string c,string cityName)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            //Users_Admin admin = UserDataAccess.FindAdmin(ad);
            return admin.CreateBusiness(owner, address, name, c, cityName);
        }
        public static ListItem[] GetAllBusnisesId(string ownerName)
        {
            return BusinessDataAccess.GetAllBusnisesId(ownerName);
        }

        public static ListItem[] GetAllBusnisesCategory(string ownerName)
        {
            return BusinessDataAccess.GetAllBusnisesCategory(ownerName);
        }

        public static ListItem[] GetAllCategories()
        {
            return BusinessDataAccess.GetCategories();
        }

        internal static bool CreateCategory(string p)
        {
            if (p=="") return false;
            return BusinessDataAccess.CreateCategory(p);
        }

        internal static int FindBusinessCategory(string Busniessid)
        {
            return BusinessDataAccess.GetBusinessCategory(Busniessid);
        }

        internal static ListItem[] GetAllCategoryIntrest(int Categoryid)
        {
            return BusinessDataAccess.GetCategoryIntrest(Categoryid);
        }

        internal static bool createInterest(string p1, string p2)
        {
            if (p2 == "") return false;
            return BusinessDataAccess.CreateInterest(p1,p2);
        }

        internal static ListItem[] GetAllCites()
        {
            return BusinessDataAccess.GetCites();
        }

        internal static bool AddCity(string p)
        {
            if (p == "") return false;
            return BusinessDataAccess.CreateCity(p);
        }
        internal static ListItem[] GetAllInterests(string categoryName)
        {
            int Categoryid = BusinessDataAccess.FindCategory(categoryName);
            return BusinessDataAccess.GetCategoryIntrest(Categoryid);
        }

        internal static bool deleteBusiness(int p)
        {
           return BusinessDataAccess.DeleteBusiness(p);
             
        }

        internal static Business findBusinessById(string p)
        {
            return BusinessDataAccess.FindBusiness( Int32.Parse(p));
        }

        internal static string Getcity(int p)
        {
            return BusinessDataAccess.FindBusinessCity(p);
        }

        internal static string GetCategoty(int p)
        {
            return BusinessDataAccess.FindBusinessCategory(p);
        }

        internal static void EditBusniess(string ad, int businessId, string address, string name, string category, string city)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            //Users_Admin admin = UserDataAccess.FindAdmin(ad);
             admin.EditBusiness(businessId, address, name, category, city);
        }
    }

}