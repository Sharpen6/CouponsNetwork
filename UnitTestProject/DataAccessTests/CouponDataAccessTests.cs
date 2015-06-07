using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline.DataLayer;
using CouponsOnline;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using CouponsOnline.BusinessLayer.Presenters;
using System.Collections;

namespace UnitTestProject.DataAccessTests
{
    [TestClass]
    public class CouponDataAccessTests
    {
        [TestMethod]
        public void CreateCouponTest()
        {
            Business b = TestBusiness.AddBusiness();
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            Assert.AreNotEqual(data.Rows.Count, "0");
            int copID = int.Parse((string)data.Rows[0][8]);
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void GetAllCouponsTest()
        {
            Business b = TestBusiness.AddBusiness();
            
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int initNum = data.Rows.Count;
            int copID = int.Parse((string)data.Rows[0][8]);
            
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int copID2 = int.Parse((string)data.Rows[1][8]);
            int Num2 = data.Rows.Count;
            
            Assert.AreEqual(Num2 - 1, initNum);

            CouponDataAccess.RemoveCoupon(copID.ToString());
            CouponDataAccess.RemoveCoupon(copID2.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void RemoveCouponTest()
        {
            Business b = TestBusiness.AddBusiness();
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int copID = int.Parse((string)data.Rows[0][8]);
            CouponDataAccess.RemoveCoupon(copID.ToString());
            data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            Assert.AreEqual(data.Rows.Count, 0);
            TestBusiness.RemoveBusinesses(b.BusinessID);          
        }
        [TestMethod]
        public void EditCouponTest()
        {
            Business b = TestBusiness.AddBusiness();
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int copID = int.Parse((string)data.Rows[0][8]);

            CouponDataAccess.EditCoupon(copID, "blabla", 43, 2, "asda", "03/04/05", 3, new List<ListItem>());

            Assert.AreEqual(CouponDataAccess.GetCoupon(copID.ToString()).Name,
                "blabla");
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);         
        }
        [TestMethod]
        public void GetCouponTest()
        {
            Business b = TestBusiness.AddBusiness();
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int copID = int.Parse((string)data.Rows[0][8]);

            CouponDataAccess.EditCoupon(copID, "blabla", 43, 2, "asda", "03/04/05", 3, new List<ListItem>());

            Assert.AreEqual(CouponDataAccess.GetCoupon(copID.ToString()).Name,
                "blabla");
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);   
        }
        [TestMethod]
        public void GetCouponsByBusniessTest()
        {
            Business b = TestBusiness.AddBusiness();
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", new System.Collections.Generic.List<string>());
            DataTable data = CouponDataAccess.GetCouponsByBusniess(b.BusinessID);
            int copID = int.Parse((string)data.Rows[0][8]);

            CouponDataAccess.EditCoupon(copID, "blabla", 43, 2, "asda", "03/04/05", 3, new List<ListItem>());

            Assert.AreEqual(CouponDataAccess.GetCoupon(copID.ToString()).Name,
                "blabla");
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);   
        }
        [TestMethod]
        public void GetCouponsByCityAndInterestTest()
        {
            Business b = TestBusiness.AddBusiness();
            Interest i = TestInterest.AddInterest();
            List<string> items = new List<string>();
            items.Add(i.Id.ToString());
            List<ListItem> interests = new List<ListItem>();
            interests.Add(new ListItem(i.Id.ToString()));
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", items);
            DataTable dt = CouponDataAccess.GetCouponsByCityAndInterest(b.City.Id.ToString(),
               interests);
            Assert.AreNotEqual(dt.Rows.Count, 0);
            int copID = int.Parse((string)dt.Rows[0][8]);
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);
            TestInterest.RemoveInterest(i.Id);

        } 
        [TestMethod]
        public void GetCouponsByCityTest()
        {
            Coupon cop = TestCoupon.AddCoupon();
            DataTable dt = CouponDataAccess.GetCouponsByCity(cop.Business.City.Id.ToString());
            Assert.AreNotEqual(dt.Rows.Count, 0);
            TestCoupon.RemoveCoupon(cop.Id);
        }
        [TestMethod]
        public void GetCouponsByInterestTest()
        {
            Business b = TestBusiness.AddBusiness();
            Interest i = TestInterest.AddInterest();
            List<string> items = new List<string>();
            items.Add(i.Id.ToString());
            List<ListItem> interests = new List<ListItem>();
            interests.Add(new ListItem(i.Id.ToString()));
            CouponDataAccess.CreateCoupon("copTest", "copTest", "3", "2", b, "01/01/2014", "4", items);
            DataTable dt = CouponDataAccess.GetCouponsByInterest(interests);
            Assert.AreNotEqual(dt.Rows.Count, 0);
            int copID = int.Parse((string)dt.Rows[0][8]);
            CouponDataAccess.RemoveCoupon(copID.ToString());
            TestBusiness.RemoveBusinesses(b.BusinessID);
            TestInterest.RemoveInterest(i.Id);
        }
    }
}
