using Calculator.Models.Models;
using System.Threading.Tasks;

namespace Calculator.Models.Interfaces
{
    public interface IDependantCalculation
    {
        Task CalculateAsync(CalculationCollection values);
        bool Predicate(CalculationCollection values);
    }
}