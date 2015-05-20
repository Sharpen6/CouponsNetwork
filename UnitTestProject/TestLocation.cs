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
    public class TestLocation
    {
        Location loc;

        [TestInitialize]
        public void TestInit()
        {

        }

        [TestMethod]
        public void TestAddLocation()
        {
            using (basicEntities be = new basicEntities())
            {
                loc = new Location();

                loc.Id = 4;
                loc.Coordinates = "34N 40' 50.12";          
                be.Locations.Add(loc);             
                be.SaveChanges();
                Assert.AreEqual(be.Locations.Find(loc.Id).Coordinates, loc.Coordinates);
            }
        }
        [TestMethod]
        public void TestRemoveLocation()
        {
            using (basicEntities be = new basicEntities())
            {
                loc = new Location();

                loc.Id = 4;
                loc.Coordinates = "34N 40' 50.12";
                be.Locations.Add(loc);
                be.SaveChanges();

                be.Locations.Remove(be.Locations.Find(loc.Id));
                be.SaveChanges();
                Assert.IsNull(be.Locations.Find(loc.Id));
            }
        }
        [TestMethod]
        public void TestUpdateLocation()
        {
            using (basicEntities be = new basicEntities())
            {
                loc = new Location();

                loc.Id = 4;
                loc.Coordinates = "34N 40' 50.12";
                be.Locations.Add(loc);
                be.SaveChanges();

                loc.Coordinates = "36S 24' 51.35";
                be.SaveChanges();
                Assert.AreEqual(be.Locations.Find(loc.Id).Coordinates, loc.Coordinates);
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            using (basicEntities be = new basicEntities())
            {
                if (be.Locations.Find(loc.Id) != null)
                {
                    be.Locations.Remove(be.Locations.Find(loc.Id));
                    be.SaveChanges();
                }

            }
        }
    }
}
