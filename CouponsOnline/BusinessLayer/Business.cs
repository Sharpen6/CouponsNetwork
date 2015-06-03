using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CouponsOnline
{
    public partial class Business
    {             
        //all tested       
        public bool Deactivate()
        {
            return BusinessDataAccess.DisableBusiness(BusinessID);
        }
        public DataTable GetCoupons()
        {
            return CouponDataAccess.GetCouponsByBusniess(BusinessID);
        }     
        public bool ChangeDetails(string address, string name, 
            string categoryID, string cityID)
        {
            return BusinessDataAccess.EditBusiness(BusinessID, address, name, categoryID, cityID);
        }
        public bool CreateCoupon(string name, string org, string disc, 
            string desc, string exp, string mpu, List<string> selected)
        {
            return CouponDataAccess.CreateCoupon(name, desc, org, disc, this, exp, mpu, selected);
        }
    }
}