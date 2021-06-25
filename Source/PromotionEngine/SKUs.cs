using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PromotionEngine
{

    public class SKUs
    {
        Dictionary<char, SKU> SkuDictionary = new Dictionary<char, SKU>();

        public SKU this[char id]
        {
            get {
                return SkuDictionary.ContainsKey(id) ? SkuDictionary[id] : null;
            }
        }

        public void Add(SKU sku)
        {

            if (SkuDictionary.ContainsKey(sku.Id))
            {
                SkuDictionary[sku.Id].Quantity += sku.Quantity;
            }
            else
            {
                SkuDictionary.Add(sku.Id, sku);
            }
        }

        public int TotalPrice()
        {
            int price = 0;
            foreach (var skuId in SkuDictionary.Keys)
            {
                price += SkuDictionary[skuId].TotalPrice();
            }
            return price;
        }

        public List<char> Ids() {
            return SkuDictionary.Keys.ToList();
        }
    }
}
