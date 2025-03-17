using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Contracts.Counters.Contracts;

public sealed class CounterValueInternal
{
    internal CounterValueInternal(Id<CounterInternal> id, int value)
    {
        Id = id;
        Value = value;
    }

    public Id<CounterInternal> Id { get; }
    public int Value { get; }
}
