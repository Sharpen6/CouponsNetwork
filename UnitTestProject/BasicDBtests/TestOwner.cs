using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.BusinessLayer.Presenters;
using CouponsOnline.DataLayer;
using System.Web.UI.WebControls;

namespace UnitTestProject
{
    [TestClass]
    public class TestOwner
    {

        [TestMethod]
        public void TestAddOwner()
        {
            string owner;
            using (basicEntities be = new basicEntities())
            {
                owner = AddOwner().UserName;
                Users_Owner ad = be.Users_Owner.Find(owner);
                Assert.AreEqual(ad.UserName, owner);
                Assert.AreEqual(be.Users.Find(owner).UserName, owner);
                
            }
            RemoveOwner(owner);
        }
        [TestMethod]
        public void TestUpdateOwner()
        {
            string username ;
            using (basicEntities be = new basicEntities())
            {
                username  = AddOwner().UserName;
                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();
                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");
            }
            RemoveOwner(username);
        }
        [TestMethod]
        public void TestRemoveOwner()
        {
            string username = AddOwner().UserName;
            RemoveOwner(username);
            using (basicEntities be = new basicEntities())
            {                
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }
        [TestMethod]
        public void GetBusinessesTest()
        {
            Business b = TestBusiness.AddBusiness();
            int startcount = b.Users_Owner.GetBusinesses().Length;
            b.Users_Admin.CreateBusiness(b.Users_Owner.UserName, "", "", b.BusinessCategory.Id.ToString(), b.City.Id.ToString());
            int endcount = b.Users_Owner.GetBusinesses().Length;
            ListItem[] bus = b.Users_Owner.GetBusinesses();
            Assert.AreEqual(endcount - 1, startcount);
            TestBusiness.RemoveBusinesses(b.BusinessID);
            TestBusiness.RemoveBusinesses(int.Parse(bus[1].Value));
        }

        public static Users_Owner AddOwner(string UserName = "ownerUserName", string Name = "ownerName", string Password = "1234", string PhoneNum = "123", string Email = "temp@temp.temp")
        {
            User a = TestUser.AddUser(UserName, Name, Password, PhoneNum, Email);
            using (basicEntities be = new basicEntities())
            {
                Users_Owner ua = new Users_Owner();
                ua.UserName = a.UserName;
                ua.User = a;
                be.Entry(a).State = System.Data.Entity.EntityState.Unchanged;
                be.Users_Owner.Add(ua);
                be.SaveChanges();
                return ua;
            }
        }

        public static void RemoveOwner(string owner)
        {          
            using (basicEntities be = new basicEntities())
            {
                foreach (var item in be.Businesses)
                {
                    if (item.Users_Owner.UserName == owner) return;
                }
                Users_Owner userToRemove = be.Users_Owner.Find(owner);
                if (userToRemove != null)
                {
                    be.Users_Owner.Remove(userToRemove);
                    be.SaveChanges();
                }
            }

            TestUser.RemoveUser(owner);
        }
    }
}
