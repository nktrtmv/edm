using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Counters.Commands.Increment.Validators;

internal static class DistinctCountersValidator
{
    internal static void Validate(Id<CounterInternal>[] countersIds)
    {
        Id<CounterInternal>[] duplicates = countersIds
            .GroupBy(c => c)
            .Where(c => c.Count() > 1)
            .Select(c => c.Key)
            .ToArray();

        if (duplicates.Any())
        {
            string duplicatedIdsList = string.Join(", ", duplicates);

            throw new ArgumentException($"Duplicated counters ids found: {duplicatedIdsList}.");
        }
    }
}
