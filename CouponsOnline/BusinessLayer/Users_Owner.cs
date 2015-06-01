﻿using CouponsOnline.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline
{
    public partial class Users_Owner
    {
        public ListItem[] GetBusinesses()
        {
            return BusinessDataAccess.GetAllBusnisesId(UserName);
        }
    }
}