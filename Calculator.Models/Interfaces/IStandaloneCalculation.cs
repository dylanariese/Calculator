using Calculator.Models.Models;
using System.Threading.Tasks;

namespace Calculator.Models.Interfaces
{
    public interface IStandaloneCalculation
    {
        Task CalculateAsync(CalculationCollection values);
    }
}