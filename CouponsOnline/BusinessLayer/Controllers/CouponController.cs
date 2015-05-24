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
        public static bool CreateCoupon(string name, string orgprice, string discount,string user,
            string selectedBusiness, string desc, string datee, int maxNum, List<ListItem> interestt)
        {
            Users_Owner owner = UserDataAccess.FindOwner(user);
            return owner.CreateCoupon(name, orgprice, discount, selectedBusiness,
                desc, datee,maxNum, interestt);
        }

        internal static object GetCouponsByBusniess(string Busniess)
        {
            return CouponDataAccess.GetCouponsByBusniess(Busniess);
        }

        internal static DataTable FindCoupons(string city, List<ListItem> selectedInterests, double coordinateX, double coordinateY,int category)
        {
            DataTable table = new DataTable();
            DataTable t1 = new DataTable();
            DataTable t2 = new DataTable();
            DataTable t3 = new DataTable();
            //without Gps 
            if (city != "" & category!=0)
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

          /*  table = t1.Clone();

            foreach (var DataRow in t2.Rows)
            {
                table.Rows.Add(DataRow);
            }
            foreach (var DataRow in t3.Rows)
            {
                table.Rows.Add(DataRow);
            }*/

            return table;
        }
        internal static bool removeCoupon(string CoponId)
        {
            return CouponDataAccess.RemoveCoupon(CoponId);
        }
    }
}