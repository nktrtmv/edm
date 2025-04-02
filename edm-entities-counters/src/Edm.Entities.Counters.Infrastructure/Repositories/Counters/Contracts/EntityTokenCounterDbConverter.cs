using Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts.Values;

namespace Edm.Entities.Counters.Infrastructure.Repositories.Counters.Contracts;

internal static class EntityTokenCounterDbConverter
{
    public static EntityTokenCounterDb FromCounterValueDb(CounterValueDb counterValue, string entityToken)
    {
        var result = new EntityTokenCounterDb(counterValue.Id, entityToken, counterValue.Value);

        return result;
    }

    public static CounterValueDb ToCounterValueDb(EntityTokenCounterDb entityTokenCounterDb)
    {
        var result = new CounterValueDb
        {
            Id = entityTokenCounterDb.CounterId,
            Value = entityTokenCounterDb.Value
        };

        return result;
    }
}
