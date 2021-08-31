using System;
using CustomerBasket;
using CustomerBasket.Items;

namespace CustomerBasketTests.Setup
{
  public class TestSetup
  {
    protected const int DefaultShippingChost = 10;
    protected const int FreeShippingChost = 0;
    protected DateTime BirthDateNotVeteran = DateTime.Now.AddYears(-35);
    protected DateTime BirthDateVeteran = DateTime.Now.AddYears(-65);

    protected CustomerBasketBuilder CustomerBasketBuilder;
    protected Customer CustomerNotVeteran;
    protected Customer CustomerVeteran;
    protected bool IsVeteran = true;
    protected Item ItemWithPrice10;
    protected Item ItemWithPrice30;
    protected Item PremiumItemWithPrice100;

    public TestSetup()
    {
      CustomerBasketBuilder = new CustomerBasketBuilder();
      ItemWithPrice10 = new Item("Lightbulb", 10);
      ItemWithPrice30 = new Item("BasicDesk", 30);
      PremiumItemWithPrice100 = new PremiumItem("PremiumChair", 100);
      CustomerVeteran = new Customer("Pepito", "Benito", "Santa Fe", IsVeteran, BirthDateVeteran);
      CustomerNotVeteran = new Customer("Sebastian", "Elnarco", "Ushuaia", IsVeteran, BirthDateNotVeteran);
    }
  }
}