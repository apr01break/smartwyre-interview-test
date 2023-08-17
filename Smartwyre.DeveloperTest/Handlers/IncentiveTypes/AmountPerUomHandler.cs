using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Smartwyre.DeveloperTest.Types;

namespace Smartwyre.DeveloperTest.Handlers.IncentiveTypes
{
    public class AmountPerUomHandler : IIncentiveTypeHandler
    {
        public static IncentiveType Name => IncentiveType.AmountPerUom;
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
            else if (!product.SupportedIncentives.HasFlag(SupportedIncentiveType.AmountPerUom))
            {
                result = false;
            }
            else if (rebate.Amount == 0 || request.Volume == 0)
            {
                result = false;
            }
            else
            {
                rebateAmount += rebate.Amount * request.Volume;
                result = true;
            }
            return result;
        }
    }
}
