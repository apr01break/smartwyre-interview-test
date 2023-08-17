using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers.IncentiveTypes
{
    public interface IIncentiveTypeHandler
    {
        bool IsValid(Rebate rebate, Product product, CalculateRebateRequest request, ref decimal rebateAmount);
        static virtual IncentiveType Name { get; }
    }
}
