using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.BusinessLayer.Presenters;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace UnitTestProject
{
    
    [TestClass]
    public class TestBusiness
    {

        [TestMethod]
        public void TestAddBusiness()
        {
            int Businessid=0;
            using (basicEntities be = new basicEntities())
            {
                Businessid = AddBusiness().BusinessID;
                Assert.AreEqual(be.Businesses.Find(Businessid).BusinessID, Businessid);
            }
            RemoveBusinesses(Businessid);
        }

        
        [TestMethod]
        public void TestUpdateBusiness()
        {
            int Businessid = AddBusiness().BusinessID;
            using (basicEntities be = new basicEntities())
            {

                be.Businesses.Find(Businessid).Address = "tel ron";
                be.SaveChanges();

                Assert.AreEqual(be.Businesses.Find(Businessid).Address, "tel ron");
            }
            RemoveBusinesses(Businessid);
        }

        [TestMethod]
        public void TestRemoveBusiness()
        {
            int Businessid = AddBusiness().BusinessID;
            RemoveBusinesses(Businessid);
            using (basicEntities be = new basicEntities())
            {               
                Assert.IsNull(be.Businesses.Find(Businessid));
            }
        }

        [TestMethod]
        public void TestDeactivate()
        {
            Business b = AddBusiness();
            b.Deactivate();
            Assert.IsNull(BusinessController.GetBusiness(b.BusinessID.ToString()));
            RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void TestCreateCoupon()
        {
            Random r = new Random();
            Business b = AddBusiness();
            Interest interest = TestInterest.AddInterest();
            List<string> inte = new List<string>() { interest.Id.ToString() };
            List<ListItem> inteLi = new List<ListItem>();
            inteLi.Add(new ListItem(interest.Description, interest.Id.ToString()));

            for (int i = 0; i < 10; i++)
			{
                int p = r.Next(50);
                int d = p - r.Next(30);
                
			    b.CreateCoupon("coupon"+i,p.ToString(),d.ToString(),"testCop","21/12/89",r.Next(10).ToString(),inte);
			}
            DataTable dt = CouponController.FindCoupons(b.City.Id.ToString(), inteLi, 0, 0);
            foreach (DataRow item in dt.Rows)
            {
                
                TestCoupon.RemoveOnlyCoupon(int.Parse(item[8].ToString()));
            }
            RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void TestChangeDetail()
        {
            Business b = AddBusiness();
            BusinessCategories bc = TestCategory.AddCategory();
            City c = TestCity.AddCity();
            TestCategory.RemoveCategory(bc.Id);
            TestCity.RemoveCity(c.Id);
            b.ChangeDetails("bla", "blag", bc.Id.ToString(), c.Id.ToString());
            b = BusinessController.GetBusiness(b.BusinessID.ToString());
            Assert.AreEqual(b.Address,"bla");
            RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void TestGetCoupons()
        {
            Random r = new Random();
            Business b = AddBusiness();
            Interest interest = TestInterest.AddInterest();
            List<string> inte = new List<string>() { interest.Id.ToString() };
            List<ListItem> inteLi = new List<ListItem>();
            inteLi.Add(new ListItem(interest.Description, interest.Id.ToString()));

            for (int i = 0; i < 10; i++)
            {
                int p = r.Next(50);
                int d = p - r.Next(30);

                b.CreateCoupon("coupon" + i, p.ToString(), d.ToString(), "testCop", "21/12/89", r.Next(10).ToString(), inte);
            }
            DataTable dt = b.GetCoupons();
            foreach (DataRow item in dt.Rows)
            {
                TestCoupon.RemoveOnlyCoupon(int.Parse(item[8].ToString()));
            }
            RemoveBusinesses(b.BusinessID);
        }

        public static Business AddBusiness(String address = "kalisher 5", string name = "addbusinesstest")
        {
            City city = TestCity.AddCity();
            Users_Owner owner = TestOwner.AddOwner();
            Users_Admin admin = TestAdmin.AddAdmin();
            BusinessCategories bc = TestCategory.AddCategory();
            Business b = new Business();
            using (basicEntities be = new basicEntities())
            {
                b.Users_Admin = admin;
                b.Users_Owner = owner;
                b.Address = address;
                b.Name = name;               
                be.Entry(admin).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(owner).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(bc).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(city).State = System.Data.Entity.EntityState.Unchanged;
                b.BusinessCategory = bc;
                b.City = city;
                be.Businesses.Add(b);
                be.SaveChanges();
                return b;
            }                      
        }

        public static void RemoveBusinesses(int BusinessID)
        {
            int catID = 0;
            int cityID = 0;
            string admin;
            string owner;
            using (basicEntities be = new basicEntities())
            {
                Business BusinessesToRemove = be.Businesses.Find(BusinessID);
                catID = BusinessesToRemove.BusinessCategory.Id;
                cityID = BusinessesToRemove.City.Id;
                admin = BusinessesToRemove.Users_Admin.UserName;
                owner = BusinessesToRemove.Users_Owner.UserName;

                be.Entry(be.Cities.Find(cityID)).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(be.BusinessCategories.Find(catID)).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(be.Users_Admin.Find(admin)).State = System.Data.Entity.EntityState.Unchanged;
                be.Entry(be.Users_Owner.Find(owner)).State = System.Data.Entity.EntityState.Unchanged;
                
                be.Businesses.Remove(BusinessesToRemove);
                be.SaveChanges();
            }
            TestCategory.RemoveCategory(catID);
            TestCity.RemoveCity(cityID);
            TestAdmin.RemoveAdmin(admin);
            TestOwner.RemoveOwner(owner);
        }
    }
}
