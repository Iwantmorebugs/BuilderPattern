using System;

namespace CustomerBasket
{
  public class Customer
  {
    public Customer(string name, string surname, string shippingAddress, bool isVeteran, DateTime? dateOfBirth)
    {
      Name = name ?? throw new ArgumentNullException(nameof(name));
      Surname = surname ?? throw new ArgumentNullException(nameof(surname));
      ShippingAddress = shippingAddress ?? throw new ArgumentNullException(nameof(shippingAddress));
      IsVeteran = isVeteran;
      DateOfBirth = dateOfBirth;
    }

    public string Name { get; }
    public DateTime? DateOfBirth { get; set; }
    public string Surname { get; }
    public string ShippingAddress { get; }
    public bool IsVeteran { get; set; }
  }
}