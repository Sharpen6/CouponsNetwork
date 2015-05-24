﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{

    [TestClass]
    public class TestRecommendation
    {
        Recommendation rec;
        Users_Customer customer;
        
        [TestMethod]
        public void TestAddRecommendation()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");
                
                rec = new Recommendation();
                rec.Description = "blabla";
                rec.Id = 4;
                rec.Link = "www.google.com";
                rec.Source = 1;
                rec.Users_Customer = customer;
                be.Recommendations.Add(rec);
                be.SaveChanges();

                Assert.AreEqual(be.Recommendations.Find(rec.Id).Link, rec.Link);
            }
        }
        [TestMethod]
        public void TestRemoveRecommendation()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");

                rec = new Recommendation();
                rec.Description = "blabla";
                rec.Id = 4;
                rec.Link = "www.google.com";
                rec.Source = SourceType.GooglePlus;

                rec.Customer = customer;
                be.Users.Add(customer);
                be.Recommendations.Add(rec);
                be.SaveChanges();


                be.Recommendations.Remove(rec);
                be.Users.Remove(be.Users.Find(customer.UserName));
                be.SaveChanges();

                Assert.IsNull(be.Recommendations.Find(rec.Id));
            }
        }
        [TestMethod]
        public void TestUpdateRecommendation()
        {
            using (basicEntities be = new basicEntities())
            {
                customer = TestCustomer.AddCustomer("Customer123", "adam", "admin123123", 054, 3134195, "adamin@gmail.com");

                rec = new Recommendation();
                rec.Description = "blabla";
                rec.Id = 4;
                rec.Link = "www.google.com";
                rec.Source = SourceType.GooglePlus;

                rec.Customer = customer;
                be.Users.Add(customer);
                be.Recommendations.Add(rec);
                be.SaveChanges();


                rec.Link = "www.twitter.com";
                be.SaveChanges();

                Assert.AreEqual(be.Recommendations.Find(rec.Id).Link, rec.Link);
            }
        }
        [TestCleanup]
        public void Cleanup()
        {
            using (basicEntities be = new basicEntities())
            {
                Recommendation r = be.Recommendations.Find(rec.Id);
                if (r != null)
                {
                    be.Recommendations.Remove(be.Recommendations.Find(r.Id));
                    //TestCustomer.RemoveCustomer("Customer123");
                    be.Users.Remove(be.Users.Find(customer.UserName));
                    be.SaveChanges();
                }
            }
        }
    }
}
