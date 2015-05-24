using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using System.Linq;

namespace UnitTestProject
{
    //[TestClass]
    public class TestDeleteAllTables
    {

        [TestMethod]
        public void TesDeleteAll()
        {
            DeleteAllCoupons();
            DeleteAllBusiness();
            DeleteAllAdmin();
            DeleteAllOwners();
            DeleteAllUser();


        }
        public static void DeleteAllAdmin()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Users
                            select b;

                foreach (Coupon.User item in query)
                    if (item is Coupon.Admin)
                        TestAdmin.RemoveAdmin(item.UserName);

            }
        }

        public static void DeleteAllUser()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Users
                            select b;

                foreach (Coupon.User item in query)
                    TestUser.RemoveUser(item.UserName);

            }
        }

        public static void DeleteAllBusiness()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Businesses
                            select b;

                foreach (Coupon.Business item in query)
                    TestBusiness.RemoveBusinesses(item.BusinessID);

            }
        }

        public static void DeleteAllCoupons()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Coupons
                            select b;

                foreach (Coupon.Coupon item in query)
                {
                    TestCoupon.RemoveCoupon(item.Id);
                }
            }
        }

        public static void DeleteAllOwners()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Users
                            select b;

                foreach (Coupon.User item in query)
                    if (item is Coupon.Owner)
                        TestOwner.RemoveOwner(item.UserName);

            }
        }

        public static void DeleteAllustomers()
        {
            using (basicEntities be = new basicEntities())
            {
                var query = from b in be.Users
                            select b;

                foreach (Coupon.User item in query)
                    if (item is Coupon.Customer)
                        TestCustomer.RemoveCustomer(item.UserName);

            }
        }
    }
}

