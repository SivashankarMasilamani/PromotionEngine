using System;
using System.Collections.Generic;
namespace PromotionEngine
{
    public class PromotionEngine
    {
        private readonly List<IPromotion> ActivePromotions = new List<IPromotion>();

        public PromotionEngine()
        {
            this.LoadPromotions();
        }

        /// <summary>
        /// Load the promotions, best way to have it from db. 
        /// </summary>
        private void LoadPromotions()
        {
            Dictionary<char, int> promotionType = new Dictionary<char, int>();
            promotionType.Add('A', 3);
            var Apromotion = new Promotion('A', 3, 130);
            var Bpromotion = new Promotion('B', 2, 45);

            var CDpromotionType = new Dictionary<char, int> { { 'C', 1 }, { 'D', 1 } };
            var CDcombinedPromotion = new GroupPromotion(CDpromotionType, 30);

            var EFpromotionType = new Dictionary<char, int> { { 'E', 3 }, { 'F', 2 } };
            var EFcombinedPromotion = new GroupPromotion(EFpromotionType, 30);

            ActivePromotions.Add(Apromotion);
            ActivePromotions.Add(Bpromotion);
            ActivePromotions.Add(CDcombinedPromotion);
            ActivePromotions.Add(EFcombinedPromotion);
        }

        /// <summary>
        /// Apply all the promotions for the given order list
        /// </summary>
        /// <param name="orderedItems">Order list</param>
        /// <returns>Total price after promotion discount</returns>
        public int Apply(OrderList orderedItems)
        {
            // gives the total only for the units for which promotion is applied
            int partialTotal = applyPromotions(orderedItems);

            // add the total for rest of the units with actual price which dont come under promotion 
            return partialTotal + orderedItems.TotalPrice();
        }

        /// <summary>
        /// Apply all the active promotions only for the qualified items
        /// </summary>
        /// <param name="orderedItems"></param>
        /// <returns>partial total which is applied only for the qualified items</returns>
        private int applyPromotions(OrderList orderedItems)
        {
            int totalPrice = 0;
            
            foreach (var promotion in ActivePromotions)
            {
                totalPrice += promotion.Apply(orderedItems);
            }

            return totalPrice;
        }
    }
}
