using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.BusinessLayer.Presenters
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
        #endregion
        #region city
        public static bool CreateCity(string p)
        {
            if (p == "") return false;
            return DataAccess.CreateCity(p);
        }
        public static ListItem[] GetAllCites()
        {
            return DataAccess.GetAllCites();
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