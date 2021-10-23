using Calculator.Core.Calculations.Company;
using Calculator.Models.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Calculator.Api.Extensions.Calculations
{
    public static class OwnCompanyExtension
    {
        public static void AddOwnCompany(this IServiceCollection services)
        {
            services.AddTransient<ICalculation, CompanyCarCalculation>();
        }
    }
}
