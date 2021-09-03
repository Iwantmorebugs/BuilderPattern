using System;
using System.Collections.Generic;

namespace SalesOrder.DiscountRules
{
  public class VeteranRule : IDiscountRule
  {
    private const int KeyOrder = 2;
    private const decimal RuleDiscount = 0.1m;

    private readonly Func<CustomerBasket.CustomerBasket, bool> _isVeteran = customerBasket =>
      customerBasket.Customer.IsVeteran;

    public int Key => KeyOrder;
    public decimal Discount => RuleDiscount;

    public decimal CalculateDiscount(CustomerBasket.CustomerBasket customerBasket)
    {
      if (_isVeteran(customerBasket)) return RuleDiscount;
      return 0;
    }

    public bool IsApplicable(CustomerBasket.CustomerBasket customerBasket, IEnumerable<IDiscountRule> appliedRules)
    {
      return _isVeteran(customerBasket);
    }
  }
}