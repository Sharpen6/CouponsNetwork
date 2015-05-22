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
        public static int CreateCoupon(string name,  string orgprice, string discount,
            string business,string desc, string datee, int maxNum,  List<ListItem> interestt)
        {
            Business b = GetUserBusiness(business);
                if (b==null) return 0;
            //Interest inter= getinterest(b,interestt);
                return BusinessDataAccess.CreateCoupon(name, desc, orgprice, discount, b, datee, maxNum, interestt);
        }

        private static Interest getinterest(Business catrgory, string interestt)
        {
            return BusinessDataAccess.FindInterestt(catrgory, interestt);
        }


        public static bool CreateBusiness(string ad, string owner, string address, 
            string name, string c,string cityName)
        {
            int cityID = BusinessDataAccess.FindCity(cityName);
            int categoryID = BusinessDataAccess.FindCategory(c);            
            return BusinessDataAccess.CreateBusiness(ad, owner, address, name, categoryID,cityID);
        }
        private static Business GetUserBusiness(string ownerName)
        {
            return BusinessDataAccess.FindBusiness(ownerName);
        }
        public static ListItem[] GetAllBusnisesId(string ownerName)
        {
            return BusinessDataAccess.GetAllBusnisesId(ownerName);
        }

        public static ListItem[] GetAllBusnisesCategory(string ownerName)
        {
            return BusinessDataAccess.GetAllBusnisesCategory(ownerName);
        }

        public static bool UserHasBusiness(string userName)
        {
            Business b = GetUserBusiness(userName);
            if (b == null) 
                return false;
            return true;
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
    }

}