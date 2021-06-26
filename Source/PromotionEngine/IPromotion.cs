namespace PromotionEngine
{
    public interface IPromotion
    {
        /// <summary>
        /// Apply the promotion to the given order list.
        /// </summary>
        int Apply(OrderList Order);
    }
}
