using Calculator.Models.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Calculator.Models.Interfaces
{
    public interface IRunner
    {
        Task<Dictionary<string, decimal>> RunAsync(CalculationCollection values);
    }
}