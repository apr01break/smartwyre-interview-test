using Moq;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Handlers;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
using Xunit;

namespace Smartwyre.DeveloperTest.Tests;

public class RebateServiceTests
{
    [Fact]
    public void Calculate_ValidRequestAmountPerUom_ReturnsSuccessTrue()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 50
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void Calculate_InvalidRequestAmountPerUom_ReturnsFalse()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.AmountPerUom
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.AmountPerUom,
            Amount = 50
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 0
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void Calculate_ValidRequestFixedCashAmount_ReturnsSuccessTrue()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 50
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void Calculate_InvalidRequestFixedCashAmount_ReturnsSuccessFalse()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedCashAmount
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.FixedCashAmount,
            Amount = 0
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }

    [Fact]
    public void Calculate_ValidRequestFixedRateRebate_ReturnsSuccessTrue()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 90
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 50,
            Percentage = 80
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.True(result.Success);
    }

    [Fact]
    public void Calculate_InvalidRequestFixedRateRebate_ReturnsSuccessFalse()
    {
        var unitOfWorkMock = new Mock<IUnitOfWork>();
        unitOfWorkMock.Setup(db => db.ProductDataStore.GetProduct(It.IsAny<string>())).Returns(new Product()
        {
            SupportedIncentives = SupportedIncentiveType.FixedRateRebate,
            Price = 0
        });
        unitOfWorkMock.Setup(db => db.RebateDataStore.GetRebate(It.IsAny<string>())).Returns(new Rebate()
        {
            Incentive = IncentiveType.FixedRateRebate,
            Amount = 50,
            Percentage = 0
        });
        IRebateService rebateService = new RebateService(unitOfWorkMock.Object, new IncentiveTypeStrategy());
        var request = new CalculateRebateRequest()
        {
            Volume = 40
        };

        CalculateRebateResult result = rebateService.Calculate(request);

        Assert.NotNull(result);
        Assert.False(result.Success);
    }
}
