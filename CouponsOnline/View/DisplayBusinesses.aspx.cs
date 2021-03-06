﻿using CouponsOnline.BusinessLayer.Presenters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.View
{
    public partial class DisplayBusinesses : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, GetType(),
                        "SwitchTo", "SwitchTo('home')", true);
            GridView1.DataSource = BusinessController.GetAllBusinesses();
            GridView1.DataBind();
        }
    }
}