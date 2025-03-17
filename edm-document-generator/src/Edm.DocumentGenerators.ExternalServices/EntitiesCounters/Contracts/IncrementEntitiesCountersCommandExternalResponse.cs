using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;

public sealed class IncrementEntitiesCountersCommandExternalResponse
{
    public IncrementEntitiesCountersCommandExternalResponse(CounterValue[] countersValues)
    {
        CountersValues = countersValues;
    }

    public CounterValue[] CountersValues { get; }
}
