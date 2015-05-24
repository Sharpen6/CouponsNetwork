using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    [TestClass]
    public class TestCustomer
    {
        [TestMethod]
        public void TestAddCustomer()
        {
            using (basicEntities be = new basicEntities())
            {
                string customer = AddCustomer();
                Users_Customer ad = be.Users_Customer.Find(customer);
                Assert.AreEqual(ad.UserName, customer);
                Assert.AreEqual(be.Users.Find(customer).UserName, customer);
                RemoveCustomer(customer);
            }
        }
        [TestMethod]
        public void TestUpdateCustomer()
        {
            using (basicEntities be = new basicEntities())
            {
                string username = AddCustomer();
                be.Users.Find(username).Name = "xerxses";
                be.SaveChanges();
                Assert.AreEqual(be.Users.Find(username).Name, "xerxses");
                RemoveCustomer(username);
            }
        }
        [TestMethod]
        public void TestRemoveCustomer()
        {
            string customer = AddCustomer();
            using (basicEntities be = new basicEntities())
            {
                RemoveCustomer(customer);
                Assert.AreEqual(be.Users.Find(customer), null);
                Assert.AreEqual(be.Users_Customer.Find(customer), null);
            }
        }

        public static string AddCustomer(string UserName = "customerUserName", string Name = "customerName", string Password = "1234", int PhoneKidumet = 1234567, int PhoneNum = 123, string Email = "temp@temp.temp")
        {
            User a =TestUser.AddUser(UserName, Name, Password, PhoneKidumet, PhoneNum, Email);
            using (basicEntities be = new basicEntities())
            {
                Users_Customer ua = new Users_Customer();
                ua.UserName = a.UserName;
                ua.User = a;
                be.Entry(a).State = System.Data.Entity.EntityState.Unchanged; 
                be.Users_Customer.Add(ua);
                be.SaveChanges();
                return ua.UserName;
            }
        }

        public static void RemoveCustomer(string Customer)
        {           
            using (basicEntities be = new basicEntities())
            {
                Users_Customer customerToRemove = be.Users_Customer.Find(Customer);
                be.Users_Customer.Remove(customerToRemove);
                be.SaveChanges();
            }
            TestUser.RemoveUser(Customer);
        }


    }
}
