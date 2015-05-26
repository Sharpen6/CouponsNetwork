using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    [TestClass]
    public class TestOwner
    {

        [TestMethod]
        public void TestAddOwner()
        {
            using (basicEntities be = new basicEntities())
            {
                string owner = AddOwner().UserName;
                Users_Owner ad = be.Users_Owner.Find(owner);
                Assert.AreEqual(ad.UserName, owner);
                Assert.AreEqual(be.Users.Find(owner).UserName, owner);
                RemoveOwner(owner);
            }
        }
        [TestMethod]
        public void TestUpdateOwner()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = AddOwner().UserName;
                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();
                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");
                RemoveOwner(username);
            }
        }
        [TestMethod]
        public void TestRemoveOwner()
        {
            string username = AddOwner().UserName;
            using (basicEntities be = new basicEntities())
            {
                RemoveOwner(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }

        public static Users_Owner AddOwner(string UserName = "ownerUserName", string Name = "ownerName", string Password = "1234", int PhoneKidumet = 1234567, int PhoneNum = 123, string Email = "temp@temp.temp")
        {
            User a = TestUser.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
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
                Users_Owner userToRemove = be.Users_Owner.Find(owner);
                be.Users_Owner.Remove(userToRemove);
                be.SaveChanges();
            }
            TestUser.RemoveUser(owner);
        }
    }
}
