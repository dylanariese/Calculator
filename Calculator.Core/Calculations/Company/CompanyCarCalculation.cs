using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using Calculator.Models.Models.Company;
using Calculator.Models.Statics;
using System.Threading.Tasks;

namespace Calculator.Core.Calculations.Company
{
    public class CompanyCarCalculation : IStandaloneCalculation, ICalculation
    {
        private readonly ISharedCollection shared;

        public CompanyCarCalculation(ISharedCollection shared)
        {
            this.shared = shared;
        }

        public async Task CalculateAsync(CalculationCollection values)
        {
            var ownCompany = values.Income.OwnCompany;

            if (ownCompany.DrivenKilometers < 500)
            {
                shared.Collection.TryAdd(Keys.CompanyCar, 0);

                return;
            }

            if (ownCompany.NewValue.Amount == 0)
            {
                shared.Collection.TryAdd(Keys.CompanyCar, 0);

                return;
            }

            if (ownCompany.NewValue.Rate != 0)
            {
                ownCompany.NewValue.Amount = ownCompany.NewValue.Amount / ownCompany.NewValue.Rate;
            }

            //todo: get correct value from database
            var companyCar = await Task.FromResult(new CompanyCar { Deduction = 2500 });

            var value = companyCar.Deduction / 100 * ownCompany.NewValue.Amount;

            shared.Collection.TryAdd(Keys.CompanyCar, value);
        }
    }
}
