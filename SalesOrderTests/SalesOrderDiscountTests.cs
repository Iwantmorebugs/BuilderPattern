using System.Linq;
using FluentAssertions;
using SalesOrder.DiscountRules;
using SalesOrderTests.Setup;
using Xunit;

namespace SalesOrderTests
{
  public class SalesOrderDiscountTests : TestSetup
  {
    private const decimal SeniorDiscountValue = .05m;
    private const decimal VeteranDiscountValue = .10m;
    private const decimal MoreThan3PremiumItemsDiscount = .07m;
    private const decimal MoreThan5DefaultItemsDiscount = .05m;
    private SalesOrder.SalesOrder _sut;


    [Fact]
    public void When_Customer_IsOnlySenior_Then_OnlySeniorDiscountRule_ShouldBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteranSenior)
          .WithItem(ItemWithPrice10)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var seniorRule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      seniorRule.Should().NotBeNull();
      seniorRule.Should().BeOfType<SeniorRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(SeniorDiscountValue);
    }

    [Fact]
    public void When_Customer_IsOnlyVeteran_Then_OnlyVeteranDiscountRule_ShouldBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerVeteranNotSenior)
          .WithItem(ItemWithPrice10)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var veteranRule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      veteranRule.Should().NotBeNull();
      veteranRule.Should().BeOfType<VeteranRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(VeteranDiscountValue);
    }

    [Fact]
    public void When_ThereAreMoreThan5DefaultItems_And_CustomerNotSeniorNotVeteran_Then_ItsOnlyRule_ShouldBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteranNotSenior)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var veteranRule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      veteranRule.Should().NotBeNull();
      veteranRule.Should().BeOfType<MoreThan5DefaultItemsRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(MoreThan5DefaultItemsDiscount);
    }

    [Fact]
    public void When_TheAreMoreThan3PremiumtItems_And_CustomerNotSeniorNotVeteran_Then_ItsOnlyRule_ShouldBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteranNotSenior)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var veteranRule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      veteranRule.Should().NotBeNull();
      veteranRule.Should().BeOfType<MoreThan3PremiumItemsRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(MoreThan3PremiumItemsDiscount);
    }

    [Fact]
    public void When_MoreThan5DefaultItemRuleApplied_Then_MoreThan3PremiumItemRule_ShouldNotBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteranNotSenior)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .WithItem(PremiumItemWithPrice100)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var rule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      rule.Should().NotBeNull();
      rule.Should().NotBeOfType<MoreThan3PremiumItemsRule>();
      rule.Should().BeOfType<MoreThan5DefaultItemsRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(MoreThan5DefaultItemsDiscount);
    }

    [Fact]
    public void When_SeniorRuleApplied_Then_MoreThan5DefaultItemRule_ShouldNotBeApplied()
    {
      var customerBasket =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteranNotSenior)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice10)
          .WithCustomer(CustomerNotVeteranSenior)
          .Build();

      customerBasket.CloseCustomerBasket();

      _sut = new SalesOrder.SalesOrder(customerBasket, DiscountCalculator);

      var result = _sut.ProcessSalesOrder();
      var rule = result.TotalDiscountResult.AppliedDiscountRules.FirstOrDefault();

      rule.Should().NotBeNull();
      rule.Should().NotBeOfType<MoreThan5DefaultItemsRule>();
      rule.Should().BeOfType<SeniorRule>();

      result.TotalDiscountResult.AppliedDiscountRules.Count().Should().Be(1);
      result.TotalDiscountResult.TotalDiscountApplied.Should().Be(SeniorDiscountValue);
    }
  }
}