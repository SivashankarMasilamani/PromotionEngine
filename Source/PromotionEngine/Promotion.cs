namespace PromotionEngine
{
    /// <summary>
    /// Promotion for buying 'n' units of 'm' skuId 
    /// 3 * A = 130
    /// 2 * B = 40
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

        /// <summary>
        /// Apply the promotion and reduce it from the quantity
        /// </summary>
        /// <param name="orderedItems"></param>
        /// <returns></returns>
        public int Apply(OrderList orderedItems)
        {
            var sku = orderedItems[Id];
            if (sku != null)
            {
                var noOfPromotions = sku.Quantity / Quantity;
                sku.Quantity -= (noOfPromotions * Quantity);
                return noOfPromotions * Price;
            }
            return 0;
        }
    }
}
