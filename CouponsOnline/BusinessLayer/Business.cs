using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline
{
    public partial class Business
    {             
        //not tested
        
        public bool Deactivate()
        {
            return BusinessDataAccess.DisableBusiness(BusinessID);
        }
        public object GetCoupons()
        {
            return CouponDataAccess.GetCouponsByBusniess(BusinessID);
        }     
        public bool ChangeDetails(string address, string name, 
            string categoryID, string cityID)
        {
            return BusinessDataAccess.EditBusiness(BusinessID, address, name, categoryID, cityID);
        }
        public int GetCategory()
        {
            return BusinessDataAccess.GetBusinessCategory(BusinessID).Id;
        }
        public bool CreateCoupon(string name, string org, string disc, 
            string desc, string exp, string mpu, List<string> selected)
        {
            return CouponDataAccess.CreateCoupon(name, desc, org, disc, this, exp, mpu, selected);
        }
        internal int GetCity()
        {
            return BusinessDataAccess.GetBusinessCity(BusinessID);
        }
    }
}