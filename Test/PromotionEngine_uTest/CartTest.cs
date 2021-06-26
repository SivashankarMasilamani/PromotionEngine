using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void TestAddSKU()
        {
            Cart myCart = new Cart();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            var skuB = new StoreKeepingUnit('B', 8, 15);

            myCart.AddSKU(skuA);
            myCart.AddSKU(skuB);

            Assert.IsTrue(myCart.orderedItems['A'] != null);
            Assert.IsTrue(myCart.orderedItems['B'] != null);
            Assert.IsTrue(myCart.orderedItems['C'] == null);
        }
    }
}
