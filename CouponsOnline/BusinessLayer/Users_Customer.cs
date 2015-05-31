﻿using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class Users_Customer
    {
        public ListItem[] GetInterests()
        {
            return UserDataAccess.GetUserInterests(UserName);
        }
    }
}