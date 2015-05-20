using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

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
                string username = TestOwnerAdd();
                Assert.AreEqual(be.Users.Find(username).UserName, username);
                RemoveOwner(username);

            }
        }

        public static string TestOwnerAdd()
        {
            using (basicEntities be = new basicEntities())
            {
                Owner o = AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                be.Users.Add(o);
                be.SaveChanges();
                return o.UserName;


            }
        }

        [TestMethod]
        public void TestUpdatePhoneOwner()
        {
            string username = TestOwnerAdd();
            using (basicEntities be = new basicEntities())
            {

                User user = be.Users.Find(username);
                user.PhoneNum = 2222222;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneNum, 2222222);
            }
            RemoveOwner(username);
        }

        /*[TestMethod]
        public void TestUpdateOwnerPhoneKidumet()
        {
            string username = TestOwnerAdd();
            using (basicEntities be = new basicEntities())
            {
                User user = be.Users.Find(username);
                user.PhoneKidomet = 052;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneKidomet, 052);
            }
            RemoveOwner(username);
        }*/


        [TestMethod]
        public void TestRemoveOwner()
        {
            string username = TestOwnerAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveOwner(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }

        public static Owner AddOwner(string UserName, String Name, String Password, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                Owner u = new Owner();
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

        public static void RemoveOwner(string owner)
        {
            using (basicEntities be = new basicEntities())
            {
                User userToRemove = be.Users.Find(owner);

                be.Users.Remove(userToRemove);
                be.SaveChanges();
            }
        }
    }
}
