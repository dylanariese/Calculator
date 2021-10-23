using Calculator.Api.Extensions.Calculations;
using Calculator.Core.Runner;
using Calculator.Models.Interfaces;
using Calculator.Shared;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Api.Extensions
{
    public static class CalculatorServiceCollectionExtensions
    {
        public static void AddCalculation(this IServiceCollection services)
        {
            services.AddScoped<ISharedCollection, SharedCollection>();
            services.AddScoped<IRunner, CalculationRunner>();

            services.AddOwnCompany();
            services.AddPersonalDeduction();
        }
    }
}
