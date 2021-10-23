using Calculator.Models.Interfaces;
using System.Collections.Concurrent;

namespace Calculator.Shared
{
    public class SharedCollection : ISharedCollection
    {
        public ConcurrentDictionary<string, decimal> Collection { get; } =
            new ConcurrentDictionary<string, decimal>();
    }
}