using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupons;

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
                string username=TestAdminAdd();
                Assert.AreEqual(be.Users.Find(username).UserName, username);
                RemoveAdmin(username);

            }
        }

        [TestMethod]
        public void TestUpdateAdmin()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = TestAdminAdd();

                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");

                RemoveAdmin(username);

            }
        }
        public static string TestAdminAdd()
        {
            using (basicEntities be = new basicEntities())
            {
                Admin A = AddAdmin("Admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                be.Users.Add(A);
                be.SaveChanges();

                return A.UserName;
 

            }
        }

        [TestMethod]
        public void TestUpdatePhoneAdmin()
        {
            string username = TestAdminAdd();
            using (basicEntities be = new basicEntities())
            {

                User user = be.Users.Find(username);
                user.PhoneNum = 2222222;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneNum, 2222222);
            }
            RemoveAdmin(username);
        }

        /*[TestMethod]
        public void TestUpdateAdminPhoneKidumet()
        {
            string username = TestAdminAdd();
            using (basicEntities be = new basicEntities())
            {
                User user = be.Users.Find(username);
                user.PhoneKidomet = 052;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneKidomet, 052);
            }
            RemoveAdmin(username);
        }*/

        [TestMethod]
        public void TestRemoveAdmin()
        {
            string username=TestAdminAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveAdmin(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }

        public static Admin AddAdmin(string UserName, String Name, String Password, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                Admin u = new Admin();
                u.Name = Name;
                u.UserName = UserName;
                User sameKey = be.Users.Find(u.UserName);
                while (sameKey != null && sameKey.UserName.ToLower() == u.UserName.ToLower())
                {
                    u.UserName += "1";
                    sameKey = be.Users.Find(u.UserName);
                }
                u.Password = Password;
                u.PhoneKidomet = PhoneKidumet;
                u.PhoneNum = PhoneNum;
                u.Email = Email;

                string originalName = u.UserName;
                return u;
            }
        }

        public static void RemoveAdmin(string admin)
        {
            using (basicEntities be = new basicEntities())
            {
               
                User AdminToRemove = be.Users.Find(admin);

                be.Users.Remove(AdminToRemove);
                be.SaveChanges();
            }
        }
    }
}
