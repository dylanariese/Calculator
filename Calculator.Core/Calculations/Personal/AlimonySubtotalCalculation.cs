using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using Calculator.Models.Statics;
using System.Threading.Tasks;

namespace Calculator.Core.Calculations.Personal
{
    public class AlimonySubtotalCalculation : IStandaloneCalculation, ICalculation
    {
        private readonly ISharedCollection shared;

        public AlimonySubtotalCalculation(ISharedCollection shared)
        {
            this.shared = shared;
        }

        //Added just to test AlimonyTotalCalculation
        public async Task CalculateAsync(CalculationCollection values) =>
            shared.Collection.TryAdd(Keys.AlimonySubtotal, 5000m);
    }
}