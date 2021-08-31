using System;
using System.Collections.Generic;
using System.Linq;
using CustomerBasket;
using CustomerBasket.Items;

namespace SalesOrder
{
  internal class Program
  {
    private static void Main(string[] args)
    {
      var customerBasket = GenerateCustomerBasket();

      var salesOrder = new SalesOrder(customerBasket);

      var salesOrderResult = salesOrder.ProcessSalesOrder();

      salesOrderResult.TotalDiscountResult.AppliedDiscountRules.ToList().ForEach(discount =>
        Console.WriteLine($"The following discount rules were applied: {discount.GetType().Name}"));
      Console.WriteLine(
        $"The total discount is of {salesOrderResult.TotalDiscountResult.TotalDiscountApplied} and the total price: {salesOrderResult.TotalCost}");
      Console.ReadKey();
    }

    private static CustomerBasket.CustomerBasket GenerateCustomerBasket()
    {
      var customerBasket = new CustomerBasket.CustomerBasket();

      var customer = new Customer("FeliX", "Saenz", "Abbey Road, 13", true, DateTime.Now.AddYears(-65));
      customerBasket.AddCustomer(customer);

      var item1 = new Item("Lightbulb", 10);
      var item2 = new Item("BasicDesk", 30);
      var item3 = new PremiumItem("PremiumChair", 100);

      var items = new List<Item>();

      items.Add(item1);
      items.Add(item1);
      items.Add(item1);
      items.Add(item2);
      items.Add(item3);
      items.Add(item3);
      items.Add(item3);

      customerBasket.AddItems(items);
      customerBasket.CloseCustomerBasket();

      return customerBasket;
    }
  }
}