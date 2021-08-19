using System;

namespace BuilderPattern.Items
{
    public class Item : IItem
    {
        public Item(string itemName, double price)
        {
            ItemName = itemName ?? throw new ArgumentNullException(nameof(itemName));
            Price = price;
        }

        public double Price { get; }
        public string ItemName { get; }
    }
}