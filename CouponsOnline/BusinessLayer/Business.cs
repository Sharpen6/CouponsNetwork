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
        public bool ChangeDetails(string address, string name, int categoryID, int cityID)
        {
            return BusinessDataAccess.EditBusiness(BusinessID, address, name, categoryID, cityID);
        }
    }
}