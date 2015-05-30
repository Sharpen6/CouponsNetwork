using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;
using CouponsOnline.BusinessLayer.Controllers;
using System.Collections.Generic;

namespace UnitTestProject.ControllersTests
{
    [TestClass]
    public class UserControllerTest
    {
        [TestMethod]
        public void ValidateRegisterationTest()
        {
            List<string> test = UserController.ValidateRegisteration("mash123mash", 
                "123", "1234", "054-31313", "saban,gmail.com", "boom");
            int errors = 0;
            foreach (var item in test)
            {
                if (item.Contains("Password"))
                {
                    errors+=100;
                    break;
                }
            }
            foreach (var item in test)
            {
                if (item.Contains("phone"))
                {
                    errors+=10;
                    break;
                }
            }
            foreach (var item in test)
            {
                if (item.Contains("Email"))
                {
                    errors++;
                    break;
                }
            }
            Assert.AreEqual(111,errors);
        }


    }
}
