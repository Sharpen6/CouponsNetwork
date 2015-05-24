using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

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
                Sensor s = new Sensor();
                loc.Sensor = s;
                loc.Id = 4;
                loc.Longitude = "30.4";
                loc.Altitude = "50.9";
                be.Locations.Add(loc);             
                be.SaveChanges();
                Assert.AreEqual(be.Locations.Find(loc.Id).Altitude, loc.Altitude);
                Assert.AreEqual(be.Locations.Find(loc.Id).Longitude, loc.Longitude);
            }
        }
        [TestMethod]
        public void TestRemoveLocation()
        {
            using (basicEntities be = new basicEntities())
            {
                loc = new Location();

                loc.Id = 4;
                loc.Longitude = "30.4";
                loc.Altitude = "50.9";
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
                loc.Longitude = "30.4";
                loc.Altitude = "50.9";
                be.Locations.Add(loc);
                be.SaveChanges();

                loc.Longitude = "31.4";
                loc.Altitude = "56.9";
                be.SaveChanges();
                Assert.AreEqual(be.Locations.Find(loc.Id).Altitude, loc.Altitude);
                                Assert.AreEqual(be.Locations.Find(loc.Id).Longitude, loc.Longitude);
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
