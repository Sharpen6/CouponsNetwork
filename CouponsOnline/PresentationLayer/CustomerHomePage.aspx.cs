using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CouponsOnline.PresentationLayer
{
    public partial class CustomerHomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                ScriptManager.RegisterStartupScript(this, GetType(), 
                    "SwitchTo", "SwitchTo('home')", true);
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), 
                    "SwitchTo", "SwitchTo('prevDiv')", true);
            }
        }
    }
}