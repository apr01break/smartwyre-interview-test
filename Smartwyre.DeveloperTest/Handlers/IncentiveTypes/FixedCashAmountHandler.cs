using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Handlers.IncentiveTypes
{
    public class FixedCashAmountHandler : IIncentiveTypeHandler
    {
        public static IncentiveType Name => IncentiveType.FixedCashAmount;
        public bool IsValid(Rebate rebate, Product product, CalculateRebateRequest request, ref decimal rebateAmount)
        {
            bool result;
            if (rebate == null)
            {
                result = false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedCashAmount))
            {
                result = false;
            }
            else if (rebate.Amount == 0)
            {
                result = false;
            }
            else
            {
                rebateAmount = rebate.Amount;
                result = true;
            }
            return result;
        }
    }
}
