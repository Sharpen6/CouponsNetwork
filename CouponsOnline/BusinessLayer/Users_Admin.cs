using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline
{
    public partial class Users_Admin
    {
        public bool CreateBusiness(string owner, string address,
            string name, string categoryID, string cityID)
        {
            return BusinessDataAccess.CreateBusiness(this.UserName, owner, address, name, categoryID, cityID);
        }

        public bool EditBusiness(int businessId, string address,
            string name, string category, string city)
        {
            Business bus = BusinessDataAccess.GetBusinessByID(businessId);
            int cityID = DataAccess.FindCity(city);
            int categoryID = DataAccess.FindCategory(category);
            return bus.ChangeDetails(address, name, categoryID, cityID);
        }
    }
}