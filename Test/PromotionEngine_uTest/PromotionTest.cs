using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class PromotionTest
    {
        [TestMethod]
        public void TestApply()
        {
            StoreKeepingUnit A = new StoreKeepingUnit('A', 50, 3);
            var orderList = new OrderList();
            orderList.Add(A);

            var promotion = new Promotion('A', 3, 100);

            var total = promotion.Apply(orderList);

            Assert.IsTrue(total == 100);
            Assert.IsTrue(orderList['A'].Quantity == 0);
        }

        [TestMethod]
        public void TestApply_WithNonApplicableUnits()
        {
            StoreKeepingUnit B = new StoreKeepingUnit('B', 30, 5);
            var orderList = new OrderList();
            orderList.Add(B);

            var promotion = new Promotion('B', 2, 45);

            var total = promotion.Apply(orderList);

            Assert.IsTrue(total == 90);
            Assert.IsTrue(orderList['B'].Quantity == 1);
        }
    }
}
