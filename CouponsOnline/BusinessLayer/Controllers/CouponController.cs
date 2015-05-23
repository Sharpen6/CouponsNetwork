using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;


namespace CouponsOnline.BusinessLayer.Controllers
{
    public class CouponController
    {
        internal static DataTable GetCouponsByCity(string city)
        {
            return CouponDataAccess.GetCouponsByCity(city);
        }

        internal static object GetCouponsByBusniess(string Busniess)
        {
            return CouponDataAccess.GetCouponsByBusniess(Busniess);
        }

        internal static DataTable FindCoupons(string city, List<ListItem> selectedInterests, double coordinateX, double coordinateY)
        {
            DataTable table = new DataTable();
            if (city != "")
                table = CouponDataAccess.GetCouponsByCity(city);
            else if (selectedInterests.Count != 0)
                table = CouponDataAccess.GetCouponsByInterest(selectedInterests);
            else if (coordinateX != 0 && coordinateY != 0)
                table = CouponDataAccess.GetCouponsByGps(coordinateX, coordinateY);
            return table;
        }
        internal static bool removeCoupon(string CoponId)
        {
            return CouponDataAccess.RemoveCoupon(CoponId);
        }
    }
}