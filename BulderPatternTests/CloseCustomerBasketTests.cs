using System;
using BuilderPattern.Exceptions;
using BulderPatternTests.Setup;
using FluentAssertions;
using Xunit;

namespace BulderPatternTests
{
    public class CloseCustomerBasketTests : TestSetup
    {
        [Fact]
        public void CloseCustomerBasket_Returns_NoCustomerFoundException_WhenNoCustomerIsAdded()
        {
            var customerBasket = CustomerBasketBuilder
                .WithItem(ItemWithPrice10)
                .WithItem(ItemWithPrice30).Build();

            Action _sut = () => customerBasket.CloseCustomerBasket();

            _sut.Should().Throw<NoCustomerFoundException>();
        }

        [Fact]
        public void CloseCustomerBasket_Returns_CustomerBasketAlreadyClosedException_WhenNoCustomerIsAdded()
        {
            var customerBasket = CustomerBasketBuilder
                .WithCustomer(Customer1)
                .WithItem(ItemWithPrice10)
                .WithItem(ItemWithPrice30).Build();

            customerBasket.CloseCustomerBasket();

            Action _sut = () => customerBasket.CloseCustomerBasket();

            _sut.Should().Throw<CustomerBasketAlreadyClosedException>();
        }

        [Fact]
        public void CloseCustomerBasket_Returns_NoItemsFoundException_WhenNoCustomerIsAdded()
        {
            var customerBasket = CustomerBasketBuilder
                .WithCustomer(Customer1)
                .Build();

            Action _sut = () => customerBasket.CloseCustomerBasket();

            _sut.Should().Throw<NoItemsFoundException>();
        }
    }
}