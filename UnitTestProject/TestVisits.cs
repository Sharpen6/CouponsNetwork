using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Coupon;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for TestVisits
    /// </summary>
    [TestClass]
    public class TestVisits
    {
        User customer;
        Visit visit;
        Location l;
        [TestInitialize]
        public void TestInit()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = be.Users.Find("customer");
                if (customer == null)
                {

                    customer = new Customer();
                    customer.Name = "adam";
                    customer.UserName = "customer";
                    customer.Password = "admin123123";
                    customer.PhoneKidomet = 054;
                    customer.PhoneNum = 3134195;
                    customer.Email = "adamin@gmail.com";
                }
            }
        }

        [TestMethod]
        public void TestAddVisit()
        {
            using (basicEntities be = new basicEntities())
            {
                
                visit = new Visit();
                visit.Id = 1;
                visit.Date = "01/01/2004";
                l = new Location();
                l.Coordinates = "34N 40' 50.12";
                visit.Location = l;
                ((Customer)customer).Visits.Add(visit);
                be.Users.Add(customer);
                be.Visits.Add(visit);              
                be.SaveChanges();

                Assert.AreEqual(be.Visits.Find(visit.Id).Location, visit.Location);
            }
        }

        [TestMethod]
        public void TestRemoveVisit()
        {
            using (basicEntities be = new basicEntities())
            {

                visit = new Visit();
                visit.Id = 1;
                visit.Date = "01/01/2004";
                Location l = new Location();
                l.Coordinates = "34N 40' 50.12";
                visit.Location = l;
                ((Customer)customer).Visits.Add(visit);
                be.Users.Add(customer);
                be.Visits.Add(visit);

                be.SaveChanges();

                
                be.Visits.Remove(be.Visits.Find(visit.Id));
                be.Users.Remove(be.Users.Find("customer"));
                be.Locations.Remove(be.Locations.Find(l.Id));
                be.SaveChanges();


                Assert.IsNull(be.Visits.Find(visit.Id));
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            using (basicEntities be = new basicEntities())
            {
                if (be.Visits.Find(visit.Id) != null)
                {                   
                    be.Visits.Remove(be.Visits.Find(visit.Id));
                    be.Users.Remove(be.Users.Find("customer"));
                    be.Locations.Remove(be.Locations.Find(l.Id));
                    be.SaveChanges();
                }
            }
        }
    }
}
