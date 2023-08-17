using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.IncentiveTypes
{
    public class FixedRateRebateHandler : IIncentiveTypeHandler
    {
        public static IncentiveType Name => IncentiveType.FixedRateRebate;

        public bool IsValid(Rebate rebate, Product product, CalculateRebateRequest request, ref decimal rebateAmount)
        {
            bool result;
            if (rebate == null)
            {
                result = false;
            }
            else if (product == null)
            {
                result = false;
            }
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.FixedRateRebate))
            {
                result = false;
            }
            else if (rebate.Percentage == 0 || product.Price == 0 || request.Volume == 0)
            {
                result = false;
            }
            else
            {
                rebateAmount += product.Price * rebate.Percentage * request.Volume;
                result = true;
            }
            return result;
        }
    }
}
