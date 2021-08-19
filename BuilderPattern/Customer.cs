using System;

namespace BuilderPattern
{
    public class Customer
    {
        public Customer(string name, string surname, string shippingAddress)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Surname = surname ?? throw new ArgumentNullException(nameof(surname));
            ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
        }

        public string Name { get; }
        public string Surname { get; }
        public string ShippingAddress { get; }
    }
}