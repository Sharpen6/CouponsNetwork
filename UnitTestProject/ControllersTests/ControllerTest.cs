using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.BusinessLayer.Controllers;
using System.Web.UI.WebControls;

namespace UnitTestProject.ControllersTests
{
    [TestClass]
    public class ControllerTest
    {
        [TestMethod]
        public void TestCreateCity()
        {
            Controller.CreateCity("dimona");
            ListItem[] cities = Controller.GetAllCites();
            bool flag = false;
            int cityID = 0;
            foreach (var item in cities)
            {
                if (item.Text == "dimona")  {
                    flag = true;
                    cityID = int.Parse(item.Value);
                }
            }
            Assert.IsTrue(flag);
            using (basicEntities be = new basicEntities())
            {
                be.Cities.Remove(be.Cities.Find(cityID));
            }
        }
    }
}
