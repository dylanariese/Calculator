using Calculator.Models;
using Calculator.Models.Interfaces;
using Calculator.Models.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calculator.Core.Runner
{
    public class CalculationRunner : IRunner
    {
        private readonly ISharedCollection shared;
        private readonly IEnumerable<ICalculation> standalones;
        private readonly IEnumerable<ICalculation> dependants;

        public CalculationRunner(ISharedCollection shared, IEnumerable<ICalculation> calculators)
        {
            this.shared = shared;

            standalones = calculators.Where(x => x.GetType().GetInterface(nameof(IStandaloneCalculation)) != null);
            dependants = calculators.Where(x => x.GetType().GetInterface(nameof(IDependantCalculation)) != null);
        }

        public async Task<Dictionary<string, decimal>> RunAsync(CalculationCollection values)
        {
            await Task.WhenAll(standalones.Select(calculation => calculation.CalculateAsync(values)));
            await Task.WhenAll(dependants.Select(calculation => DependantHandler(calculation, values)));

            return shared.Collection.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private Task DependantHandler(ICalculation calculation, CalculationCollection values)
        {
            var done = false;
            var dependant = calculation as IDependantCalculation;

            while (!done)
            {
                done = dependant.Predicate(values);                
            }

            return dependant.CalculateAsync(values);
        }
    }
}