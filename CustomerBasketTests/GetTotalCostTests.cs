using CustomerBasketTests.Setup;
using FluentAssertions;
using Xunit;

namespace CustomerBasketTests
{
  public class GetTotalCostTests : TestSetup
  {
    [Fact]
    public void GetTotal_Should_Return_Cost_WithDefaultShippingCost_When_No_PremiumItemIsAdded()
    {
      var expectedCost = 50;

      var _sut =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteran)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice30)
          .Build();

      _sut.GetTotal().Should().Be(expectedCost);
      _sut.ShippingCost.Should().Be(DefaultShippingChost);
    }

    [Fact]
    public void GetTotal_Should_Return_TotalCost_WithFreetShippingCost_When_PremiumItemIsAdded()
    {
      var expectedCost = 100;

      var _sut =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteran)
          .WithItem(PremiumItemWithPrice100)
          .Build();

      _sut.GetTotal().Should().Be(expectedCost);
      _sut.ShippingCost.Should().Be(FreeShippingChost);
    }

    [Fact]
    public void
      GetTotal_Should_Return_TotalCost_WithFreetShippingCost_When_PremiumItemIsAdded_With_OtherDefaultItems()
    {
      var expectedCost = 140;

      var _sut =
        CustomerBasketBuilder
          .WithCustomer(CustomerNotVeteran)
          .WithItem(ItemWithPrice10)
          .WithItem(ItemWithPrice30)
          .WithItem(PremiumItemWithPrice100)
          .Build();

      _sut.GetTotal().Should().Be(expectedCost);
      _sut.ShippingCost.Should().Be(FreeShippingChost);
    }

    [Fact]
    public void GetTotal_Should_Return_DefaultShippingChost_When_PremiumItem_Is_Added_And_ThenRemoved()
    {
      var expectedCostWithoutPremium = 50;
      var expectedCostWithPremium = 140;

      var _sut = CustomerBasketBuilder
        .WithCustomer(CustomerNotVeteran)
        .WithItem(ItemWithPrice10)
        .WithItem(ItemWithPrice30)
        .WithItem(PremiumItemWithPrice100)
        .Build();

      _sut.GetTotal().Should().Be(expectedCostWithPremium);
      _sut.ShippingCost.Should().Be(FreeShippingChost);

      _sut.RemoveItem(PremiumItemWithPrice100);

      _sut.GetTotal().Should().Be(expectedCostWithoutPremium);
      _sut.ShippingCost.Should().Be(DefaultShippingChost);
    }
  }
}