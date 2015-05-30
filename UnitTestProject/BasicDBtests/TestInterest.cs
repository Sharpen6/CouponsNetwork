using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    [TestClass]
    public class TestInterest
    {
        [TestMethod]
        public void TestAddInterest()
        {
            Interest interest = AddInterest();
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNotNull(be.Interests.Find(interest.Id));
            }
            RemoveInterest(interest.Id);
        }
        [TestMethod]
        public void TestRemoveInterest()
        {
            Interest interest = AddInterest();
            RemoveInterest(interest.Id);
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNull(be.Interests.Find(interest.Id));
            }            
        }
        [TestMethod]
        public void TestUpdateInterest()
        {
            Interest interest = AddInterest();
            using (basicEntities be = new basicEntities())
            {
                be.Interests.Find(interest.Id).Description = "test";
                be.SaveChanges();
                Assert.AreEqual(be.Interests.Find(interest.Id).Description, "test");
            }
            RemoveInterest(interest.Id);
        }
        public Interest AddInterest()
        {
            BusinessCategories bc = TestCategory.AddCategory();
            Interest i = new Interest();
            using (basicEntities be = new basicEntities())
            {
                i.BusinessCategory = bc;
                be.Entry(bc).State = System.Data.Entity.EntityState.Unchanged;
                i.Description = "blabla";
                i.Id = 1;
                be.Interests.Add(i);
                be.SaveChanges();
            }
            return i;
        }
        public void RemoveInterest(int i)
        {
            int bcID = 0;
            using (basicEntities be = new basicEntities())
            {
                Interest interest =  be.Interests.Find(i);
                if (interest != null)
                {
                    bcID = interest.BusinessCategory.Id;
                    be.Interests.Remove(interest);
                    be.SaveChanges();
                }
            }
            TestCategory.RemoveCategory(bcID);
        }
    }
}
