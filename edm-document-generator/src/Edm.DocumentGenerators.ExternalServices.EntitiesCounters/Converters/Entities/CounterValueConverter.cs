using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values.Factories;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Converters.Entities;

internal static class CounterValueConverter
{
    internal static CounterValue FromDto(EntityCounterValueDto counterValueDto)
    {
        Id<Counter> id = IdConverterFrom<Counter>.FromString(counterValueDto.Id);

        CounterValue result = CounterValueFactory.CreateFrom(id, counterValueDto.Value);

        return result;
    }
}
