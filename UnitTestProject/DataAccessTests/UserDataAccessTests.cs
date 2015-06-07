using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.DataLayer;
using CouponsOnline.View;
using System.Collections.Generic;

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
            Assert.IsNotNull(UserDataAccess.GetUser(ua.UserName));
            TestAdmin.RemoveAdmin(ua.UserName);
        }
        [TestMethod]
        public void FindOwnerTest()
        {
            Users_Owner ua = TestOwner.AddOwner();
            Assert.IsNotNull(UserDataAccess.FindOwner(ua.UserName));
            Assert.IsNotNull(UserDataAccess.GetUser(ua.UserName));
            TestOwner.RemoveOwner(ua.UserName);
        }
        [TestMethod]
        public void FindCustomerTest()
        {
            Users_Customer ua = TestCustomer.AddCustomer();
            Assert.IsNotNull(UserDataAccess.FindCustomer(ua.UserName));
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
        [TestMethod]
        public void GetAuthenticationTest()
        {
            Users_Customer uc = TestCustomer.AddCustomer();
            Assert.AreEqual(UserDataAccess.GetAuthentication(uc.UserName),UserType.Customer);
            TestCustomer.RemoveCustomer(uc.UserName);
        }
        [TestMethod]
        public void UpdateInfoTest()
        {
            User u = TestUser.AddUser();
            UserDataAccess.UpdateInfo(u.UserName, "blag", "phone132", "123");
            Assert.AreEqual(UserDataAccess.GetUser(u.UserName).PhoneNum, "phone132");
            TestUser.RemoveUser(u.UserName); 
        }
        [TestMethod]
        public void UpdateInterestsToUserTest()
        {
            Users_Customer u = TestCustomer.AddCustomer();
            Interest i = TestInterest.AddInterest();
            List<string> inte = new List<string>();
            inte.Add(i.Id.ToString());
            UserDataAccess.UpdateInterestsToUser(u.UserName, inte);
            u = UserDataAccess.FindCustomer(u.UserName); 
            foreach (var item in u.Interests)
	        {
		         Assert.IsTrue(item.Id==i.Id);
	        }
            using (basicEntities be = new basicEntities())
            {
                Interest interest = be.Interests.Find(i.Id);
                be.Users_Customer.Find(u.UserName).Interests.Remove(interest);
                be.SaveChanges();
            }
            TestCustomer.RemoveCustomer(u.UserName);
            TestInterest.RemoveInterest(i.Id);
        }
        [TestMethod]
        public void ChangePasswordTest()
        {
            Users_Customer uc = TestCustomer.AddCustomer();
            UserDataAccess.ChangePassword(uc.UserName, "blabla");
            Assert.IsTrue(UserDataAccess.CheckCredentials(uc.UserName,"blabla"));
            TestCustomer.RemoveCustomer(uc.UserName);
        }
        [TestMethod]
        public void AddAuthenticationTest()
        {
            User u = TestUser.AddUser();
            UserDataAccess.AddAuthentication(u.UserName, UserType.Customer);
            Assert.AreEqual(UserDataAccess.GetAuthentication(u.UserName), UserType.Customer);
            TestCustomer.RemoveCustomer(u.UserName);
        }
        [TestMethod]
        public void CheckCredentialsTest()
        {
            Users_Customer uc = TestCustomer.AddCustomer();
            UserDataAccess.ChangePassword(uc.UserName, "blabla");
            Assert.IsTrue(UserDataAccess.CheckCredentials(uc.UserName, "blabla"));
            TestCustomer.RemoveCustomer(uc.UserName);
        }
        public void AddUserTest()
        {
            UserDataAccess.AddUser("avi", "avi", "avi", "043", "avi");
            User u = UserDataAccess.GetUser("avi");
            Assert.IsTrue(UserDataAccess.CheckCredentials(u.UserName, "avi"));
            TestUser.RemoveUser(u.UserName);      
        }
        public void RemoveUserTest()
        {
            User u = TestUser.AddUser();
            UserDataAccess.RemoveUser(u.UserName);
            Assert.IsNull(UserDataAccess.GetUser(u.UserName));
        }
    }
}