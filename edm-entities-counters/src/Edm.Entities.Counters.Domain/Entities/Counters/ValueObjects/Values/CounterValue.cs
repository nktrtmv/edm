using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;

public sealed class CounterValue
{
    internal CounterValue(Id<Counter> id, int value)
    {
        Id = id;
        Value = value;
    }

    public Id<Counter> Id { get; }
    public int Value { get; }
}
