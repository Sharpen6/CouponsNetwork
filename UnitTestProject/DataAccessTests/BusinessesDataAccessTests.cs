using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using System.Linq;
using CouponsOnline.DataLayer;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace UnitTestProject.DataAccessTests
{
    [TestClass]
    public class BusinessesDataAccessTests
    {
        [TestMethod]
        public void CreateBusinessTest() 
        {
            Business b = TestBusiness.AddBusiness();
            using (basicEntities be = new basicEntities())
            {
                int countBusinesses = (from bu in be.Businesses
                             select bu).Count();

                BusinessDataAccess.CreateBusiness(b.Users_Admin.UserName,
                    b.Users_Owner.UserName, "", "", b.BusinessCategory.Id.ToString(),
                    b.City.Id.ToString());

                int countBusinesses2 = (from bu in be.Businesses
                                       select bu).Count();

                Assert.AreEqual(countBusinesses2 - 1, countBusinesses);
            }
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }

        [TestMethod]
        public void GetBusinessTest()
        {
            Business b = TestBusiness.AddBusiness();
            Assert.IsNotNull(BusinessDataAccess.GetBusiness(b.BusinessID));
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void DisableBusinessTest()
        {
            Business b = TestBusiness.AddBusiness();
            BusinessDataAccess.DisableBusiness(b.BusinessID);
            Assert.IsNull(BusinessDataAccess.GetBusiness(b.BusinessID));
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void GetCategoriesTest()
        {
            int startCount = BusinessDataAccess.GetCategories().Count();
            BusinessCategories c = TestCategory.AddCategory();
            int endCount = BusinessDataAccess.GetCategories().Count();
            Assert.AreEqual(endCount - 1, startCount);
            TestCategory.RemoveCategory(c.Id);
        }
        [TestMethod]
        public void GetAllBusinssesOfOwnerTest()
        {
            Business b = TestBusiness.AddBusiness();
            List<Business> b2 = BusinessDataAccess.GetAllBusinssesOfOwner(b.Users_Owner.UserName);
            Assert.AreEqual(b.BusinessID, b2.First().BusinessID);
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void GetAllIntrestOfCategoryTest()
        {
            Interest interest = TestInterest.AddInterest();
            ListItem[] interests = BusinessDataAccess.GetAllIntrestOfCategory(interest.BusinessCategory.Id.ToString());
            Assert.AreEqual(interest.Id.ToString(), interests.First().Value);
            TestInterest.RemoveInterest(interest.Id);
        }
        [TestMethod]
        public void EditBusinessTest()
        {
            Business b = TestBusiness.AddBusiness();
            BusinessDataAccess.EditBusiness(b.BusinessID, "mor", "mor", b.BusinessCategory.Id.ToString(), b.City.Id.ToString());
            Assert.AreEqual("mor", BusinessDataAccess.GetBusiness(b.BusinessID).Address);
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
        [TestMethod]
        public void GetlAllInterestsTest()
        {
            int startCount = BusinessDataAccess.GetlAllInterests().Count();
            Interest i = TestInterest.AddInterest();
            int endCount = BusinessDataAccess.GetlAllInterests().Count();
            Assert.AreEqual(endCount - 1, startCount);
            TestInterest.RemoveInterest(i.Id);         
        }
    }
}
