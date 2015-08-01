using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CouponsOnline.BusinessLayer
{
    public class RecommendByBoth : RecommendStrategy
    {
        public DataTable Recommend(string[] args)
        {
            string username = args[0];
            Users_Customer u = UserDataAccess.FindCustomer(username);
            List<string> interests = new List<string>();
            foreach (Interest i in u.Interests)
            {
                interests.Add(i.Id.ToString());
            }
            DataTable table = CouponDataAccess.GetCouponsByInterest(interests);

            double lon = double.Parse(args[1]);
            double lat = double.Parse(args[2]);
            DataTable table2 = CouponDataAccess.GetCouponsByGps(lon, lat);

            DataTable newTable = table2.Clone();

            foreach (DataRow row in table.Rows)
            {
                foreach (DataRow row2 in table2.Rows)
                {
                    string s1 = row[8].ToString();
                    string s2 = row2[7].ToString();
                    if (s1==s2)
                    {
                        double value = double.Parse(row2[0].ToString().Split(' ').First());
                        if (value < double.Parse(args[3]))
                            newTable.Rows.Add(row2.ItemArray);
                    }

                }
               
            }
            return newTable;
        }
    }
}