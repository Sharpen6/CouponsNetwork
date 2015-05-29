using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouponsOnline;
namespace UnitTestProject
{
    [TestClass]
    public class TestCoupon
    {
        [TestMethod]
        public void TestAddCoupon()
        {
            Coupon coupon = AddCoupon();
            using (basicEntities be = new basicEntities())
            {
                Assert.AreEqual(be.Coupons.Find(coupon.Id).Id, coupon.Id);
            }
            RemoveCoupon(coupon.Id);
        }

        [TestMethod]
        public void TestUpdateCoupon()
        {
            Coupon coupon = AddCoupon();
            using (basicEntities be = new basicEntities())
            {
                be.Coupons.Find(coupon.Id).Description = "blablabla";
                be.SaveChanges();
                Assert.AreEqual(be.Coupons.Find(coupon.Id).Description, "blablabla");
            }
            RemoveCoupon(coupon.Id);
        }
        [TestMethod]
        public void TestRemoveCoupon()
        {

            Coupon coupon = AddCoupon();
            using (basicEntities be = new basicEntities())
            {
                RemoveCoupon(coupon.Id);
                Assert.IsNull(be.Coupons.Find(coupon.Id));
            }
        }

        public static Coupon AddCoupon(int id=2, string name="Flying pizza", string orgprice="100", string discount="50", string datee="10/10/2009",int maxNum=5)
        {
            Coupon cop = new Coupon();
            Business b = TestBusiness.AddBusiness();            
            cop.Id = id;
            cop.Name = name;
            cop.OriginalPrice = orgprice;
            cop.DiscountPrice = discount;
            
            cop.Business = b;
            cop.ExperationDate = datee;
            cop.MaxNum = maxNum;
            using (basicEntities be = new basicEntities())
            {
                be.Entry(b).State = System.Data.Entity.EntityState.Unchanged;
                be.Coupons.Add(cop);
                be.SaveChanges();
            }
            return cop;
        }

        public static void RemoveCoupon(int CouponID)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon CouponToRemove = be.Coupons.Find(CouponID);
                int Businessid = CouponToRemove.Business.BusinessID;
                be.Coupons.Remove(CouponToRemove);
                be.SaveChanges();
                TestBusiness.RemoveBusinesses(Businessid);
                be.SaveChanges();
            }
        }
    }
}
