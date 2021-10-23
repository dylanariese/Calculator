using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using Calculator.Models.Statics;
using System;
using System.Threading.Tasks;

namespace Calculator.Core.Calculations.Personal
{
    public class AlimonyTotalCalculation : IDependantCalculation, ICalculation
    {
        private readonly ISharedCollection shared;

        public AlimonyTotalCalculation(ISharedCollection shared)
        {
            this.shared = shared;
        }

        public bool Predicate(CalculationCollection values) =>
            shared.Collection.ContainsKey(Keys.AlimonySubtotal) &&
            shared.Collection.ContainsKey(Keys.AlimonyShare);

        public async Task CalculateAsync(CalculationCollection values)
        {
            var value = await Task.Run(() =>
            {
                shared.Collection.TryGetValue(Keys.AlimonySubtotal, out decimal alimonySubTotal);
                shared.Collection.TryGetValue(Keys.AlimonyShare, out decimal alimonyShare);

                return Math.Ceiling(alimonySubTotal * (alimonyShare / 100));
            });
        }
    }
}
