using Smartwyre.DeveloperTest.Handlers.IncentiveTypes;
using Smartwyre.DeveloperTest.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Smartwyre.DeveloperTest.Handlers
{
    public class IncentiveTypeStrategy
    {
        private readonly Dictionary<IncentiveType, Type> _handlers;
        public IncentiveTypeStrategy()
        {
            _handlers = Assembly.GetExecutingAssembly().DefinedTypes
            .Where(x => typeof(IIncentiveTypeHandler).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
            .ToDictionary(
                info => (IncentiveType)info.GetProperty(nameof(IIncentiveTypeHandler.Name))?.GetValue(null),
                info => info.AsType());
        }

        public bool IsValid(IncentiveType type, Rebate rebate, Product product, CalculateRebateRequest request, ref decimal rebateAmount)
        {
            var handler = _handlers[type];
            var incentiveTypeHandler = Activator.CreateInstance(handler) as IIncentiveTypeHandler;
            return incentiveTypeHandler.IsValid(rebate, product, request, ref rebateAmount);
        }
    }
}
