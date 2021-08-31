using System;
using System.Linq;
using SalesOrder.DiscountRules;

namespace SalesOrder.DiscountRulesEngine
{
  public class DiscountCalculator : IDiscountCalculator
  {
    public DiscountResult CalculateDiscountPercentage(CustomerBasket.CustomerBasket customerBasket)
    {
      var ruleType = typeof(IDiscountRule);
      var rules = GetType().Assembly.GetTypes()
        .Where(p => ruleType.IsAssignableFrom(p) && !p.IsInterface)
        .Select(r => Activator.CreateInstance(r) as IDiscountRule);
      rules = rules.OrderBy(o => o.Key);

      var engine = new DiscountRuleEngine(rules);

      return engine.CalculateDiscountPercentage(customerBasket);
    }
  }
}