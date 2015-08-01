using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CouponsOnline.BusinessLayer
{
    public class RecommendByLocation : RecommendStrategy
    {
        public DataTable Recommend(string[] args)
        {
            double lon = double.Parse(args[1]);
            double lat = double.Parse(args[2]);
            DataTable table = CouponDataAccess.GetCouponsByGps(lon, lat);
            return table;
        }
    }
}