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
        Users_Owner owner;
        Users_Admin admin;
        Business b ;
        Coupon cop;
        Users_Customer customer;
        OrderedCoupon oc;

        [TestInitialize]
        public void TestInit()
        {
            
            
        }
        
        [TestMethod]
        public void TestAddOrderedCoupon()
        {
            using (basicEntities be = new basicEntities())
            {
                owner = TestOwner.AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                admin = TestAdmin.AddAdmin("admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                b = TestBusiness.AddBusinesses("123", admin, owner, "beer-Sheva", "bla");
                cop = TestCoupon.CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014",8);
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                
                be.Users.Add(owner);
                be.Users.Add(admin);
                be.Businesses.Add(b);
                be.Coupons.Add(cop);
                be.SaveChanges();

                oc = new OrderedCoupon();
                oc.SerialNum = 4;
                oc.Status = StatusType.NotUsed;
                oc.PurchaseDate = "27/04/1990";
                oc.Coupon = cop;
                oc.UseDate = "";
                oc.Rank = "0";
                oc.Opinion = "";
                oc.Customer = customer;

                be.OrderedCoupons.Add(oc);
                be.SaveChanges();
                

                Assert.AreEqual(be.OrderedCoupons.Find(oc.SerialNum).PurchaseDate, oc.PurchaseDate);
               
            }
        }

        [TestMethod]
        public void TestRemoveOrderedCoupon()
        {
            using (basicEntities be = new basicEntities())
            {
                owner = TestOwner.AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                admin = TestAdmin.AddAdmin("admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                b = TestBusiness.AddBusinesses("123", admin, owner, "beer-Sheva", "bla", Category.CarsAccessories);
                cop = TestCoupon.CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014",8);
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");

                be.Users.Add(owner);
                be.Users.Add(admin);
                be.Businesses.Add(b);
                be.Coupons.Add(cop);
                be.SaveChanges();

                oc = new OrderedCoupon();
                oc.SerialNum = 4;
                oc.Status = StatusType.NotUsed;
                oc.PurchaseDate = "27/04/1990";
                oc.Coupon = cop;
                oc.UseDate = "";
                oc.Rank = "0";
                oc.Opinion = "";
                oc.Customer = customer;

                be.OrderedCoupons.Add(oc);
                be.SaveChanges();

                be.OrderedCoupons.Remove(be.OrderedCoupons.Find(oc.SerialNum));
                be.Coupons.Remove(be.Coupons.Find(cop.Id));
                be.Businesses.Remove(be.Businesses.Find(b.BusinessID));
                be.Users.Remove(be.Users.Find(admin.UserName));
                be.Users.Remove(be.Users.Find(owner.UserName));
                be.Users.Remove(be.Users.Find(customer.UserName));
                be.SaveChanges();

                Assert.IsNull(be.OrderedCoupons.Find(oc.SerialNum));

            }
        }

        [TestMethod]
        public void TestUpdateOrderedCoupon()
        {
            using (basicEntities be = new basicEntities())
            {
                owner = TestOwner.AddOwner("owner123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                admin = TestAdmin.AddAdmin("admin123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                b = TestBusiness.AddBusinesses("123", admin, owner, "beer-Sheva", "bla", Category.CarsAccessories);
                cop = TestCoupon.CreateCoupon(2, "Fly PIZZA", "100", "40", b, "10/10/2014",8);
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");

                be.Users.Add(owner);
                be.Users.Add(admin);
                be.Businesses.Add(b);
                be.Coupons.Add(cop);
                be.SaveChanges();

                oc = new OrderedCoupon();
                oc.SerialNum = 4;
                oc.Status = StatusType.NotUsed;
                oc.PurchaseDate = "27/04/1990";
                oc.Coupon = cop;
                oc.UseDate = "";
                oc.Rank = "0";
                oc.Opinion = "";
                oc.Customer = customer;

                be.OrderedCoupons.Add(oc);
                be.SaveChanges();

                oc.Rank = "5";
                be.SaveChanges();

                Assert.AreEqual(be.OrderedCoupons.Find(oc.SerialNum).Rank, oc.Rank);

            }
        }
        public OrderedCoupon AddOrderedCoupon()
        {
            OrderedCoupon oc = new OrderedCoupon();
            oc.Coupon = TestCoupon.AddCoupon();
            oc.Users_Customer = TestCustomer.AddCustomer();
            using (basicEntities be = new basicEntities())
            {
                oc.Opinion = "not used it yet";
                oc.PurchaseDate = DateTime.Now.ToShortDateString();
                oc.Rank = 0;
                oc.SerialNum = 1;
                oc.UseDate = "";
                oc.
            }
            return oc;
        }

        public void RemoveOrderedCoupon(int id)
        {

        }
        [TestCleanup]
        public void CleanUp()
        {
            using (basicEntities be = new basicEntities())
            {
                if (be.OrderedCoupons.Find(oc.SerialNum) != null)
                {
                    be.OrderedCoupons.Remove(be.OrderedCoupons.Find(oc.SerialNum));
                    be.Coupons.Remove(be.Coupons.Find(cop.Id));
                    be.Businesses.Remove(be.Businesses.Find(b.BusinessID));
                    be.Users.Remove(be.Users.Find(admin.UserName));
                    be.Users.Remove(be.Users.Find(owner.UserName));
                    be.Users.Remove(be.Users.Find(customer.UserName));
                    be.SaveChanges();
                }
            }
        }
    }
}
