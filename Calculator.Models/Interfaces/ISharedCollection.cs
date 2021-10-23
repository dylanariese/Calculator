using System.Collections.Concurrent;

namespace Calculator.Models.Interfaces
{
    public interface ISharedCollection
    {
        ConcurrentDictionary<string, decimal> Collection { get; }
    }
}