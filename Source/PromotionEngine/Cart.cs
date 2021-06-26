namespace PromotionEngine
{
    public class Cart
    {
        /// <summary>
        /// Items in the cart
        /// </summary>
        OrderList orderedItems;

        /// <summary>
        /// Constructor
        /// </summary>
        public Cart()
        {
            orderedItems = new OrderList();
        }

        /// <summary>
        /// Add item to the cart
        /// </summary>
        /// <param name="item">Item</param>
        public void AddSKU(StoreKeepingUnit item)
        {
            orderedItems.Add(item);
        }

        /// <summary>
        /// Total price after applying the promotion 
        /// </summary>
        /// <param name="promotionEngine">Promotion engine</param>
        /// <returns>Check out price</returns>
        public int TotalPriceAfterPromotion(PromotionEngine promotionEngine) {
            return promotionEngine.Apply(this.orderedItems);
        }
    }
}

