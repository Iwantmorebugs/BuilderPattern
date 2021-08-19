using System;
using System.Collections.Generic;
using BuilderPattern.Items;

namespace BuilderPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myCustomerBasket = new CustomerBasket();

            var customer = new Customer("FeliX", "Saenz", "Abbey Road, 13");
            myCustomerBasket.AddCustomer(customer);

            var item1 = new Item("Lightbulb", 10);
            var item2 = new Item("BasicDesk", 30);
            var item3 = new PremiumItem("PremiumChair", 100);

            var items = new List<Item>();

            items.Add(item1);
            items.Add(item1);
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            myCustomerBasket.AddItems(items);

            Console.WriteLine(
                $"Total price of the customerBasket is {myCustomerBasket.GetTotal()}$ and the shipping price is {myCustomerBasket.ShippingCost}");
            Console.ReadKey();
        }
    }
}