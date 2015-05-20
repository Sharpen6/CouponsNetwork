using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

namespace UnitTestProject
{

    [TestClass]
    public class TestBusiness
    {
        string admins;
        string owners;
        string Businessid;



        [TestMethod]
        public void TestAddBusiness()
        {
            using (basicEntities be = new basicEntities())
            {
                 Businessid = TestBusinessAdd();
                Assert.AreEqual(be.Businesses.Find(Businessid).BusinessID, Businessid);
            }
        }

        public string TestBusinessAdd()
        {
            admins = TestAdmin.TestAdminAdd();
            owners = TestOwner.TestOwnerAdd();
            using (basicEntities be = new basicEntities())
            {
                Owner owner = (Owner)be.Users.Find(owners);
                Admin admin = (Admin)be.Users.Find(admins);
                Business b = AddBusinesses("123", admin, owner, "beer-Sheva", "bla", Category.CarsAccessories);
                be.Businesses.Add(b);
                be.SaveChanges();
                return b.BusinessID;
            }
        }
        [TestMethod]
        public void TestUpdateBusiness()
        {
            using (basicEntities be = new basicEntities())
            {
                Businessid = TestBusinessAdd();

                be.Businesses.Find(Businessid).Address = "tel ron";
                be.SaveChanges();

                Assert.AreEqual(be.Businesses.Find(Businessid).Address, "tel ron");
            }
        }

        [TestMethod]
        public void TestRemoveBusiness()
        {
            Businessid = TestBusinessAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveBusinesses(Businessid);
                Assert.AreEqual(be.Businesses.Find(Businessid), null);
            }
        }

        public static Business AddBusinesses(string BusinessID, Admin ad, Owner owner, String address, string name, Category c)
        {
            using (basicEntities be = new basicEntities())
            {
                Business b = new Business();
                b.BusinessID = BusinessID;

                Business sameKey = be.Businesses.Find(b.BusinessID);
                while (sameKey != null && sameKey.BusinessID.ToLower() == b.BusinessID.ToLower())
                {
                    b.BusinessID += "1";
                    sameKey = be.Businesses.Find(b.BusinessID);
                }
                b.Admin = ad;
                b.Owner = owner;
                b.Address = address;
                b.Name = name;
                b.Category = c;
                return b;

            }

        }

        public static void RemoveBusinesses(string BusinessID)
        {
            using (basicEntities be = new basicEntities())
            {

                Business BusinessesToRemove = be.Businesses.Find(BusinessID);
                string owner =BusinessesToRemove.Admin.UserName;
                string admin = BusinessesToRemove.Owner.UserName;
                be.Businesses.Remove(BusinessesToRemove);

                be.SaveChanges();
                TestOwner.RemoveOwner(owner);
                TestAdmin.RemoveAdmin(admin);
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
