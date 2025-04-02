using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters;

internal static class EntityCounterDtoFromInternalConverter
{
    internal static EntityCounterDto FromInternal(CounterInternal counter)
    {
        var id = IdConverterTo.ToString(counter.Id);
        var domainId = IdConverterTo.ToString(counter.DomainId);
        string? entityTypeId = NullableConverter.Convert(counter.EntityTypeId, IdConverterTo.ToString);

        var result = new EntityCounterDto
        {
            Id = id,
            DomainId = domainId,
            EntityTypeId = entityTypeId,
            Name = counter.Name,
            Value = counter.Value
        };

        return result;
    }
}
