using System;
using System.Collections.Generic;
using System.Linq;
using BuilderPattern.Exceptions;
using BuilderPattern.Items;

namespace BuilderPattern
{
    public class CustomerBasket
    {
        private const int DefaultShippingChost = 10;
        private const int FreeShippingChost = 0;

        public readonly Guid CustomerBasketId;
        private bool _closed;
        private double _totalCost;
        public Customer Customer;
        public List<Item> Items;
        public int ShippingCost;

        public CustomerBasket()
        {
            CustomerBasketId = Guid.NewGuid();
            Items = new List<Item>();
            _totalCost = 0;
            Customer = null;
            _closed = false;
            ShippingCost = DefaultShippingChost;
        }

        public void CloseCustomerBasket()
        {
            if (_closed) throw new CustomerBasketAlreadyClosedException();
            if (Customer is null) throw new NoCustomerFoundException();
            if (!Items.Any()) throw new NoItemsFoundException();

            if (_closed is false)
                _closed = true;
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

        public double GetTotal()
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