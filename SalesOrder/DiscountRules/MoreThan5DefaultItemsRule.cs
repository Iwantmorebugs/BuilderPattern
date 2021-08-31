using System;
using System.Collections.Generic;
using System.Linq;

namespace SalesOrder.DiscountRules
{
  public class MoreThan5DefaultItemsRule : IDiscountRule
  {
    private const int NumberOfItemsToGetDiscount = 5;
    private const decimal RuleDiscount = 0.05m;
    private const int KeyOrder = 3;
    private readonly IDiscountRule _incompatibleRule;
    private readonly List<IDiscountRule> _incompatibleRules = new();

    private readonly Func<CustomerBasket.CustomerBasket, bool> _isMoreThan5DefaultItemsRule = customerBasket =>
      customerBasket.Items.Count() > NumberOfItemsToGetDiscount;

    public MoreThan5DefaultItemsRule()
    {
      _incompatibleRule = new SeniorRule();
      _incompatibleRules.Add(_incompatibleRule);
    }

    public int Key => KeyOrder;
    public decimal Discount => RuleDiscount;

    public bool IsApplicable(CustomerBasket.CustomerBasket customerBasket, IEnumerable<IDiscountRule> appliedRules)
    {
      return _isMoreThan5DefaultItemsRule(customerBasket) && CheckIfIncompatibleRuleNeverApplied(appliedRules);
    }

    public decimal CalculateDiscount(CustomerBasket.CustomerBasket customerBasket)
    {
      if (_isMoreThan5DefaultItemsRule(customerBasket)) return RuleDiscount;
      return 0;
    }

    private bool CheckIfIncompatibleRuleNeverApplied(IEnumerable<IDiscountRule> appliedRules)
    {
      return !appliedRules.Any(x => _incompatibleRules.Any(y => x.GetType().Name == y.GetType().Name));
    }
  }
}