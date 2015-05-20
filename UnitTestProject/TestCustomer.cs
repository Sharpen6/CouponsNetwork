using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

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
                string username = TestCustomerAdd();
                Assert.AreEqual(be.Users.Find(username).UserName, username);
                RemoveCustomer(username);

            }
        }

        public string TestCustomerAdd()
        {
            using (basicEntities be = new basicEntities())
            {
                Customer c = AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                be.Users.Add(c);
                be.SaveChanges();
              
                return  c.UserName;
            }
        }

        [TestMethod]
        public void TestUpdatePhoneCustomer()
        {
            string username = TestCustomerAdd();
            using (basicEntities be = new basicEntities())
            {

                User user = be.Users.Find(username);
                user.PhoneNum = 2222222;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneNum, 2222222);
            }
            RemoveCustomer(username);
        }

        [TestMethod]
        public void TestUpdateCustomerPhoneKidumet()
        {
            string username = TestCustomerAdd();
            using (basicEntities be = new basicEntities())
            {
                User user = be.Users.Find(username);
                user.PhoneKidomet = 052;
                be.SaveChanges();

                Assert.AreEqual(be.Users.Find(username).PhoneKidomet, 052);
            }
            RemoveCustomer(username);
        }


        [TestMethod]
        public void TestRemoveCustomer()
        {
            string username = TestCustomerAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveCustomer(username);
                Assert.AreEqual(be.Users.Find(username), null);
            }
        }

        public static Customer AddCustomer(string UserName, String Name, String Password, int PhoneKidumet, int PhoneNum, string Email)
        {
            using (basicEntities be = new basicEntities())
            {
                Customer u = new Customer();
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

        public static void RemoveCustomer(string Customer)
        {
            using (basicEntities be = new basicEntities())
            {
                User userToRemove = be.Users.Find(Customer);

                be.Users.Remove(userToRemove);
                be.SaveChanges();
            }
        }


    }
}
