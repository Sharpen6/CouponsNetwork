using CouponsOnline.BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
 

namespace CouponsOnline.DataLayer
{
    public class BusinessDataAccess
    {
        

        
        public static Business FindBusiness(string businessName)
        {
            using (basicEntities be = new basicEntities())
            {
                /*var bus = from b in be.Businesses
                          where b.Owner_UserName == businessOwner
                          select b;*/
                var bus = from b in be.Businesses
                          where b.Name == businessName
                          select b;
                Business business = bus.First();
                return business;
            }
        }

        public static Business FindBusiness(int businessID)
        {
            using (basicEntities be = new basicEntities())
            {
                /*var bus = from b in be.Businesses
                          where b.Owner_UserName == businessOwner
                          select b;*/
                var bus = from b in be.Businesses
                          where b.BusinessID == businessID
                          select b;
                Business business = bus.First();
                return business;
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

        public static int FindInterest(int Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategory.Id == Category
                          select b;
                if (bus.Count() == 0) return 0;
                Interest Interests = bus.First();


                return Interests.Id;
            }
        }
        public static BusinessCategories FindCategorybyBusinessId(int businessId)
        {
            using (basicEntities be = new basicEntities())
            {
                /*var bus = from b in be.Businesses
                          where b.Owner_UserName == businessOwner
                          select b;*/
                var bus = from b in be.Businesses
                          where b.BusinessID == businessId
                          select b;
                Business business = bus.First();
                return business.BusinessCategory;
            }
        }
 
        public static bool CreateBusiness(string ad, string owner, string address, 
            string name, string categoryID,string cityID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                //b.Admin_UserName = ad;
                //b.Owner_UserName = owner;
                b.Address = address;
                b.Name = name;
                //b.Category = c;
                b.City = be.Cities.Find(int.Parse(cityID));
                b.BusinessCategory = be.BusinessCategories.Find(int.Parse(categoryID));
                b.Users_Admin = be.Users_Admin.Find(ad);
                b.Users_Owner = be.Users_Owner.Find(owner);
                be.Businesses.Add(b);
                be.SaveChanges();
                return true;
            }
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

        public static ListItem[] GetAllBusnisesId(string businessOwner)
        {
            ListItem[] ans;
            int i = 0;
            List<Business> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Businesses
                            where b.Users_Owner.UserName == businessOwner & b.Blocked==false
                            select b;
                bItems = new List<Business>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Name,item.BusinessID.ToString());
                ans[i-1].Value = item.BusinessID.ToString();

            }
            return ans;
        }

        public static ListItem[] GetAllBusnisesCategory(string businessOwner)
        {
            ListItem[] ans;
            int i = 0;
            List<Business> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Businesses
                            where b.Users_Owner.UserName == businessOwner & b.Blocked == false
                            select b;
                bItems = new List<Business>(items);
            
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.BusinessCategory.Description,
                    item.BusinessCategory.Id.ToString());
            }
                }
            return ans;
        }

        public static List<Business> GetAllBusnisesOfOwner(string businessOwner)
        {
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Businesses
                            where b.Users_Owner.UserName == businessOwner & b.Blocked == false
                            select b;
                foreach (Business b in items)
                    b.Blocked = true;
                be.SaveChanges();
                return new List<Business>(items);
            }
        }

        public static bool CreateCategory(string p)
        {
            if (FindCategory(p)!=0) return false;
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories bc = new BusinessCategories();
                bc.Description=p;
                be.BusinessCategories.Add(bc);
                be.SaveChanges();
                return true;
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

        public static bool CreateInterest(string category, string interestDesc)
        {
            int Category = FindCategory(category);
            if (FindInterest(Category, interestDesc) != 0) return false;
            
            using (basicEntities be = new basicEntities())
            {
                Interest b = new Interest();

                b.BusinessCategory = be.BusinessCategories.Find(Category);
                be.Entry(b.BusinessCategory).State = System.Data.Entity.EntityState.Unchanged;
                b.Description = interestDesc;
                be.Interests.Add(b);
                be.SaveChanges();
                return true;
            }
            
        }

        public static int FindCity(string cityName)
        {
            using (basicEntities be = new basicEntities())
            {
                var city = from b in be.Cities
                           where b.Name == cityName
                          select b;
                if (city.Count() == 0) return 0;
                City c = city.First();
                return c.Id;
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
                    ans[i++] = new ListItem(item.Name,item.Id.ToString());
                }
            }
            return ans;
        }

        public static bool CreateCity(string p)
        {
            if (FindCity(p) != 0) return false;
            using (basicEntities be = new basicEntities())
            {
                City bc = new City();
                bc.Name = p;
                be.Cities.Add(bc);
                be.SaveChanges();
                return true;
            }

        }

        public static string FindBusinessCity(int p)
        {
      
            using (basicEntities be = new basicEntities())
            {
              return be.Businesses.Find(p).City.Name;
            }
         
        }

        public static string FindBusinessCategory(int p)
        {
            using (basicEntities be = new basicEntities())
            {
                return be.Businesses.Find(p).BusinessCategory.Description;
            }
        }

        public static bool EditBusiness(int businessId, string address, string name, int categoryID, int cityID)
        {
         
                using (basicEntities be = new basicEntities())
                {
                    Business b= be.Businesses.Find(businessId);
                    b.Name = name;
                    b.Address=address;
                    b.City = be.Cities.Find(cityID);
                    b.BusinessCategory = be.BusinessCategories.Find(categoryID);
                    be.SaveChanges();
                    return true;
                }
       
            }
        
        public static Users_Owner GetBusinessOwner(string selectedBusiness)
        {
            using (basicEntities be = new basicEntities())
            {
                var owner = from b in be.Businesses
                           where b.Name == selectedBusiness
                           select b.Users_Owner;
                if (owner.Count() == 0) return null;
                Users_Owner c = owner.First();
                return c;
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

        public static bool DisableBusiness(int b)
        {
            using (basicEntities be = new basicEntities())
            {
                be.Businesses.Find(b).Blocked = true;
                be.SaveChanges();
            }
            return true;
        }
    }
    
}