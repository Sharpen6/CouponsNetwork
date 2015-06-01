using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class Coupon
    {
        public bool EditCoupon(string p1, double p2, double p3, string p4, string p5, int mdp, List<ListItem> selected)
        {
            return CouponDataAccess.EditCoupon(Id, p1, p2, p3, p4, p5, mdp, selected);
        }
        public bool RemoveCoupon()
        {
            return CouponDataAccess.RemoveCoupon(Id.ToString());
        }
        public string FindCouponExpDate(string p)
        {
            return CouponDataAccess.FindCoupon(p);
        }
        public ICollection<Interest> GetInterests(string p)
        {
            return CouponDataAccess.findCopInterest(p);
        }


    }
}