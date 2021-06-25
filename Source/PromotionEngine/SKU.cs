using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class SKU
    {
        public SKU(char id, int unitPrice, int quantity = 1)
        {
            Id = id;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public char Id { get; }

        public int UnitPrice { get; }

        public int Quantity { get; set; }

        public int TotalPrice()
        {
            return Quantity * UnitPrice;
        }
    }


}
