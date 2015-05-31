using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class Users_Owner
    {
        public bool CreateCoupon(string name, double orgprice, double discount,
            string selectedBusiness, string desc, string datee, int maxNum, List<string> interestt)
        {
            Business b = BusinessDataAccess.FindBusiness(selectedBusiness);
            return CouponDataAccess.CreateCoupon(name, desc, orgprice, discount, b, datee, maxNum, interestt);
        }

        public ListItem[] GetBusinesses()
        {
            return BusinessDataAccess.GetAllBusnisesId(UserName);
        }
    }
}