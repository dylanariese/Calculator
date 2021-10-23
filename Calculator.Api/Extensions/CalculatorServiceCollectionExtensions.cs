using Calculator.Core.Calculations.Company;
using Calculator.Core.Runner;
using Calculator.Models.Interfaces;
using Calculator.Shared;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Calculator.Api.Extensions
{
    public static class CalculatorServiceCollectionExtensions
    {
        public static void AddCalculationServices(this IServiceCollection services)
        {
            services.AddScoped<ISharedCollection, SharedCollection>();
            services.AddScoped<IRunner, CalculationRunner>();

            //auto register all calculators that implement ICalculation
            Assembly.GetAssembly(typeof(CompanyCarCalculation)).GetTypes()
                .Where(type => type.GetInterfaces().Contains(typeof(ICalculation))).ToList()
                .ForEach(type => services.AddTransient(typeof(ICalculation), type));
        }
    }
}
