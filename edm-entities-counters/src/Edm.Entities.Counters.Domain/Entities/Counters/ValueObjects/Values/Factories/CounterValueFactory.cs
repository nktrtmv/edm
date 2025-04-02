using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values.Factories;

public static class CounterValueFactory
{
    public static CounterValue CreateFromDb(Id<Counter> id, int value)
    {
        var result = new CounterValue(id, value);

        return result;
    }
}
