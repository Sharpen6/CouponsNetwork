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
        [TestMethod]
        public void TestAddLocation()
        {
            Location loc = AddLocation();
            using (basicEntities be = new basicEntities())
            {
                Assert.AreEqual(be.Locations.Find(loc.Id).Id, loc.Id);                
            }
            RemoveLocation(loc.Id);
        }
        [TestMethod]
        public void TestRemoveLocation()
        {
            Location loc = AddLocation();
            using (basicEntities be = new basicEntities())
            {            
                RemoveLocation(loc.Id);
                be.SaveChanges();
                Assert.IsNull(be.Locations.Find(loc.Id));
            }

        }
        [TestMethod]
        public void TestUpdateLocation()
        {
            Location loc = AddLocation();
            using (basicEntities be = new basicEntities())
            {              
                be.Locations.Find(loc.Id).Longitude = "31.4";
                be.Locations.Find(loc.Id).Altitude = "56.9";
                be.SaveChanges();
                Assert.AreEqual(be.Locations.Find(loc.Id).Altitude, "56.9");
                Assert.AreEqual(be.Locations.Find(loc.Id).Longitude, "31.4");
            }
            RemoveLocation(loc.Id);
        }
        public static Location AddLocation()
        {
            Location loc;
            Sensor s = TestSensor.AddSensor();
            using (basicEntities be = new basicEntities())
            {
                loc = new Location();
                loc.Sensor = s;
                be.Entry(s).State = System.Data.Entity.EntityState.Unchanged;
                loc.Id = 4;
                loc.Longitude = "30.4";
                loc.Altitude = "50.9";
                be.Locations.Add(loc);
                be.SaveChanges();
            }
            return loc;
        }
        public static void RemoveLocation(int id)
        {
            int sensorID=0;
            using (basicEntities be = new basicEntities())
            {
                Location s = be.Locations.Find(id);               
                if (s != null)
                {
                    sensorID = s.Sensor.Id;
                    be.Locations.Remove(s);
                    be.SaveChanges();
                    
                }
            }
            TestSensor.RemoveSensor(sensorID);
        }
    }
}
