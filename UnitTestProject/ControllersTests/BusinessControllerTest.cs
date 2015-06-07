using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.BusinessLayer.Presenters;

namespace UnitTestProject.ControllersTests
{
    [TestClass]
    public class BusinessControllerTest
    {
        [TestMethod]
        public void CreateBusinessTest()
        {
            Business b = TestBusiness.AddBusiness();
            BusinessController.CreateBusiness(b.Users_Admin.UserName, b.Users_Owner.UserName,
                "address", "name", b.BusinessCategory.Id.ToString(), b.City.Id.ToString());
            int busID = 0;
            bool flag = false;
            using (basicEntities be = new basicEntities())
            {

                foreach (var item in be.Businesses)
                {
                    if (item.Users_Owner.UserName == b.Users_Owner.UserName && item.Address == "address")
                    {
                        busID = item.BusinessID;
                        flag = true;

                    }
                }
                be.Businesses.Remove(be.Businesses.Find(busID));
            }
            Assert.IsTrue(flag);
            TestBusiness.RemoveBusinesses(b.BusinessID);
        }
    }
}
