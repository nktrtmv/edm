using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Contracts.Counters.Contracts;

internal static class CounterValueInternalConverter
{
    internal static CounterValueInternal FromDomain(CounterValue counterValue)
    {
        Id<CounterInternal> id = IdConverterFrom<CounterInternal>.From(counterValue.Id);
        int value = counterValue.Value;

        var result = new CounterValueInternal(id, value);

        return result;
    }
}
