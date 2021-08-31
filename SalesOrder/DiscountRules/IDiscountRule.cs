using System.Collections.Generic;

namespace SalesOrder.DiscountRules
{
  public interface IDiscountRule
  {
    int Key { get; }
    decimal Discount { get; }
    decimal CalculateDiscount(CustomerBasket.CustomerBasket customerBasket);
    bool IsApplicable(CustomerBasket.CustomerBasket customerBasket, IEnumerable<IDiscountRule> appliedRules);
  }
}