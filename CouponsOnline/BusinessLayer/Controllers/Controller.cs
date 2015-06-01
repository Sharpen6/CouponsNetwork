using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Controllers
{
    public class Controller
    {
        #region category
        public static bool CreateCategory(string p)
        {
            if (p == "") return false;
            return DataAccess.CreateCategory(p);
        }
        public static ListItem[] GetAllCategories()
        {
            return BusinessDataAccess.GetCategories();
        }
        public static string GetCategoryDesc(int catID)
        {
            ListItem[] all = GetAllCategories();
            foreach (var item in all)
            {
                if (item.Value == catID.ToString())
                    return item.Text;
            }
            return "";
        }
        #endregion
        #region city
        public static bool CreateCity(string p)
        {
            if (p == "") return false;
            return DataAccess.CreateCity(p);
        }
        public static ListItem[] GetAllCites()
        {
            return BusinessDataAccess.GetAllCites();
        } 
        #endregion
        #region interest
        public static bool CreateInterest(string categoryID, string interestDesc)
        {
            if (interestDesc == "") return false;
            return DataAccess.CreateInterest(categoryID, interestDesc);
        }
        public static ListItem[] GetAllInterests()
        {
            return BusinessDataAccess.GetlAllInterests();
        }
        public static ListItem[] GetAllCategoryInterests(string Categoryid)
        {
            return BusinessDataAccess.GetAllIntrestOfCategory(Categoryid);
        }
        #endregion
    }
}