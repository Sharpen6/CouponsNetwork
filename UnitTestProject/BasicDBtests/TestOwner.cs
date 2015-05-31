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
