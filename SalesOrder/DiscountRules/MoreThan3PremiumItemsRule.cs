using System;
using System.Collections.Generic;
using System.Linq;
using CustomerBasket.Items;

namespace SalesOrder.DiscountRules
{
  public class MoreThan3PremiumItemsRule : IDiscountRule
  {
    private const int NumberOfPremiumItemsToGetDiscount = 3;
    private const decimal RuleDiscount = 0.07m;
    private const int KeyOrder = 4;
    private readonly List<IDiscountRule> _incompatibleRules = new();

    private readonly Func<CustomerBasket.CustomerBasket, bool> _isMoreThan3PremiumItemsRule = customerBasket =>
      customerBasket.Items.OfType<PremiumItem>().Count() > NumberOfPremiumItemsToGetDiscount;

    public MoreThan3PremiumItemsRule()
    {
      IDiscountRule incompatibleRule = new MoreThan5DefaultItemsRule();
      _incompatibleRules.Add(incompatibleRule);
    }

    public int Key => KeyOrder;
    public decimal Discount => RuleDiscount;

    public decimal CalculateDiscount(CustomerBasket.CustomerBasket customerBasket)
    {
      if (_isMoreThan3PremiumItemsRule(customerBasket)) return RuleDiscount;
      return 0;
    }

    public bool IsApplicable(CustomerBasket.CustomerBasket customerBasket, IEnumerable<IDiscountRule> appliedRules)
    {
      return _isMoreThan3PremiumItemsRule(customerBasket) && CheckIfIncompatibleRuleNeverApplied(appliedRules);
    }

    private bool CheckIfIncompatibleRuleNeverApplied(IEnumerable<IDiscountRule> appliedRules)
    {
      return !appliedRules.Any(x => _incompatibleRules.Any(y => x.GetType().Name == y.GetType().Name));
    }
  }
}