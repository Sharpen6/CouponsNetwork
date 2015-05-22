using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
 

namespace CouponsOnline.DataLayer
{
    public class BusinessDataAccess
    {
        public static int CreateCoupon(string name, string desc,string orgprice, string discount, Business b, string datee, int maxNum, Interest interestt)
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
                cop.Interests.Add(interestt);
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
                          where b.Users_Owner.UserName == businessOwner
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
            string name, int c)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                //b.Admin_UserName = ad;
                //b.Owner_UserName = owner;
                b.Address = address;
                b.Name = name;
                //b.Category = c;
                b.BusinessCategory = be.BusinessCategories.Find(c);
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
    }
}