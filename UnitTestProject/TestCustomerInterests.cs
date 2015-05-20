using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coupon;
namespace UnitTestProject
{
    [TestClass]
    public class TestCustomerInterests
    {
        Customer customer;
        CustomerIntrests ci;
        [TestInitialize]
        public void TestInit()
        {
            
            
        }
        
        [TestMethod]
        public void TestAddCustomerInterests()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                
                be.Users.Add(customer);
                
                be.SaveChanges();

                ci = new CustomerIntrests();

                ci.InterestID = InterestType.Dancing;
                ci.CustomerUserName = customer.UserName;

                be.CustomerIntrests.Add(ci);
                be.SaveChanges();


                Assert.AreEqual(be.CustomerIntrests.Find(ci.CustomerUserName, ci.InterestID).CustomerUserName, ci.CustomerUserName);
               
            }
        }

        [TestMethod]
        public void TestRemoveCustomerInterests()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");

                be.Users.Add(customer);

                be.SaveChanges();

                ci = new CustomerIntrests();

                ci.InterestID = InterestType.Dancing;
                ci.CustomerUserName = customer.UserName;

                be.CustomerIntrests.Add(ci);
                be.SaveChanges();



                CustomerIntrests c = be.CustomerIntrests.Find(ci.CustomerUserName, ci.InterestID);

                if (c != null)
                {
                    be.CustomerIntrests.Remove(c);
                    be.Users.Remove(be.Users.Find(customer.UserName));
                    be.SaveChanges();
                }
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (basicEntities be = new basicEntities())
            {
                CustomerIntrests c = be.CustomerIntrests.Find(ci.CustomerUserName, ci.InterestID);

                if (c != null)
                {
                    be.CustomerIntrests.Remove(c);
                    be.Users.Remove(be.Users.Find(customer.UserName));
                    be.SaveChanges();
                }
            }
        }
    }
}
