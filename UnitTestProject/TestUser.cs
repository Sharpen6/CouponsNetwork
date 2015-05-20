using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

namespace UnitTestProject
{
    [TestClass]
    public class TestUser
    {
        [TestMethod]
        public void TestAddUser()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = TestUserAdd();
                Assert.AreEqual(be.Users.Find(username).UserName, username);
                RemoveUser(username);
            }
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = TestUserAdd();

                be.Users.Find(username).Name = "sos";
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).Name, "sos");
                RemoveUser(username);
            }
        }
        public static string TestUserAdd()
        {
            using (basicEntities be = new basicEntities())
            {
                User u = AddUser("User123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                be.Users.Add(u);
                be.SaveChanges();
                return u.UserName;
            }
        }

        /*[TestMethod]
        public void TestUpdatePhoneUser()
        {
            string username = TestUserAdd();
            using (basicEntities be = new basicEntities())
            {

                User user = be.Users.Find(username);
                user.PhoneNum = 2222222;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneNum, 2222222);
            }
            RemoveUser(username);
        }
        */
        /*[TestMethod]
        public void TestUpdatePhoneKidumet()
        {
            string username = TestUserAdd();
            using (basicEntities be = new basicEntities())
            {
                User user = be.Users.Find(username);
                user.PhoneKidomet = 052;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneKidomet, 052);
            }
            RemoveUser(username);
        }
        */
        [TestMethod]
        public void TestRemoveUser()
        {
            string username = TestUserAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveUser(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }

        public static void RemoveUser(string user)
        {
            using (basicEntities be = new basicEntities())
            {
                User userToRemove = be.Users.Find(user);
                be.Users.Remove(userToRemove);
                be.SaveChanges();
            }
        }

        public static User AddUser(string UserName, String Name, String Password, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                User u = new User();
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

                return u;
            }
        }
    }
}
