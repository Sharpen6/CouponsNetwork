using CouponsOnline.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
 

namespace CouponsOnline.DataLayer
{
    // all tested
    public class BusinessDataAccess
    {
        public static bool CreateBusiness(string ad, string owner, string address,
            string name, string categoryID, string cityID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                b.Address = address;
                b.Name = name;
                b.City = be.Cities.Find(Int32.Parse(cityID));
                b.BusinessCategory = be.BusinessCategories.Find(int.Parse(categoryID));
                b.Users_Admin = be.Users_Admin.Find(ad);
                b.Users_Owner = be.Users_Owner.Find(owner);
                be.Users_Owner.Find(owner).Businesses.Add(b);
                be.Businesses.Add(b);
                be.SaveChanges();
                return true;
            }
        }

        public static Business GetBusiness(int businessID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = be.Businesses.Find(businessID);
                be.Entry(b).Reference(p => p.BusinessCategory).Load();
                be.Entry(b).Reference(p => p.Users_Admin).Load();
                be.Entry(b).Reference(p => p.Users_Owner).Load();
                be.Entry(b).Collection(p => p.Coupons).Load();
                be.Entry(b).Reference(p => p.City).Load();
                if (!b.Blocked)
                    return b;
                else 
                    return null;
            }
        }
        public static bool DisableBusiness(int b)
        {
            using (basicEntities be = new basicEntities())
            {
                be.Businesses.Find(b).Blocked = true;
                be.SaveChanges();
            }
            return true;
        }

        public static ListItem[] GetCategories()
        {
            ListItem[] ans;
            int i=0;
            List<BusinessCategories> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.BusinessCategories
                            select b;
                bItems = new List<BusinessCategories>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Description,item.Id.ToString()); 
            }
            return ans;
        }

        public static List<Business> GetAllBusinssesOfOwner(string businessOwner)
        {
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Businesses
                            where b.Users_Owner.UserName == businessOwner && b.Blocked == false
                            select b;
                //foreach (Business b in items)
                //    b.Blocked = true;
                //be.SaveChanges();
                return new List<Business>(items);
            }
        }
        
        public static ListItem[] GetAllIntrestOfCategory(string Categoryid)
        {
            int catID = Int32.Parse(Categoryid);
            ListItem[] ans;
            int i = 0;
            List<Interest> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Interests
                            where b.BusinessCategory.Id == catID
                            select b;
                bItems = new List<Interest>(items);  
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Description,item.Id.ToString());
            }
            return ans;
        }
              
        public static bool EditBusiness(int businessId, string address, string name, string categoryID, string cityID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = be.Businesses.Find(businessId);
                b.Name = name;
                b.Address = address;
                b.City = be.Cities.Find(int.Parse(cityID));
                b.BusinessCategory = be.BusinessCategories.Find(int.Parse(categoryID));
                be.SaveChanges();
                return true;
            }
        }

        public static ListItem[] GetlAllInterests()
        {
            ListItem[] ans;
            int i = 0;
            List<Interest> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Interests
                            select b;
                bItems = new List<Interest>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Description, item.Id.ToString());
            }
            return ans;
        }

    }
    
}