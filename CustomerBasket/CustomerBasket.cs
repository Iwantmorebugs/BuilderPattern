using System;
using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Exceptions;
using CustomerBasket.Items;

namespace CustomerBasket
{
  public class CustomerBasket
  {
    private const int DefaultShippingChost = 10;
    private const int FreeShippingChost = 0;

    public readonly Guid CustomerBasketId;
    private decimal _totalCost;
    public Customer Customer;
    public List<Item> Items;
    public int ShippingCost;

    public CustomerBasket()
    {
      CustomerBasketId = Guid.NewGuid();
      Items = new List<Item>();
      _totalCost = 0;
      Customer = null;
      Closed = false;
      ShippingCost = DefaultShippingChost;
    }

    public bool Closed { get; private set; }

    public void CloseCustomerBasket()
    {
      if (Closed) throw new CustomerBasketAlreadyClosedException();
      if (Customer is null) throw new NoCustomerFoundException();
      if (!Items.Any()) throw new NoItemsFoundException();

      if (Closed is false)
        Closed = true;
    }

    public void AddCustomer(Customer customer)
    {
      if (Customer is null) Customer = customer;
    }

    public void AddItem(Item item)
    {
      Items.Add(item);
      _totalCost = _totalCost + item.Price;
    }

    public void AddItems(IEnumerable<Item> items)
    {
      Items.AddRange(items);
      _totalCost = _totalCost + items.Sum(x => x.Price);
    }

    public decimal GetTotal()
    {
      if (Items.OfType<PremiumItem>().Any()) ShippingCost = FreeShippingChost;
      else
        ShippingCost = DefaultShippingChost;

      return ShippingCost + _totalCost;
    }

    public void RemoveItem(Item item)
    {
      if (Items.Contains(item))
      {
        Items.Remove(item);
        _totalCost = _totalCost - item.Price;
      }
    }
  }
}