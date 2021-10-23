using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using Calculator.Models.Statics;
using System.Threading.Tasks;

namespace Calculator.Core.Calculations.Personal
{
    public class AlimonyShareCalculation : IStandaloneCalculation, ICalculation
    {
        private readonly ISharedCollection shared;

        public AlimonyShareCalculation(ISharedCollection shared)
        {
            this.shared = shared;
        }

        //Added just to test AlimonyTotalCalculation
        public async Task CalculateAsync(CalculationCollection values) =>
            shared.Collection.TryAdd(Keys.AlimonyShare, 1000);
    }
}
