using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.Domain.Entities.Counters;
using Edm.Entities.Counters.GenericSubdomain;

namespace Edm.Entities.Counters.Application.Contracts.Counters;

internal static class CounterInternalConverter
{
    internal static CounterInternal FromDomain(Counter counter)
    {
        Id<CounterInternal> id = IdConverterFrom<CounterInternal>.From(counter.Id);
        Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.From(counter.DomainId);
        Id<EntityTypeInternal>? entityTypeId = NullableConverter.Convert(counter.EntityTypeId, IdConverterFrom<EntityTypeInternal>.From);

        var result = new CounterInternal(id, domainId, entityTypeId, counter.Name, counter.Value);

        return result;
    }
}
