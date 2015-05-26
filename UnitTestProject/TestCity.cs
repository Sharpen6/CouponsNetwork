using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using System.Data.Entity;

namespace UnitTestProject
{
    [TestClass]
    public class TestCity
    {
        [TestMethod]
        public void TestAddCity()
        {
            using (basicEntities be = new basicEntities())
            {
                City c = AddCity();
                Assert.AreEqual(be.Cities.Find(c.Id).Name, c.Name);
                RemoveCity(c.Id);
            }

        }
        [TestMethod]
        public void TestUpdateCity()
        {
            using (basicEntities be = new basicEntities())
            {
                City c = AddCity();
                
                c.Name = "Tel Aviv";
                be.Cities.Attach(c);
                be.Entry(c).State = EntityState.Modified;
                be.SaveChanges();

                Assert.AreEqual(be.Cities.Find(c.Id).Name, "Tel Aviv");
                RemoveCity(c.Id);
            }
            
        }
        [TestMethod]
        public void TestRemoveCity()
        {
            City c = AddCity();
            RemoveCity(c.Id);
            using (basicEntities be = new basicEntities())
            {
                City a = be.Cities.Find(c.Id);
                Assert.IsNull(a);
            }
        }
        public static City AddCity()
        {
            using (basicEntities be = new basicEntities())
            {
                City c = new City();
                c.Name = "Beer Aviv";
                be.Cities.Add(c);
                be.SaveChanges();
                return c;
            }
        }
        public static void RemoveCity(int id)
        {
            using (basicEntities be = new basicEntities())
            {
                City c = be.Cities.Find(id);
                if (c != null)
                {
                    be.Cities.Remove(c);
                    be.SaveChanges();
                }
            }
        }
    }
}
