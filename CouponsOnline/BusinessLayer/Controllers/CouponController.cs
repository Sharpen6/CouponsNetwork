using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;


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



        internal static bool removeCoupon(string CoponId)
        {
            return CouponDataAccess.RemoveCoupon(CoponId);
        }
    }
}