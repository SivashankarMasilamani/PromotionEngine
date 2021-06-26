using System.Collections.Generic;

namespace PromotionEngine
{
    public class OrderList
    {
        internal Dictionary<char, StoreKeepingUnit> SkuDictionary = new Dictionary<char, StoreKeepingUnit>();

        /// <summary>
        /// Indexer to return a particular storekeepingunit of the provided id
        /// </summary>
        /// <param name="id">SKU Id</param>
        /// <returns>SKU</returns>
        public StoreKeepingUnit this[char id]
        {
            get {
                return SkuDictionary.ContainsKey(id) ? SkuDictionary[id] : null;
            }
        }

        /// <summary>
        /// Adds the item to the order list
        /// </summary>
        /// <param name="sku"></param>
        public void Add(StoreKeepingUnit sku)
        {
            // If exists, increase the quantity
            if (SkuDictionary.ContainsKey(sku.Id))
            {
                if (SkuDictionary[sku.Id].UnitPrice != sku.UnitPrice)
                {
                    throw new System.Exception("Cannot modify the unit price");
                }

                SkuDictionary[sku.Id].Quantity += sku.Quantity;
            }
            else
            {
                // else, add the new entry
                SkuDictionary.Add(sku.Id, sku);
            }
        }

        /// <summary>
        /// Calculates the total price of the items exist in the order list
        /// </summary>
        /// <returns>Total amount</returns>
        public int TotalPrice()
        {
            int price = 0;
           
            foreach (var skuId in SkuDictionary.Keys)
            {
                price += SkuDictionary[skuId].TotalPrice();
            }

            return price;
        }
    }
}
