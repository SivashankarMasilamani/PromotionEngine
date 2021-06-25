using System;
using PromotionEngine;

namespace CheckOut
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            SKU A = new SKU('A', 50, 3);
            SKU B = new SKU('B', 30, 5);
            SKU C = new SKU('C', 20);
            SKU D = new SKU('D', 15);
            SKU E = new SKU('E', 10,3);
            SKU F = new SKU('F', 10,2);

            Order order = new Order();
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
