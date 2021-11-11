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
        private readonly IEnumerable<ICalculation> dependents;

        public CalculationRunner(ISharedCollection shared, IEnumerable<ICalculation> calculators)
        {
            this.shared = shared;

            standalones = calculators.Where(calculator => calculator.GetType().GetInterface(nameof(IStandaloneCalculation)) != null);
            dependents = calculators.Where(calculator => calculator.GetType().GetInterface(nameof(IDependentCalculation)) != null);
        }

        public async Task<Dictionary<string, decimal>> RunAsync(CalculationCollection values)
        {
            await Task.WhenAll(standalones.Select(calculation => calculation.CalculateAsync(values)));
            await Task.WhenAll(dependents.Select(calculation => DependentHandler(calculation, values)));

            return shared.Collection.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private Task DependentHandler(ICalculation calculation, CalculationCollection values)
        {
            var done = false;
            var dependent = calculation as IDependentCalculation;

            while (!done)
            {
                done = dependent.Predicate(values);
            }

            return dependent.CalculateAsync(values);
        }
    }
}