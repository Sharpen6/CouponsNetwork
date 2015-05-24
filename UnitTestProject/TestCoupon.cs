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
        int Businessid;
        int coupon;
  
        [TestMethod]
        public void TestAddCoupon()
        {
            coupon=TestCouponAdd();
            using (basicEntities be = new basicEntities())
            {
                Assert.AreEqual(be.Coupons.Find(coupon).Id, coupon);
            }

        }

        [TestMethod]
        public void TestUpdateCoupon()
        {
            coupon = TestCouponAdd();
            using (basicEntities be = new basicEntities())
            {
                be.Coupons.Find(coupon).Description = "blablabla";
                be.SaveChanges();
                Assert.AreEqual(be.Coupons.Find(coupon).Description, "blablabla");
            }

        }
        public int TestCouponAdd()
        {
            TestBusiness bn = new TestBusiness();
            Businessid = bn.AddBusiness();
            using (basicEntities be = new basicEntities())
            {
                Business b = be.Businesses.Find(Businessid);
                Coupon cop = CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014",8);
                be.Coupons.Add(cop);
                be.SaveChanges();
                return cop.Id;


            }
        }

        public static Coupon CreateCoupon(int id, string name, string orgprice, string discount, Business b, string datee,int maxNum)
        {
            Coupon cop = new Coupon();
            cop.Id = id;
            cop.Name = name;
            cop.OriginalPrice = orgprice;
            cop.DiscountPrice = discount;
            cop.Business = b;
            cop.ExperationDate = datee;
            cop.MaxNum = maxNum;
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

        [TestMethod]
        public void TestRemoveCoupon()
        {

             coupon = TestCouponAdd();
            using (basicEntities be = new basicEntities())
            {
                RemoveCoupon(coupon);
                Assert.AreEqual(be.Coupons.Find(coupon), null);
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            using (basicEntities be = new basicEntities())
            {
                if (be.Coupons.Find(coupon) != null)
                {

                    be.Coupons.Remove(be.Coupons.Find(coupon));
                    be.SaveChanges();
                    TestBusiness.RemoveBusinesses(Businessid);
                    be.SaveChanges();
               
                }
            }
        }
    }
}
