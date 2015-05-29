using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    
    [TestClass]
    public class TestBusiness
    {

        [TestMethod]
        public void TestAddBusiness()
        {
            int Businessid=0;
            using (basicEntities be = new basicEntities())
            {
                Businessid = AddBusiness().BusinessID;
                Assert.AreEqual(be.Businesses.Find(Businessid).BusinessID, Businessid);
            }
            RemoveBusinesses(Businessid);
        }

        
        [TestMethod]
        public void TestUpdateBusiness()
        {
            int Businessid = AddBusiness().BusinessID;
            using (basicEntities be = new basicEntities())
            {

                be.Businesses.Find(Businessid).Address = "tel ron";
                be.SaveChanges();

                Assert.AreEqual(be.Businesses.Find(Businessid).Address, "tel ron");
            }
            RemoveBusinesses(Businessid);
        }

        [TestMethod]
        public void TestRemoveBusiness()
        {
            int Businessid = AddBusiness().BusinessID;
            RemoveBusinesses(Businessid);
            using (basicEntities be = new basicEntities())
            {               
                Assert.IsNull(be.Businesses.Find(Businessid));
            }
        }

        public static Business AddBusiness(String address = "kalisher 5", string name = "addbusinesstest")
        {
            City city = TestCity.AddCity();
            Users_Owner owner = TestOwner.AddOwner();
            Users_Admin admin = TestAdmin.AddAdmin();
            BusinessCategories bc = TestCategory.AddCategory();
            Business b = new Business();
            using (basicEntities be = new basicEntities())
            {
                b.Users_Admin = admin;
                b.Users_Owner = owner;
                b.Address = address;
                b.Name = name;
                b.BusinessCategoriesId = bc.Id;
                b.BusinessCategory = bc;
                be.Entry(admin).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(owner).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(bc).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(city).State = System.Data.Entity.EntityState.Unchanged;
                b.City = city;
                be.Businesses.Add(b);
                be.SaveChanges();
                return b;
            }                      
        }

        public static void RemoveBusinesses(int BusinessID)
        {
            int catID = 0;
            int cityID = 0;
            string admin;
            string owner;
            using (basicEntities be = new basicEntities())
            {
                
                Business BusinessesToRemove = be.Businesses.Find(BusinessID);
                catID = BusinessesToRemove.BusinessCategoriesId;
                cityID = BusinessesToRemove.City.Id;
                owner = BusinessesToRemove.Users_Admin.UserName;
                admin = BusinessesToRemove.Users_Owner.UserName;
                be.Businesses.Remove(BusinessesToRemove);
                be.SaveChanges();
            }
            TestCategory.RemoveCategory(catID);
            TestCity.RemoveCity(cityID);
            TestAdmin.RemoveAdmin(admin);
            TestOwner.RemoveOwner(owner);
        }
    }
}
