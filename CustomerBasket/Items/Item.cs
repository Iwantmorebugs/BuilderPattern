using System;

namespace CustomerBasket.Items
{
  public class Item : IItem
  {
    public Item(string itemName, decimal price)
    {
      ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
      Price = price;
    }

    public decimal Price { get; }
    public string ItemName { get; }
  }
}