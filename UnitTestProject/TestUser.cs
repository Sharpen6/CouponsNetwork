using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

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
                User user = AddUser();
                Assert.AreEqual(be.Users.Find(user.UserName).UserName, user.UserName);
                RemoveUser(user.UserName);
            }
        }

        [TestMethod]
        public void TestUpdateUser()
        {
            using (basicEntities be = new basicEntities())
            {
                User user = AddUser();

                User b = be.Users.Find(user.UserName);
                b.PhoneNum =321;
                be.SaveChanges();


                Assert.AreEqual(be.Users.Find(user.UserName).PhoneNum, 321);
                RemoveUser(user.UserName);
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
            User user = AddUser();
            using (basicEntities be = new basicEntities())
            {
                RemoveUser(user.UserName);
                Assert.AreEqual(be.Users.Find(user.UserName), null);
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
        public static User AddUser(string UserName="UserName", string Name="userName", string Password="1234", int PhoneKidumet=123, int PhoneNum=1234567, string Email="temp@temp.temp")
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

                be.Users.Add(u);
                be.SaveChanges();
                return u;
            }
        }
    }
}
