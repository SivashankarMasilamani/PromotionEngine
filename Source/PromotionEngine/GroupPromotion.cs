using System.Collections.Generic;

namespace PromotionEngine
{
    /// <summary>
    /// Promotion for buying in pairs / groups
    /// 1 C + 1 D
    /// 2 E + 3 F
    /// 1 G + 2 H + 3 I
    /// </summary>
    public class GroupPromotion : IPromotion
    {
        private int Price;

        public GroupPromotion(Dictionary<char, int> promotion, int price)
        {
            promotionType = promotion;
            Price = price;
        }

        // 1C + 1D = 100
        private Dictionary<char, int> promotionType;

        /// <summary>
        /// check if this promotion is applicable for the given list
        /// </summary>
        /// <param name="orderedItems">list of skus ordered</param>
        private bool IsApplicable(OrderList orderedItems)
        {
            foreach (var key in promotionType.Keys)
            {
                var sku = orderedItems[key];

                if (sku == null || sku.Quantity < promotionType[key])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Get the number of sets applicable for promotion
        /// </summary>
        /// <param name="orderedItems">list of skus ordered</param>
        private int NoOfPromotions(OrderList orderedItems)
        {
            int noOfPromotions = 0;

            while (IsApplicable(orderedItems))
            {
                UpdateOrderList(orderedItems);
                noOfPromotions++;
            }
            return noOfPromotions;
        }

        /// <summary>
        /// Update order list
        /// </summary>
        /// <param name="orderedItems">list of skus ordered</param>
        private void UpdateOrderList(OrderList orderedItems)
        {
            foreach (var key in promotionType.Keys)
            {
                orderedItems[key].Quantity -= promotionType[key];
            }
        }

        /// <summary>
        /// Apply the group promotion
        /// </summary>
        /// <param name="orderedItems">list of skus ordered</param>
        public int Apply(OrderList orderedItems)
        {
            int noOfPromotions = NoOfPromotions(orderedItems);
            return noOfPromotions * Price;
        }
    }
}
