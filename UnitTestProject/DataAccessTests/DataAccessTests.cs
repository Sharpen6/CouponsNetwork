using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.DataLayer;
using System.Web.UI.WebControls;

namespace UnitTestProject.DataAccessTests
{
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void CreateCity()
        {
           DataAccess.CreateCity("test City");
           ListItem[] cities = DataAccess.GetAllCites();
           foreach (var item in cities)
           {
               if (item.Text == "test City")
               {
                   Assert.IsTrue(true);
                   return;
               }
           }
           using (basicEntities be = new basicEntities())
           {
               foreach (var item in be.Cities)
               {
                   if (item.Name == "test City")
                       be.Cities.Remove(item);
               }
               be.SaveChanges();
           }
        }
        [TestMethod]
        public void GetAllCites() 
        {
           DataAccess.CreateCity("test City");
           ListItem[] cities = DataAccess.GetAllCites();
           foreach (var item in cities)
           {
               if (item.Text == "test City")
               {
                   Assert.IsTrue(true);
                   return;
               }
           }
           using (basicEntities be = new basicEntities())
           {
               foreach (var item in be.Cities)
               {
                   if (item.Name == "test City")
                       be.Cities.Remove(item);
               }
               be.SaveChanges();
           }
        }
        [TestMethod]
        public void CreateCategory()
        {
            DataAccess.CreateCategory("test category");
            if (!(DataAccess.FindCategory("test category") > 0))
                Assert.IsTrue(false);
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.BusinessCategories)
                {
                    if (item.Description == "test category")
                        be.BusinessCategories.Remove(item);
                }
                be.SaveChanges();
            }
        }
        [TestMethod]
        public void FindCategory()
        {
            DataAccess.CreateCategory("test category");
            if (!(DataAccess.FindCategory("test category") > 0))
                Assert.IsTrue(false);
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.BusinessCategories)
                {
                    if (item.Description == "test category")
                        be.BusinessCategories.Remove(item);
                }
                be.SaveChanges();
            }
        }
        [TestMethod]
        public void CreateInterest()
        {
            DataAccess.CreateCategory("topCategoryTest");
            int catID = DataAccess.FindCategory("topCategoryTest");
            DataAccess.CreateInterest(catID.ToString(), "test Interest");
            using (basicEntities be = new basicEntities())
            {
                bool flag=false;
                foreach (var item in be.Interests)
                {
                    if (item.BusinessCategory.Id==catID)
                    if (item.Description == "test Interest")
                    {
                        flag = true;
                        be.Interests.Remove(item);
                    }
                }
                Assert.IsTrue(flag);
                be.BusinessCategories.Remove(be.BusinessCategories.Find(catID));
            }
        }
    }
}
