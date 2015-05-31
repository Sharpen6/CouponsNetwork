using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CouponsOnline.DataLayer
{
    public class DataAccess
    {
        #region City Management

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
        #endregion

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

        public static Interest FindInterest(Business Category, string desription)
        {
            using (basicEntities be = new basicEntities())
            {
                var bus = from b in be.Interests
                          where b.Description == desription & b.BusinessCategory.Id == Category.BusinessCategoriesId
                          select b;
                Interest Interests = bus.First();


                return Interests;

            }
        }
     

    }
}