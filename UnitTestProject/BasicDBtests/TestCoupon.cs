using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CouponsOnline;
using System.Web.UI.WebControls;
using CouponsOnline.BusinessLayer.Controllers;
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
        [TestMethod]
        public void TestDeleteCoupon()
        {
            Coupon coupon = AddCoupon();
            using (basicEntities be = new basicEntities())
            {
                coupon.DeleteCoupon();
                Assert.IsNull(be.Coupons.Find(coupon.Id));
            }
        }
        [TestMethod]
        public void TestFindCouponExp()
        {
            Coupon coupon = AddCoupon();
            Assert.AreEqual(coupon.FindCouponExpDate(), "10/10/2009");
            RemoveCoupon(coupon.Id);
        }
        [TestMethod]
        public void TestEditCoupon()
        {
            Coupon coupon = AddCoupon();
            ICollection<Interest> t = coupon.Interests;
            List<ListItem> items = new List<ListItem>();

            for (int i = 0; i < t.Count; i++)
            {
                Interest interest = t.ElementAt(i);
                items.Add(new ListItem(interest.Description,interest.Id.ToString()));
            }
            coupon.EditCoupon("blabla", 32, 31, "test", "11/10/2009", 4, items);
            Coupon cop =   CouponController.GetCoupon(coupon.Id.ToString());
            Assert.AreEqual("blabla", cop.Name);
            Assert.AreEqual(4, cop.MaxNum);
            Assert.AreEqual(32, cop.OriginalPrice);
            Assert.AreEqual("11/10/2009", cop.ExperationDate);
            RemoveCoupon(cop.Id);
        }
      
        
        public static Coupon AddCoupon(int id=2, string name="Flying pizza", string orgprice="100", string discount="50", string datee="10/10/2009",int maxNum=5)
        {
            Coupon cop = new Coupon();
            Business b = TestBusiness.AddBusiness();            
            cop.Id = id;
            cop.Name = name;
            cop.OriginalPrice = 1; //
            cop.DiscountPrice = 2; //
            
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
        public static void RemoveOnlyCoupon(int CouponID)
        {
            using (basicEntities be = new basicEntities())
            {
                Coupon CouponToRemove = be.Coupons.Find(CouponID);
                be.Entry(CouponToRemove.Business).State = System.Data.Entity.EntityState.Unchanged;
                foreach (var i in CouponToRemove.Interests) {
                    be.Entry(i).State = System.Data.Entity.EntityState.Unchanged;
                }
                be.Coupons.Remove(CouponToRemove);
                be.SaveChanges();
            }
        }
    }
}
