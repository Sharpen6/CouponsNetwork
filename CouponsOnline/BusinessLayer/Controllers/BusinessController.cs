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
        public static int CreateCoupon(string name, string desc, string orgprice, string discount,
            string business, string datee, int maxNum)
        {
            Business b = GetUserBusiness(business);
                if (b==null) return 0;
            return BusinessDataAccess.CreateCoupon(name,desc,orgprice,discount,b,datee,maxNum);
        }
        public static bool CreateBusiness(string ad, string owner, string address, 
            string name, string c)
        {
            int categoryID = BusinessDataAccess.FindCategory(c);            
            return BusinessDataAccess.CreateBusiness(ad, owner, address, name, categoryID);
        }
        private static Business GetUserBusiness(string ownerName)
        {
            return BusinessDataAccess.FindBusiness(ownerName);
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
    }

}