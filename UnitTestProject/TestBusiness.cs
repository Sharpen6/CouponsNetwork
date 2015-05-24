using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    
    [TestClass]
    public class TestBusiness
    {
        string admins;
        string owners;
        int Businessid;


        [TestMethod]
        public void TestAddBusiness()
        {

            using (basicEntities be = new basicEntities())
            {
                Businessid = AddBusiness();
                Assert.AreEqual(be.Businesses.Find(Businessid).BusinessID, Businessid);
            }
        }

        
        [TestMethod]
        public void TestUpdateBusiness()
        {
            using (basicEntities be = new basicEntities())
            {
                Businessid = AddBusiness();

                be.Businesses.Find(Businessid).Address = "tel ron";
                be.SaveChanges();

                Assert.AreEqual(be.Businesses.Find(Businessid).Address, "tel ron");
            }
            RemoveBusinesses(Businessid);
        }

        [TestMethod]
        public void TestRemoveBusiness()
        {
            Businessid = AddBusiness();
            RemoveBusinesses(Businessid);
            using (basicEntities be = new basicEntities())
            {               
                Assert.IsNull(be.Businesses.Find(Businessid));
            }
        }
        public int AddBusiness()
        {
            admins = TestAdmin.AddAdmin();
            owners = TestOwner.AddOwner();

            using (basicEntities be = new basicEntities())
            {
                Users_Owner owner = be.Users_Owner.Find(owners);
                Users_Admin admin = be.Users_Admin.Find(admins);
                Business b = AddBusinesses(admin, owner, "beer-Sheva", "bla");
                be.Businesses.Add(b);
                be.SaveChanges();
                return b.BusinessID;
            }
        }

        public static Business AddBusinesses(Users_Admin ad, Users_Owner owner, String address, string name)
        {
            City city = TestCity.AddCity();
            BusinessCategories bc = TestCategory.AddCategory();
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                b.Users_Admin = ad;
                b.Users_Owner = owner;
                b.Address = address;
                b.Name = name;
                b.BusinessCategoriesId = bc.Id;
                b.BusinessCategory = bc;
                be.Entry(bc).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(city).State = System.Data.Entity.EntityState.Unchanged;
                b.City = city;
                return b;
            }

        }

        public static void RemoveBusinesses(int BusinessID)
        {
            using (basicEntities be = new basicEntities())
            {
                Business BusinessesToRemove = be.Businesses.Find(BusinessID);
                string owner = BusinessesToRemove.Users_Admin.UserName;
                string admin = BusinessesToRemove.Users_Owner.UserName;
                be.Businesses.Remove(BusinessesToRemove);
                be.SaveChanges();
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (basicEntities be = new basicEntities())
            {
                if(be.Businesses.Find(Businessid)!=null)
                {
                be.Businesses.Remove(be.Businesses.Find(Businessid));
                be.SaveChanges();
                TestOwner.RemoveOwner(owners);
                TestAdmin.RemoveAdmin(admins);
                }
            }
        }
    }
}
