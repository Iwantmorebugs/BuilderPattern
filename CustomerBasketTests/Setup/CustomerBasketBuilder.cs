using System.Collections.Generic;
using CustomerBasket;
using CustomerBasket.Items;

namespace CustomerBasketTests.Setup
{
  public class CustomerBasketBuilder
  {
    private const int DefaultShippingChost = 10;
    private readonly List<Item> _items;

    private Customer _customer;

    public CustomerBasketBuilder()
    {
      _customer = null;
      _items = new List<Item>();
    }

    public CustomerBasketBuilder WithCustomer(Customer customer)
    {
      _customer = customer;
      return this;
    }

    public CustomerBasketBuilder WithItem(Item item)
    {
      _items.Add(item);
      return this;
    }

    public CustomerBasketBuilder WithItems(IEnumerable<Item> items)
    {
      _items.AddRange(items);
      return this;
    }

    public CustomerBasket.CustomerBasket Build()
    {
      var customerBasket = new CustomerBasket.CustomerBasket();
      customerBasket.ShippingCost = DefaultShippingChost;
      customerBasket.AddCustomer(_customer);
      customerBasket.AddItems(_items);

      return customerBasket;
    }
  }
}