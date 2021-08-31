using System;
using CustomerBasket;
using CustomerBasket.Items;
using CustomerBasketTests.Setup;
using SalesOrder.DiscountRulesEngine;

namespace SalesOrderTests.Setup
{
  public class TestSetup
  {
    protected const int DefaultShippingChost = 10;
    protected const int FreeShippingChost = 0;
    protected DateTime BirthDateNotSenior = DateTime.Now.AddYears(-35);
    protected DateTime BirthDateSenior = DateTime.Now.AddYears(-65);

    protected CustomerBasketBuilder CustomerBasketBuilder;
    protected Customer CustomerNotVeteranNotSenior;
    protected Customer CustomerNotVeteranSenior;
    protected Customer CustomerVeteranNotSenior;
    protected Customer CustomerVeteranSenior;
    protected IDiscountCalculator DiscountCalculator;
    protected bool IsVeteran = true;
    protected Item ItemWithPrice10;
    protected Item ItemWithPrice30;
    protected bool NotVeteran = false;
    protected Item PremiumItemWithPrice100;

    public TestSetup()
    {
      CustomerBasketBuilder = new CustomerBasketBuilder();
      ItemWithPrice10 = new Item("Lightbulb", 10);
      ItemWithPrice30 = new Item("BasicDesk", 30);
      PremiumItemWithPrice100 = new PremiumItem("PremiumChair", 100);
      CustomerVeteranSenior = new Customer("Pepito", "Benito", "Santa Fe", IsVeteran, BirthDateSenior);
      CustomerNotVeteranNotSenior = new Customer("Sebastian", "Elnarco", "Ushuaia", NotVeteran, BirthDateNotSenior);
      CustomerVeteranNotSenior = new Customer("Sebastian", "Elnarco", "Ushuaia", IsVeteran, BirthDateNotSenior);
      CustomerNotVeteranSenior = new Customer("Sebastian", "Elnarco", "Ushuaia", NotVeteran, BirthDateSenior);
      DiscountCalculator = new DiscountCalculator();
    }
  }
}