using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Data;
using Smartwyre.DeveloperTest.Handlers;
using Smartwyre.DeveloperTest.Services;
using Smartwyre.DeveloperTest.Types;
using System;
//using System.Web.Services;

namespace Smartwyre.DeveloperTest.Runner;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRebateService, RebateService>()
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddSingleton<IncentiveTypeStrategy>()
                .BuildServiceProvider();
            var rebateService = serviceProvider.GetService<IRebateService>();
            var request = new CalculateRebateRequest();
            Console.Write("Enter the RebateIdentifier: ");
            request.RebateIdentifier = Console.ReadLine();
            Console.Write("Enter the ProductIdentifier: ");
            request.ProductIdentifier = Console.ReadLine();
            Console.Write("Enter the Volume (decimal): ");
            request.Volume = Convert.ToDecimal(Console.ReadLine());
            CalculateRebateResult result = rebateService.Calculate(request);
            Console.WriteLine($"The result is: {result.Success}");
        }
        catch (Exception)
        {
            Console.WriteLine("The Volume must be a decimal. Try again.");
        }
    }
}
