using CouponsOnline.DataLayer;
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
            List<Business> bus = BusinessDataAccess.GetAllBusinssesOfOwner(UserName);
            ListItem[] ans = new ListItem[bus.Count];
            int i = 0;
            foreach (var item in bus)
            {
                ans[i++] = new ListItem(item.Name,item.BusinessID.ToString());
            }
            return ans;
        }
    }
}