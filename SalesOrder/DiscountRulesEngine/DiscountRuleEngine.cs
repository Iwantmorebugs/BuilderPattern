using System.Collections.Generic;
using System.Collections.ObjectModel;
using SalesOrder.DiscountRules;

namespace SalesOrder.DiscountRulesEngine
{
  public class DiscountRuleEngine
  {
    private readonly List<IDiscountRule> _rules = new();

    public DiscountRuleEngine(IEnumerable<IDiscountRule> rules)
    {
      _rules.AddRange(rules);
    }

    public DiscountResult CalculateDiscountPercentage(CustomerBasket.CustomerBasket customerBasket)
    {
      var appliedRules = new Collection<IDiscountRule>();

      foreach (var rule in _rules)
        if (rule.IsApplicable(customerBasket, appliedRules))
        {
          rule.CalculateDiscount(customerBasket);
          appliedRules.Add(rule);
        }

      return new DiscountResult(appliedRules);
    }
  }
}