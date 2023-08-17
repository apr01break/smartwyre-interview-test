using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Handlers;
using Smartwyre.DeveloperTest.Handlers.IncentiveTypes;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Services;

public class RebateService : IRebateService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IncentiveTypeStrategy _incentiveTypeStrategy;
    public RebateService(IUnitOfWork unitOfWork, IncentiveTypeStrategy incentiveTypeStrategy)
    {
        _unitOfWork = unitOfWork;
        _incentiveTypeStrategy = incentiveTypeStrategy;
    }

    public CalculateRebateResult Calculate(CalculateRebateRequest request)
    {
        Rebate rebate = _unitOfWork.RebateDataStore.GetRebate(request.RebateIdentifier);
        Product product = _unitOfWork.ProductDataStore.GetProduct(request.ProductIdentifier);
        
        var result = new CalculateRebateResult();

        var rebateAmount = 0m;

        result.Success = _incentiveTypeStrategy.IsValid(rebate.Incentive, rebate, product, request, ref rebateAmount);        

        if (result.Success)
        {
            _unitOfWork.RebateDataStore.StoreCalculationResult(rebate, rebateAmount);
            _unitOfWork.Commit();
        }

        return result;
    }
}
