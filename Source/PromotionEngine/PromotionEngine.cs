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
        /// Fetch it from db
        /// Db will be updated promotion team from some tool 
        /// </summary>
        private void LoadPromotions()
        {
            Dictionary<char, int> promotionType = new Dictionary<char, int>();
            promotionType.Add('A', 3);
            var Apromotion = new Promotion('A', 3, 130);
            var Bpromotion = new Promotion('B', 2, 45);

            var CDpromotionType = new Dictionary<char, int> { { 'C', 1 }, { 'D', 1 } };
            var CDcombinedPromotion = new CombinedPromotion(CDpromotionType, 30);

            var EFpromotionType = new Dictionary<char, int> { { 'E', 3 }, { 'F', 2 } };
            var EFcombinedPromotion = new CombinedPromotion(EFpromotionType, 30);

            ActivePromotions.Add(Apromotion);
            ActivePromotions.Add(Bpromotion);
            ActivePromotions.Add(CDcombinedPromotion);
            ActivePromotions.Add(EFcombinedPromotion);
        }

        public int Apply(SKUs skus)
        {
            int promotionPrice = applyPromotions(skus);
            return promotionPrice + skus.TotalPrice();
        }

        private int applyPromotions(SKUs skus)
        {
            int totalPrice = 0;
            foreach (var promotion in ActivePromotions)
            {
                totalPrice += promotion.Apply(skus);
            }
            return totalPrice;
        }
    }
}
