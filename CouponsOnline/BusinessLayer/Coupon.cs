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
        //all tested
        public bool EditCoupon(string name, double org, double disc, string desc, string exp, int mdp, List<ListItem> selected)
        {
            return CouponDataAccess.EditCoupon(Id, name, org, disc, desc, exp, mdp, selected);
        }
        public bool DeleteCoupon()
        {
            return CouponDataAccess.RemoveCoupon(Id.ToString());
        }/*
        public string FindCouponExpDate()
        {
            return CouponDataAccess.FindCoupon(Id.ToString());
        }*/
    }
}