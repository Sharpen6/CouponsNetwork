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
            string admin;
            using (basicEntities be = new basicEntities())
            {
                admin = AddAdmin().UserName;
                Users_Admin ad = be.Users_Admin.Find(admin);
                Assert.AreEqual(ad.UserName, admin);
                Assert.AreEqual(be.Users.Find(admin).UserName, admin);              
            }
            RemoveAdmin(admin);
        }
        [TestMethod]
        public void TestUpdateAdmin()
        {
            string username;
            using (basicEntities be = new basicEntities())
            {
                username = AddAdmin().UserName;
                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();
                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");
            }
            RemoveAdmin(username);
        }
        [TestMethod]
        public void TestRemoveAdmin()
        {
            string username = AddAdmin().UserName;
            RemoveAdmin(username);
            using (basicEntities be = new basicEntities())
            {
                Assert.AreEqual(be.Users.Find(username), null);
            }
            
        }


       

        public static Users_Admin AddAdmin(string UserName = "adminUserName", string Name = "adminName", string Password = "1234", string PhoneNum = "123", string Email = "temp@temp.temp")
        {
            User a = TestUser.AddUser(UserName, Name, Password, PhoneNum, Email);
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
                foreach (var item in be.Businesses)
                {
                    if (item.Users_Admin.UserName == admin)
                        return;
                }
                Users_Admin AdminToRemove = be.Users_Admin.Find(admin);
                if (AdminToRemove != null)
                {
                    be.Users_Admin.Remove(AdminToRemove);
                    be.SaveChanges();
                }
            }
            TestUser.RemoveUser(admin);
        }
    }
}
