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
            string name, string category, string cityName)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            //Users_Admin admin = UserDataAccess.FindAdmin(ad);
            return admin.CreateBusiness(owner, address, name, category, cityName);
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

        public static bool CreateCategory(string p)
        {
            if (p=="") return false;
            return BusinessDataAccess.CreateCategory(p);
        }

        public static int FindBusinessCategory(string Busniessid)
        {
            return BusinessDataAccess.FindCategorybyBusinessId(Int32.Parse(Busniessid)).Id;
        }

        public static ListItem[] GetAllCategoryInterests(string Categoryid)
        {
            return BusinessDataAccess.GetAllIntrestOfCategory(Categoryid);
        }

        public static bool CreateInterest(string category, string interestDesc)
        {
            if (interestDesc == "") return false;
            return BusinessDataAccess.CreateInterest(category, interestDesc);
        }

        public static ListItem[] GetAllCites()
        {
            return BusinessDataAccess.GetAllCites();
        }

        public static bool AddCity(string p)
        {
            if (p == "") return false;
            return BusinessDataAccess.CreateCity(p);
        }

        public static bool deleteBusiness(int p)
        {
           return BusinessDataAccess.DeleteBusiness(p);
             
        }

        public static Business findBusinessById(string p)
        {
            return BusinessDataAccess.FindBusiness( Int32.Parse(p));
        }

        public static string Getcity(int p)
        {
            return BusinessDataAccess.FindBusinessCity(p);
        }

        public static string GetCategoty(int p)
        {
            return BusinessDataAccess.FindBusinessCategory(p);
        }

        public static void EditBusniess(string ad, int businessId, string address, string name, string category, string city)
        {
            Users_Admin admin = UserDataAccess.FindAdmin(ad);
            //Users_Admin admin = UserDataAccess.FindAdmin(ad);
             admin.EditBusiness(businessId, address, name, category, city);
        }

        public static ListItem[] GetAllInterests()
        {
            return BusinessDataAccess.GetlAllInterests();
        }

        public static ListItem[] GetAllUserInterests(string p)
        {
            ListItem[] all = GetAllInterests();
            ListItem[] user = UserDataAccess.GetUserInterests(p);

            foreach (var item in all)
            {
                if (user.Contains(item))
                    item.Selected = true;
            }
            return all;
        }
    }

}