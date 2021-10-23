using Calculator.Core.Calculations.Personal;
using Calculator.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Api.Extensions.Calculations
{
    public static class PersonalDeductionExtension
    {
        public static void AddPersonalDeduction(this IServiceCollection services)
        {
            //non-dependant
            services.AddTransient<ICalculation, AlimonySubtotalCalculation>();
            services.AddTransient<ICalculation, AlimonyShareCalculation>();

            //dependaning on other calculation results
            services.AddTransient<ICalculation, AlimonyTotalCalculation>();
        }
    }
}