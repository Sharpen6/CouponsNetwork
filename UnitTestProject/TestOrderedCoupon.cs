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
    public class TestOrderedCoupon
    {       
        [TestMethod]
        public void TestAddOrderedCoupon()
        {
            OrderedCoupon oc = AddOrderedCoupon();
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNotNull(be.OrderedCoupons.Find(oc.SerialNum));              
            }
            RemoveOrderedCoupon(oc.SerialNum);
        }

        [TestMethod]
        public void TestRemoveOrderedCoupon()
        {
            using (basicEntities be = new basicEntities())
            {
                
            }
        }

        [TestMethod]
        public void TestUpdateOrderedCoupon()
        {
            using (basicEntities be = new basicEntities())
            {
               
            }
        }
        public OrderedCoupon AddOrderedCoupon()
        {
            OrderedCoupon oc = new OrderedCoupon();
            oc.Coupon = TestCoupon.AddCoupon();
            oc.Users_Customer = TestCustomer.AddCustomer();
            using (basicEntities be = new basicEntities())
            {
                oc.Opinion = "";
                oc.PurchaseDate = DateTime.Now.ToShortDateString();
                oc.Rank = 0;
                oc.SerialNum = 1;
                oc.UseDate = "";
                oc.Status = StatusType.NotUsed;
                be.Entry(oc.Coupon).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(oc.Users_Customer).State = System.Data.Entity.EntityState.Unchanged;
                be.OrderedCoupons.Add(oc);
                be.SaveChanges();
            }
            return oc;
        }

        public void RemoveOrderedCoupon(int id)
        {
            string user="";
            int couponID = 0;
            using (basicEntities be = new basicEntities())
            {
                OrderedCoupon oc = be.OrderedCoupons.Find(id);
                if (oc != null)
                {
                    user = oc.Users_Customer.UserName;
                    couponID = oc.Coupon.Id;
                    be.OrderedCoupons.Remove(oc);
                    be.SaveChanges();
                }
            }
            TestCoupon.RemoveCoupon(couponID);
            TestCustomer.RemoveCustomer(user);
        }
    }
}
