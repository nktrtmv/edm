using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;

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
