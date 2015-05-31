using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using System.Collections.Generic;


namespace UnitTestProject
{
    [TestClass]
    public class TestUserInterests
    {
        [TestMethod]
        public void TestAddUserInterests()
        {
            Users_Customer u = CreateUserInterest();
            using (basicEntities be = new basicEntities())
            {
                Assert.IsTrue(be.Users_Customer.Find(u.UserName).Interests.Count > 0);
            }
            RemoveUserInterest(u);
        }

        [TestMethod]
        public void TestRemoveUserInterests()
        {
            Users_Customer u = TestCustomer.AddCustomer();
            Interest i = TestInterest.AddInterest();
            using (basicEntities be = new basicEntities())
            {

                be.Users_Customer.Find(u.UserName).Interests.Add(be.Interests.Find(i.Id));
                be.SaveChanges();
                be.Users_Customer.Find(u.UserName).Interests.Remove(be.Interests.Find(i.Id));
                be.SaveChanges();
                Assert.IsTrue(be.Users_Customer.Find(u.UserName).Interests.Count == 0);
            }
            TestCustomer.RemoveCustomer(u.UserName);
        }


        public void RemoveUserInterest(Users_Customer u) {
            ICollection<Interest> collection=null;
            using (basicEntities be = new basicEntities())
            {
                collection = be.Users_Customer.Find(u.UserName).Interests;
                be.Users_Customer.Find(u.UserName).Interests.Clear();
                be.SaveChanges();
            }
            TestCustomer.RemoveCustomer(u.UserName);
            foreach (var item in collection)
	        {
                TestInterest.RemoveInterest(item.Id);
	        }
        }
        public Users_Customer CreateUserInterest()
        {
            Interest i = TestInterest.AddInterest();
            Users_Customer u = TestCustomer.AddCustomer();
            using (basicEntities be = new basicEntities())
            {
                Interest interest = be.Interests.Find(i.Id);
                be.Entry(interest).State = System.Data.Entity.EntityState.Unchanged;
                be.Users_Customer.Find(u.UserName).Interests.Add(interest);              
                be.SaveChanges();
            }
            return u;
        }
    }
}
