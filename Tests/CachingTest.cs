using Business.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class CachingTest
    {
        [TestMethod]
        public void GetCategoriesFromCache()
        {
            var cb = new CommonBusiness();

            cb.GetCategories(4); //from app

            cb.GetCategories(5); //from app

            Assert.IsTrue(cb.GetCategories(4).Any()); //from cache

            Assert.IsTrue(cb.GetCategories(5).Any()); //from cache
        }
    }
}
