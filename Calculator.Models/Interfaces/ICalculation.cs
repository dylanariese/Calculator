using Calculator.Models.Models;
using System.Threading.Tasks;

namespace Calculator.Models.Interfaces
{
    public interface ICalculation
    {
        Task CalculateAsync(CalculationCollection values);
    }
}