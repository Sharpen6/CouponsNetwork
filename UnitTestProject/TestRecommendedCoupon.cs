using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{

    [TestClass]
    public class TestRecommendedCoupon
    {
       
        [TestMethod]
        public void TestAddRecommendation()
        {
            RecommendedCoupon rec = AddRecommendedCoupon();
            using (basicEntities be = new basicEntities())
            {
                Assert.AreEqual(be.RecommendedCoupons.Find(rec.Id).Link, rec.Link);
            }
            RemoveRecommendedCoupon(rec.Id);
        }
        [TestMethod]
        public void TestRemoveRecommendation()
        {
            RecommendedCoupon rec = AddRecommendedCoupon();
            RemoveRecommendedCoupon(rec.Id);
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNull(be.RecommendedCoupons.Find(rec.Id));
            }
        }
        [TestMethod]
        public void TestUpdateRecommendation()
        {
            RecommendedCoupon rec = AddRecommendedCoupon();
            using (basicEntities be = new basicEntities())
            {
                be.RecommendedCoupons.Find(rec.Id).Link = "blabla";
                be.SaveChanges();
                Assert.AreEqual(be.RecommendedCoupons.Find(rec.Id).Link, "blabla");
            }
            RemoveRecommendedCoupon(rec.Id);
        }
        public void RemoveRecommendedCoupon(int id)
        {
            RecommendedCoupon rc;
            int copID = 0;
            string customerName = "";
            using (basicEntities be = new basicEntities())
            {
                rc = be.RecommendedCoupons.Find(id);
                if (rc != null)
                {
                    customerName = rc.Users_Customer.UserName;
                    copID = rc.Coupon.Id;
                    be.RecommendedCoupons.Remove(rc);
                    be.SaveChanges();
                }
            }
            TestCustomer.RemoveCustomer(customerName);
            TestCoupon.RemoveCoupon(copID);
        }

        public RecommendedCoupon AddRecommendedCoupon()
        {
            RecommendedCoupon rc = new RecommendedCoupon();
            rc.Approved = false;
            rc.Coupon = TestCoupon.AddCoupon();
            rc.Link = "www.facebook.com";
            rc.Source = SourceType.Facebook;
            rc.Id = 1;
            rc.Users_Customer = TestCustomer.AddCustomer();
            using (basicEntities be = new basicEntities())
            {
                be.Entry(rc.Coupon).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(rc.Users_Customer).State = System.Data.Entity.EntityState.Unchanged;
                be.RecommendedCoupons.Add(rc);                
                be.SaveChanges();
            }
            return rc;
        }
    }
}
