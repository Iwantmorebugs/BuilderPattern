using System;
using System.Collections.Generic;

namespace SalesOrder.DiscountRules
{
  public class SeniorRule : IDiscountRule
  {
    private const int KeyOrder = 1;
    private const decimal RuleDiscount = 0.05m;

    private readonly Func<CustomerBasket.CustomerBasket, bool> _isSenior = customerBasket =>
      customerBasket.Customer.DateOfBirth < DateTime.Now.AddYears(-65);

    public int Key => KeyOrder;
    public decimal Discount => RuleDiscount;

    public bool IsApplicable(CustomerBasket.CustomerBasket customerBasket, IEnumerable<IDiscountRule> appliedRules)
    {
      return _isSenior(customerBasket);
    }

    public decimal CalculateDiscount(CustomerBasket.CustomerBasket customerBasket)
    {
      if (_isSenior(customerBasket)) return RuleDiscount;
      return 0;
    }
  }
}