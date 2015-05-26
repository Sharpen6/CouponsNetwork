using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    [TestClass]
    public class TestAdmin
    {
        [TestMethod]
        public void TestAddAdmin()
        {
            using (basicEntities be = new basicEntities())
            {
                string admin = AddAdmin().UserName;
                Users_Admin ad = be.Users_Admin.Find(admin);
                Assert.AreEqual(ad.UserName, admin);
                Assert.AreEqual(be.Users.Find(admin).UserName, admin);
                RemoveAdmin(admin);
            }
        }
        [TestMethod]
        public void TestUpdateAdmin()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = AddAdmin().UserName;
                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();
                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");
                RemoveAdmin(username);
            }
        }
        [TestMethod]
        public void TestRemoveAdmin()
        {
            string username = AddAdmin().UserName;
            using (basicEntities be = new basicEntities())
            {
                RemoveAdmin(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }


       

        public static Users_Admin AddAdmin(string UserName = "adminUserName", string Name = "adminName", string Password = "1234", int PhoneKidumet = 1234567, int PhoneNum = 123, string Email = "temp@temp.temp")
        {
            User a = TestUser.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
            using (basicEntities be = new basicEntities())
            {
                Users_Admin ua = new Users_Admin();
                ua.UserName = a.UserName;
                ua.User = a;
                be.Entry(a).State = System.Data.Entity.EntityState.Unchanged;
                be.Users_Admin.Add(ua);
                be.SaveChanges();
                return ua;
            }
        }

        public static void RemoveAdmin(string admin)
        {
            using (basicEntities be = new basicEntities())
            {
                Users_Admin AdminToRemove = be.Users_Admin.Find(admin);
                be.Users_Admin.Remove(AdminToRemove);
                be.SaveChanges();
            }
            TestUser.RemoveUser(admin);
        }
    }
}
