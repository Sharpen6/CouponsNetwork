﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
 

namespace CouponsOnline.DataLayer
{
    public class BusinessDataAccess
    {
        public static int CreateCoupon(string name, string desc, string orgprice, string discount, Business b, string datee, int maxNum, List<ListItem> interestt)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon cop = new Coupon();
                cop.Name = name;
                cop.Description = desc;
                cop.OriginalPrice = orgprice;
                cop.DiscountPrice = discount;
                cop.Business = b;
              //  cop.Interest = interestt;
                foreach (ListItem i in interestt)
                {
                    Interest t = FindInterestt(b, i.Value);
                    be.Entry(t).State = System.Data.Entity.EntityState.Unchanged;
                    cop.Interests.Add(t);
                }
                cop.ExperationDate = datee;
                cop.MaxNum = maxNum;
                cop.AvarageRanking = "0";
                cop.Business_BusinessID = b.BusinessCategoriesId;
          
                cop.Business = be.Businesses.Find(b.BusinessCategoriesId);
              //  cop.InterestId = interestt.Id;
                be.Coupons.Add(cop);
                be.SaveChanges();
            
                return cop.Id;
            }
        }

        
        public static Business FindBusiness(string businessOwner)
        {
            using (basicEntities be = new basicEntities())
            {
                /*var bus = from b in be.Businesses
                          where b.Owner_UserName == businessOwner
                          select b;*/
                var bus = from b in be.Businesses
                          where b.Name == businessOwner
                          select b;
                Business business = bus.First();
                return business;
            }
        }

        public static BusinessCategories FindCategorybyId(int businessId)
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
            string name, int categoryID,int cityID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                //b.Admin_UserName = ad;
                //b.Owner_UserName = owner;
                b.Address = address;
                b.Name = name;
                //b.Category = c;
                b.City = be.Cities.Find(cityID);
                b.BusinessCategory = be.BusinessCategories.Find(categoryID);
                b.Users_Admin = be.Users_Admin.Find(ad);
                b.Users_Owner = be.Users_Owner.Find(owner);
                be.Businesses.Add(b);
                be.SaveChanges();
                return true;
            }
        }

        private static Users_Admin FindAdmin(string ad)
        {
            throw new NotImplementedException();
        }

        private static Users_Owner FindOwner(string owner)
        {
            throw new NotImplementedException();
        }

        public static int FindCategory(string c)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.BusinessCategories
                          where b.Description == c
                          select b;
                if (bus.Count()==0) return 0;
                BusinessCategories businessCat = bus.First();

                
                return businessCat.Id;
            }
        }

        public static Interest FindInterestt(Business Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategoriesId==Category.BusinessCategoriesId
                          select b;
                Interest Interests = bus.First();


                return Interests;
            
            }
        }
        public static int FindInterest(int Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategoriesId==Category
                          select b;
                if (bus.Count() == 0) return 0;
                Interest Interests = bus.First();


                return Interests.Id;
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
                ans[i++] = new ListItem(item.Description); 
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
                            where b.Users_Owner.UserName == businessOwner
                            select b;
                bItems = new List<Business>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Name);
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
                            where b.Users_Owner.UserName == businessOwner
                            select b;
                bItems = new List<Business>(items);
            
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.BusinessCategory.Description);
            }
                }
            return ans;
        }

        internal static bool CreateCategory(string p)
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

        internal static int GetBusinessCategory(string Busniessid)
        {
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories Bu = FindCategorybyId(Int32.Parse(Busniessid));

                return Bu.Id;
                throw new NotImplementedException();
            }
        }

        internal static ListItem[] GetCategoryIntrest(int Categoryid)
        {
           ListItem[] ans;
            int i = 0;
            List<Interest> bItems;
            using (basicEntities be = new basicEntities())
            {
                var items = from b in be.Interests
                            where b.BusinessCategory.Id == Categoryid
                            select b;
                bItems = new List<Interest>(items);
            }
            ans = new ListItem[bItems.Count];
            foreach (var item in bItems)
            {
                ans[i++] = new ListItem(item.Description);
            }
            return ans;
        }

        internal static bool CreateInterest(string p1, string p2)
        {
            int Category = FindCategory(p1);
            if (FindInterest(Category, p2) != 0) return false;
            
            using (basicEntities be = new basicEntities())
            {
                Interest b = new Interest();

                b.BusinessCategoriesId = Category;
                b.Description = p2;
                be.Interests.Add(b);
                be.SaveChanges();
                return true;
            }
            
        }

        internal static int FindCity(string cityName)
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

        public static ListItem[] GetCites()
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
                    ans[i++] = new ListItem(item.Name);
                }
            }
            return ans;
        }

        internal static bool CreateCity(string p)
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
    }
}