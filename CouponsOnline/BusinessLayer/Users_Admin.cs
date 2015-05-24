﻿using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline
{
    public partial class Users_Admin
    {
        public bool CreateBusiness(string owner, string address,
            string name, string c, string cityName)
        {
            int cityID = BusinessDataAccess.FindCity(cityName);
            int categoryID = BusinessDataAccess.FindCategory(c);
            return BusinessDataAccess.CreateBusiness(this.UserName, owner, address, name, categoryID, cityID);
        }
    }
}