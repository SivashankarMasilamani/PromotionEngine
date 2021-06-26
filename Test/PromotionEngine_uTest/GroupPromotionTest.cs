using Microsoft.VisualStudio.TestTools.UnitTesting;
using PromotionEngine;
using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine_uTest
{
    [TestClass]
    public class GroupPromotionTest
    {
        [TestMethod]
        public void TestApply()
        {
            StoreKeepingUnit C = new StoreKeepingUnit('C', 20);
            StoreKeepingUnit D = new StoreKeepingUnit('D', 15);
            var orderList = new OrderList();
            orderList.Add(C);
            orderList.Add(D);

            var CDpromotionType = new Dictionary<char, int> { { 'C', 1 }, { 'D', 1 } };
            var CDcombinedPromotion = new GroupPromotion(CDpromotionType, 30);

            var total = CDcombinedPromotion.Apply(orderList);

            Assert.IsTrue(total == 30);
            Assert.IsTrue(orderList['C'].Quantity == 0);
            Assert.IsTrue(orderList['D'].Quantity == 0);
        }

        [TestMethod]
        public void TestApply_WithExcessUnits_AndApplicableForOnlyOnePromotion()
        {
            // Added more C's
            StoreKeepingUnit C = new StoreKeepingUnit('C', 20, 10);
            
            // But only one D
            StoreKeepingUnit D = new StoreKeepingUnit('D', 15);
            
            var orderList = new OrderList();
            orderList.Add(C);
            orderList.Add(D);

            var CDpromotionType = new Dictionary<char, int> { { 'C', 1 }, { 'D', 1 } };
            var CDcombinedPromotion = new GroupPromotion(CDpromotionType, 30);

            var total = CDcombinedPromotion.Apply(orderList);

            Assert.IsTrue(total == 30);
            Assert.IsTrue(orderList['C'].Quantity == 9);
            Assert.IsTrue(orderList['D'].Quantity == 0);
        }

        [TestMethod]
        public void TestApply_WithExcessUnits_AndApplicableForMultipleNoOfPromotions()
        {
            // Added 10 C's
            StoreKeepingUnit C = new StoreKeepingUnit('C', 20, 10);

            // But 5 D's
            StoreKeepingUnit D = new StoreKeepingUnit('D', 15, 5);

            var orderList = new OrderList();
            orderList.Add(C);
            orderList.Add(D);

            var CDpromotionType = new Dictionary<char, int> { { 'C', 1 }, { 'D', 1 } };
            var CDcombinedPromotion = new GroupPromotion(CDpromotionType, 30);

            // Applicable for 5 Promotions
            var total = CDcombinedPromotion.Apply(orderList);

            Assert.IsTrue(total == 150);
            Assert.IsTrue(orderList['C'].Quantity == 5);
            Assert.IsTrue(orderList['D'].Quantity == 0);
        }
    }
}
