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
        public static DataTable GetCouponsByCity(string city)
        {
            return CouponDataAccess.GetCouponsByCity(city);
        }
        public static bool CreateCoupon(string name, double orgprice, double discount,
            string selectedBusiness, string desc, string datee, int maxNum, List<string> interestt)
        {
            Users_Owner owner = BusinessDataAccess.GetBusinessOwner(selectedBusiness);
            return owner.CreateCoupon(name, orgprice, discount, selectedBusiness,
                desc, datee,maxNum, interestt);
        }

        public static object GetCouponsByBusniess(string Busniess)
        {
            return CouponDataAccess.GetCouponsByBusniess(Busniess);
        }

        public static DataTable FindCoupons(string city, List<ListItem> selectedInterests, double coordinateX, double coordinateY,int category)
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
        public static bool removeCoupon(string CoponId)
        {
            return CouponDataAccess.RemoveCoupon(CoponId);
        }



        public static bool EditCoupon(int copId, string p1, double p2, double p3, string p4, string p5, int mdp, List<ListItem> selected)
        {
            return CouponDataAccess.EditCoupon( copId,  p1,  p2,  p3,  p4,  p5,  mdp, selected);
        }

        public static string FindCouponExpDate(string p)
        {
            return CouponDataAccess.FindCoupon(p);
        }

        public static ICollection<Interest> FindCopInterest(string p)
        {
            return CouponDataAccess.findCopInterest(p);
        }
    }
}