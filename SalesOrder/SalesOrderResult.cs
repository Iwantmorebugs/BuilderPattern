using SalesOrder.DiscountRulesEngine;

namespace SalesOrder
{
  public class SalesOrderResult
  {
    public SalesOrderResult(DiscountResult totalDiscount, decimal totalCost)
    {
      TotalDiscountResult = totalDiscount;
      TotalCost = totalCost;
    }

    public DiscountResult TotalDiscountResult { get; }
    public decimal TotalCost { get; }
  }
}