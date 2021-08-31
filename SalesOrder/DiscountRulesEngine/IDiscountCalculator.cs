namespace SalesOrder.DiscountRulesEngine
{
  public interface IDiscountCalculator
  {
    DiscountResult CalculateDiscountPercentage(CustomerBasket.CustomerBasket customerBasket);
  }
}