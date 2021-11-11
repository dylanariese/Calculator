using Calculator.Models.Models;
using System.Threading.Tasks;

namespace Calculator.Models.Interfaces
{
    public interface IDependentCalculation
    {
        Task CalculateAsync(CalculationCollection values);
        bool Predicate(CalculationCollection values);
    }
}