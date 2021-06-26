using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using Moq;
using System.Collections.Generic;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class PromotionEngineTest
    {
        [TestMethod]
        public void TestApply()
        {
            var firstPromotionMock = new Mock<IPromotion>();
            var secondPromtionMock = new Mock<IPromotion>();
            List<IPromotion> promotions = new List<IPromotion> { firstPromotionMock.Object, secondPromtionMock.Object };
            PromotionEngine.PromotionEngine pEngine = new PromotionEngine.PromotionEngine(promotions);
            var orderList = new OrderList();
            var skuA = new StoreKeepingUnit('A', 10, 10);
            var skuB = new StoreKeepingUnit('B', 8, 15);
            orderList.Add(skuA);
            orderList.Add(skuB);

            pEngine.Apply(orderList);

            firstPromotionMock.Verify(x => x.Apply(It.IsAny<OrderList>()), Times.Once);
            secondPromtionMock.Verify(x => x.Apply(It.IsAny<OrderList>()), Times.Once);
        }

        [TestMethod]
        [DataRow(1, 1, 1, 0, 100)]
        [DataRow(5, 5, 1, 0, 370)]
        [DataRow(3, 5, 1, 1, 280)]
        public void TestApply_withRealData(int skuAQuantity, int skuBQuantity, int skuCQuantity, int skuDQuantity, int expectedTotal )
        {
            StoreKeepingUnit A = new StoreKeepingUnit('A', 50, skuAQuantity);
            StoreKeepingUnit B = new StoreKeepingUnit('B', 30, skuBQuantity);
            StoreKeepingUnit C = new StoreKeepingUnit('C', 20, skuCQuantity);
            StoreKeepingUnit D = new StoreKeepingUnit('D', 15, skuDQuantity);

            var orderList = new OrderList();
            orderList.Add(A);
            orderList.Add(B);
            orderList.Add(C);
            orderList.Add(D);

            PromotionEngine.PromotionEngine pEngine = new PromotionEngine.PromotionEngine();
            var actualTotal = pEngine.Apply(orderList);

            Assert.AreEqual(expectedTotal, actualTotal);
        }
    }
}
