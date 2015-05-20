using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

namespace UnitTestProject
{
    [TestClass]
    public class TestCustomerFriend
    {
        [TestMethod]
        public void TestAddCustomerFriend()
        {
            TestCustomer tc = new TestCustomer();

            using (basicEntities be = new basicEntities())
            {
                Customer c1 = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                Customer c2 = TestCustomer.AddCustomer("Customerfriend", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                c1.Customers1.Add(c2);
                be.Users.Add(c1);             
                be.SaveChanges();
                Assert.IsTrue(((Customer)be.Users.Find(c1.UserName)).Customers1.Contains(c2));
                TestCustomer.RemoveCustomer("Customer123");
                TestCustomer.RemoveCustomer("Customerfriend");
            }
        }
    }
}
