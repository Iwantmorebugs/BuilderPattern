using System;
using System.Collections.Generic;
using System.Linq;
using SalesOrder.DiscountRules;

namespace SalesOrder.DiscountRulesEngine
{
  public class DiscountResult
  {
    public DiscountResult(IEnumerable<IDiscountRule> appliedDiscountRules)
    {
      AppliedDiscountRules = appliedDiscountRules ?? throw new ArgumentNullException(nameof(appliedDiscountRules));
    }

    public IEnumerable<IDiscountRule> AppliedDiscountRules { get; }

    public decimal TotalDiscountApplied
    {
      get { return AppliedDiscountRules.Select(x => x.Discount).Sum(); }
    }
  }
}