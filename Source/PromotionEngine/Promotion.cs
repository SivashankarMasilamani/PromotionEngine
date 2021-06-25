using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    /// <summary>
    /// 3 * A = 130
    /// 2 * B = 40
    /// n units of m skuId 
    /// </summary>
    public class Promotion : IPromotion
    {
        private int Quantity;
        private int Price;
        public char Id { get; private set; }

        public Promotion(char skuId, int quantity, int price)
        {
            Id = skuId;
            Quantity = quantity;
            Price = price;
        }

        public int Apply(SKUs skus)
        {
            var sku = skus[Id];
            if (sku != null)
            {
                var noOfPromotions = sku.Quantity / Quantity;
                sku.Quantity -= (noOfPromotions * Quantity);
                return noOfPromotions * Price;
            }
            return 0;
        }
    }

    /// <summary>
    /// C + D
    /// </summary>
    public class CombinedPromotion : IPromotion
    {
        private int Price;

        public CombinedPromotion(Dictionary<char, int> promotion, int price)
        {
            promotionType = promotion;
            Price = price;
        }

        // 1C + 1D = 100
        private Dictionary<char, int> promotionType;

        private bool IsApplicable(SKUs skus)
        {
            foreach (var key in promotionType.Keys)
            {
                var sku = skus[key];
               
                if (sku == null || sku.Quantity < promotionType[key])
                {
                    return false;
                }
            }
            return true;
        }

        private int NoOfPromotions(SKUs skus)
        {
            int noOfPromotions = 0;

            if (IsApplicable(skus))
            {
                UpdateSkus(skus);
                noOfPromotions++;
            }
            return noOfPromotions;
        }

        private void UpdateSkus(SKUs skus)
        {
            foreach (var key in promotionType.Keys)
            {
                skus[key].Quantity -= promotionType[key];
            }
        }

        public int Apply(SKUs skus)
        {
            int noOfPromotions = NoOfPromotions(skus);
            return noOfPromotions * Price;
        }

    }
}
