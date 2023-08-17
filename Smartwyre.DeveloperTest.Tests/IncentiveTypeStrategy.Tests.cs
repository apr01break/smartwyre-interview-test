using Moq;
using Smartwyre.DeveloperTest.Handlers;
using Smartwyre.DeveloperTest.Handlers.IncentiveTypes;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class IncentiveTypeStrategyTests
{
    [Fact]
    public void IsValid_AmountPerUonHandler_False()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        Product product = null;
        Rebate rebate = null;
        CalculateRebateRequest request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.AmountPerUom, rebate, product, request, ref rebateAmount);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_AmountPerUonHandler_ReturnsTrue()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
        var rebate = new Rebate()
        {
            Amount = 50
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.AmountPerUom, rebate, product, request, ref rebateAmount);

        Assert.True(result);
    }

    [Fact]
    public void IsValid_AmountPerUon_ReturnsWrongRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product();
        var rebate = new Rebate()
        {
            Amount = 80
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 60
        };
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = rebate.Amount * request.Volume;

        incentiveTypeStrategy.IsValid(IncentiveType.AmountPerUom, rebate, product, request, ref rebateAmount);

        Assert.NotEqual(expectedRebaseAmount, rebateAmount);
    }

    [Fact]
    public void IsValid_AmountPerUon_ReturnsCorrectRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        };
        var rebate = new Rebate()
        {
            Amount = 80
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 60
        };
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = rebate.Amount * request.Volume;

        incentiveTypeStrategy.IsValid(IncentiveType.AmountPerUom, rebate, product, request, ref rebateAmount);

        Assert.Equal(expectedRebaseAmount, rebateAmount);
    }

    [Fact]
    public void IsValid_FixedCashAmount_False()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        Product product = null;
        Rebate rebate = null;
        CalculateRebateRequest request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.FixedCashAmount, rebate, product, request, ref rebateAmount);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_FixedCashAmount_ReturnsTrue()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };
        var rebate = new Rebate()
        {
            Amount = 50
        };
        var request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.FixedCashAmount, rebate, product, request, ref rebateAmount);

        Assert.True(result);
    }

    [Fact]
    public void IsValid_FixedCashAmount_ReturnsWrongRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product();
        var rebate = new Rebate()
        {
            Amount = 80
        };
        var request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = rebate.Amount;

        incentiveTypeStrategy.IsValid(IncentiveType.FixedCashAmount, rebate, product, request, ref rebateAmount);

        Assert.NotEqual(expectedRebaseAmount, rebateAmount);
    }

    [Fact]
    public void IsValid_FixedCashAmount_ReturnsCorrectRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        };
        var rebate = new Rebate()
        {
            Amount = 80
        };
        var request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = rebate.Amount;

        incentiveTypeStrategy.IsValid(IncentiveType.FixedCashAmount, rebate, product, request, ref rebateAmount);

        Assert.Equal(expectedRebaseAmount, rebateAmount);
    }

    [Fact]
    public void IsValid_FixedRateRebate_False()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        Product product = null;
        Rebate rebate = null;
        CalculateRebateRequest request = new CalculateRebateRequest();
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.FixedRateRebate, rebate, product, request, ref rebateAmount);

        Assert.False(result);
    }

    [Fact]
    public void IsValid_FixedRateRebate_ReturnsTrue()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 35
        };
        var rebate = new Rebate()
        {
            Percentage = 50
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };
        decimal rebateAmount = 0m;

        bool result = incentiveTypeStrategy.IsValid(IncentiveType.FixedRateRebate, rebate, product, request, ref rebateAmount);

        Assert.True(result);
    }

    [Fact]
    public void IsValid_FixedRateRebate_ReturnsWrongRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            Price = 35
        };
        var rebate = new Rebate()
        {
            Percentage = 80
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 60
        };
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = product.Price * rebate.Percentage * request.Volume;

        incentiveTypeStrategy.IsValid(IncentiveType.FixedRateRebate, rebate, product, request, ref rebateAmount);

        Assert.NotEqual(expectedRebaseAmount, rebateAmount);
    }

    [Fact]
    public void IsValid_FixedRateRebate_ReturnsCorrectRebateAmount()
    {
        var incentiveTypeStrategy = new IncentiveTypeStrategy();
        var product = new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate
        };
        var rebate = new Rebate()
        {
            Percentage = 80
        };
        var request = new CalculateRebateRequest()
        {
            Volume = 60
        };
        decimal rebateAmount = 0m;
        decimal expectedRebaseAmount = product.Price * rebate.Percentage * request.Volume;

        incentiveTypeStrategy.IsValid(IncentiveType.FixedRateRebate, rebate, product, request, ref rebateAmount);

        Assert.Equal(expectedRebaseAmount, rebateAmount);
    }
}
