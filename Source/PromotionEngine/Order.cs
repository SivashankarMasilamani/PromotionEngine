using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class Order
    {
        SKUs skus;

        public Order()
        {
            skus = new SKUs();
        }

        public void AddSKU(SKU sku)
        {
            skus.Add(sku);
        }

        public int TotalPrice()
        {
            return skus.TotalPrice();
        }

        public int TotalPriceAfterPromotion(PromotionEngine promotionEngine) {
            return promotionEngine.Apply(this.skus);
        }
    }
}

