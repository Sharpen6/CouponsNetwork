using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.PresentationLayer;
using CouponsOnline.BusinessLayer.Controllers;
using System.Web.UI.WebControls;

namespace UnitTestProject
{
    [TestClass]
    public class TestUser
    {
       [TestMethod]
       public void TestAddUser()
        {
            User user;
            using (basicEntities be = new basicEntities())
            {
                user = AddUser();
                Assert.AreEqual(be.Users.Find(user.UserName).UserName, user.UserName);
                
            }
            RemoveUser(user.UserName);
        }
       [TestMethod]
       public void TestUpdateUser()
        {
            using (basicEntities be = new basicEntities())
            {
                User user = AddUser();

                User b = be.Users.Find(user.UserName);
                b.PhoneNum ="321";
                be.SaveChanges();


                Assert.AreEqual(be.Users.Find(user.UserName).PhoneNum, "321");
                RemoveUser(user.UserName);
            }
        }
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

       [TestMethod]
       public void TestChangeDetails()
       {
            User user = AddUser();
            user.ChangeDetails("moshe", "123", "mal@ware.com", null);
            User a = UserController.GetUser(user.UserName);
            Assert.AreEqual(a.Name, "moshe");
            Assert.AreEqual(a.PhoneNum, "123");
            Assert.AreEqual(a.Email, "mal@ware.com");
            TestUser.RemoveUser(user.UserName);
       }

       // extended Tests
       [TestMethod]
       public void TestAddAuthentication()
       {
           User user = AddUser();
           user.AddAuthentication(UserType.Customer);
           Assert.AreEqual(user.GetUserType(),UserType.Customer);
           TestUser.RemoveUser(user.UserName);
       }
       [TestMethod]
       public void TestAuthenticateUser()
        {
            User user = AddUser();
            string password = user.Password;
            Assert.IsTrue(user.AuthenticateUser(password));
            RemoveUser(user.UserName);
       }
       [TestMethod]
       public void DeactivateUserTest()
       {
           Users_Customer u = TestCustomer.AddCustomer();
           User user = UserController.GetUser(u.UserName);
           Assert.IsTrue(user.AuthenticateUser(user.Password));
           user.Deactivate();
           Assert.IsFalse(user.AuthenticateUser(user.Password));
           TestCustomer.RemoveCustomer(u.UserName);
       }
       [TestMethod]
       public void ChangePasswordTest()
       {
           User u = TestUser.AddUser();
           u.ChangePassword("blabla123");
           Assert.IsTrue(u.AuthenticateUser("blabla123"));
           TestUser.RemoveUser(u.UserName);
       }
       [TestMethod]
       public void GetUserTypeTest()
       {
           Users_Admin ua = TestAdmin.AddAdmin();
           Assert.AreEqual(ua.User.GetUserType(), UserType.Admin);
           TestAdmin.RemoveAdmin(ua.UserName);
       }

       //aux functions
       public static void RemoveUser(string user)
        {
            using (basicEntities be = new basicEntities())
            {
                User userToRemove = be.Users.Find(user);
                if (userToRemove != null)
                {
                    be.Users.Remove(userToRemove);
                    be.SaveChanges();
                }
            }
        }
       public static User AddUser(string UserName="UserName", string Name="userName", string Password="1234",
           string PhoneNum="1234567", string Email="temp@temp.temp")
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
                u.PhoneNum = PhoneNum;
                u.Email = Email;

                be.Users.Add(u);
                be.SaveChanges();
                return u;
            }
        }
    }
}
