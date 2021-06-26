namespace PromotionEngine
{
    public class StoreKeepingUnit
    {
        /// <summary>
        /// SKU Id
        /// </summary>
        public char Id { get; }

        /// <summary>
        /// Price per sku unit
        /// </summary>
        public int UnitPrice { get; }

        /// <summary>
        /// Quantity of sku
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public StoreKeepingUnit(char id, int unitPrice, int quantity = 1)
        {
            Id = id;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        /// <summary>
        /// Calculates the total price (without any promotions applied)
        /// </summary>
        /// <returns>Total price</returns>
        public int TotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }
}
