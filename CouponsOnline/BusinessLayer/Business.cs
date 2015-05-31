using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline
{
    public partial class Business
    {
        public bool Deactivate()
        {
            return BusinessDataAccess.DisableBusiness(BusinessID);
        }
    }
}