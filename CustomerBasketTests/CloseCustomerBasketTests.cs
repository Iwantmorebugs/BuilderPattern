using System;
using CustomerBasket.Exceptions;
using CustomerBasketTests.Setup;
using FluentAssertions;
using Xunit;

namespace CustomerBasketTests
{
  public class CloseCustomerBasketTests : TestSetup
  {
    private Action _sut;

    [Fact]
    public void CloseCustomerBasket_Returns_NoCustomerFoundException_WhenNoCustomerIsAdded()
    {
      var customerBasket = CustomerBasketBuilder
        .WithItem(ItemWithPrice10)
        .WithItem(ItemWithPrice30).Build();

      _sut = () => customerBasket.CloseCustomerBasket();

      _sut.Should().Throw<NoCustomerFoundException>();
    }

    [Fact]
    public void CloseCustomerBasket_Returns_CustomerBasketAlreadyClosedException_WhenNoCustomerIsAdded()
    {
      var customerBasket = CustomerBasketBuilder
        .WithCustomer(CustomerNotVeteran)
        .WithItem(ItemWithPrice10)
        .WithItem(ItemWithPrice30).Build();

      customerBasket.CloseCustomerBasket();

      _sut = () => customerBasket.CloseCustomerBasket();

      _sut.Should().Throw<CustomerBasketAlreadyClosedException>();
    }

    [Fact]
    public void CloseCustomerBasket_Returns_NoItemsFoundException_WhenNoCustomerIsAdded()
    {
      var customerBasket = CustomerBasketBuilder
        .WithCustomer(CustomerNotVeteran)
        .Build();

      _sut = () => customerBasket.CloseCustomerBasket();

      _sut.Should().Throw<NoItemsFoundException>();
    }
  }
}