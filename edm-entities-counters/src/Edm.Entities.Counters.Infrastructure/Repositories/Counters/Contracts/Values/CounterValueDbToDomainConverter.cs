using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values;
using Edm.Entities.Counters.Domain.Entities.Counters.ValueObjects.Values.Factories;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts.Values;

internal static class CounterValueDbToDomainConverter
{
    internal static CounterValue ToDomain(CounterValueDb counterValue)
    {
        Id<Counter> id = IdConverterFrom<Counter>.FromString(counterValue.Id);

        CounterValue result = CounterValueFactory.CreateFromDb(id, counterValue.Value);

        return result;
    }
}
