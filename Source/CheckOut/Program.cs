using System;
using PromotionEngine;

namespace CheckOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StoreKeepingUnit A = new StoreKeepingUnit('A', 50, 3);
            StoreKeepingUnit B = new StoreKeepingUnit('B', 30, 5);
            StoreKeepingUnit C = new StoreKeepingUnit('C', 20);
            StoreKeepingUnit D = new StoreKeepingUnit('D', 15);
            StoreKeepingUnit E = new StoreKeepingUnit('E', 10,3);
            StoreKeepingUnit F = new StoreKeepingUnit('F', 10,2);

            Cart order = new Cart();
            order.AddSKU(A);
            order.AddSKU(B);
            order.AddSKU(C);
            order.AddSKU(D);
            order.AddSKU(E);
            order.AddSKU(F);

            Console.WriteLine(order.TotalPriceAfterPromotion(new PromotionEngine.PromotionEngine()));
        }
    }
}
