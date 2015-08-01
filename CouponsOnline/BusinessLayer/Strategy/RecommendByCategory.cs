using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CouponsOnline.BusinessLayer
{
    public class RecommendByCategory : RecommendStrategy
    {
        public DataTable Recommend(string[] args)
        {
            string username = args[0];
            Users_Customer u = UserDataAccess.FindCustomer(username);
            List<string> interests = new List<string>();
            foreach (Interest i in u.Interests) {
                interests.Add(i.Id.ToString());
            }
            DataTable table = CouponDataAccess.GetCouponsByInterest(interests);
            table.Columns.Remove("Business");
            table.Columns.Remove("CoupinId");
            table.Columns.Remove("MaxNum");
            return table;
        }
    }
}