using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.UI.WebControls;


namespace CouponsOnline.BusinessLayer.Presenters
{
    public class CouponController
    {
        public static DataTable GetCouponsByCity(string city)
        {
            return CouponDataAccess.GetCouponsByCity(city);
        }

        public static DataTable FindCoupons(string city, List<ListItem> selectedInterests,
            double coordinateX, double coordinateY)
        {
            DataTable table = new DataTable();
            //without Gps 
            if (city != "" && selectedInterests!=null)
            {
                table = CouponDataAccess.GetCouponsByCityAndInterest(city, selectedInterests);
            }
            else
            if (city != "")
                table = CouponDataAccess.GetCouponsByCity(city);
            else  if (selectedInterests.Count != 0)
                table = CouponDataAccess.GetCouponsByInterest(selectedInterests);
            else  if (coordinateX != 0 && coordinateY != 0)
                table = CouponDataAccess.GetCouponsByGps(coordinateX, coordinateY);

        
            return table;
        }
        //NEW 
        public static List<string> ValidateNewCoupon(string maxPerUser, string dicount, string original, string expiration,List<string> interests)
        {
            List<string> errors = new List<string>();
            int mdu;
            double orgPrice;
            double newPrice;
            if (!(interests.Count > 0))
                errors.Add("Coupon must have at least one interest");
            if (!int.TryParse(maxPerUser, out mdu))
                errors.Add("Missing maximum quantity per user.");
            if (!double.TryParse(dicount, out newPrice))
                errors.Add("Discount has to be Number");
            if (!double.TryParse(original, out orgPrice))
                errors.Add("Price has to be Number");
            if (expiration == "" || DateTime.Parse(expiration) < DateTime.Now)
                errors.Add("Experation Date is Wrong");
            if (newPrice > orgPrice)
                errors.Add("New price must be lower then the original price!");
            if (mdu < 1)
                errors.Add("Quantity per user must be greater then zero.");
            return errors;
        }

        public static Coupon GetCoupon(string id)
        {
            return CouponDataAccess.GetCoupon(id);
        }
    }
}