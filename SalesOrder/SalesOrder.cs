using System;
using SalesOrder.DiscountRulesEngine;
using SalesOrder.Exceptions;

namespace SalesOrder
{
  public class SalesOrder
  {
    private const decimal InitialCost = 0;
    private readonly CustomerBasket.CustomerBasket _customerBasket;
    private readonly IDiscountCalculator _discountCalculator;
    public readonly Guid BusinessProcessId;
    public decimal SalesOrderTotalCost;

    public SalesOrder(CustomerBasket.CustomerBasket customerBasket, IDiscountCalculator discountCalculator)
    {
      _customerBasket = customerBasket;
      _discountCalculator = discountCalculator;
      BusinessProcessId = Guid.NewGuid();
      SalesOrderTotalCost = InitialCost;
    }

    public SalesOrderResult ProcessSalesOrder()
    {
      if (_customerBasket.Closed)
      {
        var discountResult = _discountCalculator.CalculateDiscountPercentage(_customerBasket);
        ApplyDiscount(_customerBasket, discountResult.TotalDiscountApplied);

        return new SalesOrderResult(discountResult, SalesOrderTotalCost);
      }

      throw new CustomerBasketNotClosedException();
    }

    private void ApplyDiscount(CustomerBasket.CustomerBasket customerBasket, decimal totalDiscount)
    {
      SalesOrderTotalCost = customerBasket.GetTotal() * (1 - totalDiscount);
    }
  }
}