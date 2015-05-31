using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.DataLayer;

namespace UnitTestProject
{
    [TestClass]
    public class UserDataAccessTests
    {
        [TestMethod]
        public void FindAdminTest()
        {
            Users_Admin ua = TestAdmin.AddAdmin();
            Assert.IsNotNull(UserDataAccess.FindAdmin(ua.UserName));
            Assert.IsNull(UserDataAccess.FindCustomer(ua.UserName));
            Assert.IsNull(UserDataAccess.FindOwner(ua.UserName));
            Assert.IsNotNull(UserDataAccess.GetUser(ua.UserName));
            TestAdmin.RemoveAdmin(ua.UserName);
        }
        [TestMethod]
        public void FindOwnerTest()
        {
            Users_Owner ua = TestOwner.AddOwner();
            Assert.IsNull(UserDataAccess.FindAdmin(ua.UserName));
            Assert.IsNull(UserDataAccess.FindCustomer(ua.UserName));
            Assert.IsNotNull(UserDataAccess.FindOwner(ua.UserName));
            Assert.IsNotNull(UserDataAccess.GetUser(ua.UserName));
            TestOwner.RemoveOwner(ua.UserName);
        }
        [TestMethod]
        public void FindCustomerTest()
        {
            Users_Customer ua = TestCustomer.AddCustomer();
            Assert.IsNull(UserDataAccess.FindAdmin(ua.UserName));
            Assert.IsNotNull(UserDataAccess.FindCustomer(ua.UserName));
            Assert.IsNull(UserDataAccess.FindOwner(ua.UserName));
            Assert.IsNotNull(UserDataAccess.GetUser(ua.UserName));
            TestCustomer.RemoveCustomer(ua.UserName);
        }
        [TestMethod]
        public void GetUserTest()
        {
            User u = TestUser.AddUser();
            Assert.IsNotNull(UserDataAccess.GetUser(u.UserName));
            TestUser.RemoveUser(u.UserName);
        }
    }
}