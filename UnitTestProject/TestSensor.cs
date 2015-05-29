using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using System.Data.Entity;


namespace UnitTestProject
{
    [TestClass]
    public class TestSensor
    {
        [TestMethod]
        public void TestAddSensor()
        {
            int id = 0;
            using (basicEntities be = new basicEntities())
            {
                Sensor s = AddSensor();
                id = s.Id;
                Assert.AreEqual(be.Sensors.Find(s.Id).Id, s.Id);
                
            }
            RemoveSensor(id);

        }
        //[TestMethod] nothing to modify
        public void TestUpdateSensor()
        {
            /*using (basicEntities be = new basicEntities())
            {
                Sensor s = AddSensor();
                be.Sensors.Add(s);
                be.SaveChanges();
                Assert.AreEqual(be.Sensors.Find(s.Id).Id, );
                RemoveSensor(s.Id);
            }*/
        }
        
        [TestMethod]
        public void TestRemoveSensor()
        {
            Sensor s = AddSensor();
            RemoveSensor(s.Id);
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNull(be.Sensors.Find(s.Id));
            }
        }
        public static Sensor AddSensor()
        {
            using (basicEntities be = new basicEntities())
            {
                Sensor s = new Sensor();               
                be.Sensors.Add(s);
                be.SaveChanges();
                return s;
            }
        }
        public static void RemoveSensor(int id)
        {
            using (basicEntities be = new basicEntities())
            {
                Sensor s = be.Sensors.Find(id);
                if (s != null)
                {
                    be.Sensors.Remove(s);
                    be.SaveChanges();
                }
            }
        }
    }
}
