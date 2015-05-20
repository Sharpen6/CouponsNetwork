using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coupon;
namespace UnitTestProject
{
    [TestClass]
    public class TestCouponInterests
    {
        Owner owner;
        Admin admin;
        Business b;
        Coupon.Coupon cop;

        CouponInterests ci;

        [TestInitialize]
        public void TestInit()
        {
        }
        
        [TestMethod]
        public void TestAddCouponInterests()
        {
            using (basicEntities be = new basicEntities())
            {
                owner = TestOwner.AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                admin = TestAdmin.AddAdmin("admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                b = TestBusiness.AddBusinesses("123", admin, owner, "beer-Sheva", "bla", Category.CarsAccessories);
                cop = TestCoupon.CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014", 8);

                be.Users.Add(owner);
                be.Users.Add(admin);
                be.Businesses.Add(b);
                be.Coupons.Add(cop);
                be.SaveChanges();
                

                ci = new CouponInterests();

                ci.CouponId = cop.Id;
                ci.InterestID = InterestType.Dancing;
                

                be.CouponInterests.Add(ci);
                be.SaveChanges();


                Assert.AreEqual(be.CouponInterests.Find(ci.InterestID, ci.CouponId).CouponId, ci.CouponId);
               
            }
        }

        [TestMethod]
        public void TestRemoveCouponInterests()
        {
            using (basicEntities be = new basicEntities())
            {
                owner = TestOwner.AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                admin = TestAdmin.AddAdmin("admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                b = TestBusiness.AddBusinesses("123", admin, owner, "beer-Sheva", "bla", Category.CarsAccessories);
                cop = TestCoupon.CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014", 8);

                be.Users.Add(owner);
                be.Users.Add(admin);
                be.Businesses.Add(b);
                be.Coupons.Add(cop);
                be.SaveChanges();


                ci = new CouponInterests();

                ci.CouponId = cop.Id;
                ci.InterestID = InterestType.Dancing;


                be.CouponInterests.Add(ci);
                be.SaveChanges();

                CouponInterests c = be.CouponInterests.Find(ci.InterestID, ci.CouponId);

                if (c != null)
                {
                    be.CouponInterests.Remove(c);
                    be.Coupons.Remove(be.Coupons.Find(cop.Id));
                    be.Businesses.Remove(be.Businesses.Find(b.BusinessID));
                    be.Users.Remove(be.Users.Find(admin.UserName));
                    be.Users.Remove(be.Users.Find(owner.UserName));
                    be.SaveChanges();
                }

                Assert.IsNull(be.CouponInterests.Find(ci.InterestID, ci.CouponId));          
            }
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (basicEntities be = new basicEntities())
            {
                CouponInterests c = be.CouponInterests.Find(ci.InterestID, ci.CouponId);

                if (c != null)
                {
                    be.CouponInterests.Remove(c);
                    be.Coupons.Remove(be.Coupons.Find(cop.Id));
                    be.Businesses.Remove(be.Businesses.Find(b.BusinessID));
                    be.Users.Remove(be.Users.Find(admin.UserName));
                    be.Users.Remove(be.Users.Find(owner.UserName));
                    be.SaveChanges();
                }
            }
        }
    }
}
