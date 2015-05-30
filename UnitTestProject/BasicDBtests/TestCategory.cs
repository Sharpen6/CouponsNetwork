using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CouponsOnline;

namespace UnitTestProject
{
    [TestClass]
    public class TestCategory
    {
        [TestMethod]
        public void TestAddCategory()
        {
            BusinessCategories catID = AddCategory();
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories bc = be.BusinessCategories.Find(catID.Id);
                Assert.IsNotNull(bc);               
            }
            RemoveCategory(catID.Id);
        }
        [TestMethod]
        public void TestRemoveCategory()
        {
            BusinessCategories catID = AddCategory();
            RemoveCategory(catID.Id);
            using (basicEntities be = new basicEntities())
            {
                Assert.IsNull(be.BusinessCategories.Find(catID.Id));
            }
        }
        [TestMethod]
        public void TestUpdateCategory()
        {
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories catID = AddCategory();
                be.BusinessCategories.Find(catID.Id).Description = "Bob";
                be.SaveChanges();
              

                Assert.AreEqual(be.BusinessCategories.Find(catID.Id).Description,"Bob");
                RemoveCategory(catID.Id);
            }
        }
        public static void RemoveCategory(int id)
        {
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories bc = be.BusinessCategories.Find(id);
                be.BusinessCategories.Remove(bc);
                be.SaveChanges();
            }
        }
        public static BusinessCategories AddCategory()
        {
            using (basicEntities be = new basicEntities())
            {
                BusinessCategories bc = new BusinessCategories();
                bc.Description = "Cars";
                be.BusinessCategories.Add(bc);
                be.SaveChanges();
                return bc;
            }

        }
    }
}
