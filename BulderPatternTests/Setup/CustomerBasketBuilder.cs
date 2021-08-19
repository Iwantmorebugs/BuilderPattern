using System.Collections.Generic;
using BuilderPattern;
using BuilderPattern.Items;

namespace BulderPatternTests.Setup
{
    public class CustomerBasketBuilder
    {
        private const int DefaultShippingChost = 10;
        private readonly List<Item> _items;

        private Customer _customer;
        private double _totalCost;

        public CustomerBasketBuilder()
        {
            _customer = null;
            _items = new List<Item>();
            _totalCost = 0;
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

        public CustomerBasket Build()
        {
            var customerBasket = new CustomerBasket();
            customerBasket.ShippingCost = DefaultShippingChost;
            customerBasket.AddCustomer(_customer);
            customerBasket.AddItems(_items);

            return customerBasket;
        }
    }
}