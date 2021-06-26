using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class StoreKeepingUnitTests
    {
        [TestMethod]
        public void TestTotalPrice( )
        {
            var skuA = new StoreKeepingUnit('A', 10, 10);
            var skuB = new StoreKeepingUnit('B', 8, 15);

            Assert.AreEqual(skuA.TotalPrice(), 100);
            Assert.AreEqual(skuB.TotalPrice(), 120);
        }

        [TestMethod]
        public void TestTotalPrice_Negative()
        {
            var skuA = new StoreKeepingUnit('A', -10, 10);
            var skuB = new StoreKeepingUnit('B', 10, -5);

            Assert.AreEqual(skuA.TotalPrice(), 0);
            Assert.AreEqual(skuB.TotalPrice(), 0);
        }
    }
}
