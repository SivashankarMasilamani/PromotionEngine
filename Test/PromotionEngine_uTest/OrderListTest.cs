using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class OrderListTest
    {
        [TestMethod]
        public void TestAdd_ForNewEntries()
        {
            OrderList orderList = new OrderList();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            var skuB = new StoreKeepingUnit('B', 8, 15);
            orderList.Add(skuA);
            orderList.Add(skuB);

            Assert.IsTrue(orderList.SkuDictionary.ContainsKey('A'));
            Assert.IsTrue(orderList.SkuDictionary.ContainsKey('B'));
        }

        [TestMethod]
        public void TestAdd_ForExistingEntries()
        {
            OrderList orderList = new OrderList();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            orderList.Add(skuA);
            Assert.IsTrue(orderList['A'].Quantity == 10);

            var moreSkuA = new StoreKeepingUnit('A', 10, 5);
            orderList.Add(moreSkuA);
            Assert.IsTrue(orderList['A'].Quantity == 15);
        }

        [TestMethod]
        [ExpectedException(typeof(System.Exception))]
        public void TestAdd_WithUnitPriceModified()
        {
            OrderList orderList = new OrderList();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            orderList.Add(skuA);
            Assert.IsTrue(orderList['A'].Quantity == 10);

            var moreSkuA = new StoreKeepingUnit('A', 20, 5);
            orderList.Add(moreSkuA);
        }

        [TestMethod]
        public void TestTotalPrice()
        {
            OrderList orderList = new OrderList();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            var skuB = new StoreKeepingUnit('B', 8, 15);
            orderList.Add(skuA);
            orderList.Add(skuB);

            Assert.AreEqual(orderList.TotalPrice(), 220);
        }
    }
}
