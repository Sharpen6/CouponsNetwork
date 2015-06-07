using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace CouponsOnline.DataLayer
{
    public class DataAccess
    {
        //all tested
        public static bool CreateCity(string p)
        {
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Cities)
                {
                    if (item.Name == p) return false;
                }
                City bc = new City();
                bc.Name = p;
                be.Cities.Add(bc);
                be.SaveChanges();
                return true;
            }

        }
        public static ListItem[] GetAllCites()
        {
            ListItem[] ans;
            int i = 0;
            List<City> cItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Cities
                            select b;
                cItems = new List<City>(items);

                ans = new ListItem[cItems.Count];
                foreach (var item in cItems)
                {
                    ans[i++] = new ListItem(item.Name, item.Id.ToString());
                }
            }
            return ans;
        }
        public static bool CreateCategory(string p)
        {
            if (FindCategory(p) != 0) return false;
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories bc = new BusinessCategories();
                bc.Description = p;
                be.BusinessCategories.Add(bc);
                be.SaveChanges();
                return true;
            }

        }
        public static int FindCategory(string c)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.BusinessCategories
                          where b.Description == c
                          select b;
                if (bus.Count() == 0) return 0;
                BusinessCategories businessCat = bus.First();


                return businessCat.Id;
            }
        }        
        public static bool CreateInterest(string categoryID, string interestDesc)
        {            using (basicEntities be = new basicEntities())
            {
                int Category = int.Parse(categoryID);
                BusinessCategories bc = be.BusinessCategories.Find(Category);
                if (bc == null) return false; 
                 Interest b = new Interest();
                b.BusinessCategory = be.BusinessCategories.Find(Category);
                
                be.Entry(b.BusinessCategory).State = System.Data.Entity.EntityState.Unchanged;
                b.Description = interestDesc;
                be.Interests.Add(b);
                be.SaveChanges();
                return true;
            }
        }
    }
}