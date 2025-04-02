using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values.Factories;

public static class CounterValueFactory
{
    public static CounterValue CreateFrom(Id<Counter> id, int value)
    {
        var result = new CounterValue(id, value);

        return result;
    }
}
