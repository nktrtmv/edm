using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Update;

internal static class UpdateCounterQueryInternalConverter
{
    internal static UpdateCounterQueryInternal FromDto(UpdateEntityCounterQuery query)
    {
        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.FromString(query.Id);

        Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.FromString(query.DomainId);

        Id<EntityTypeInternal> entityTypeId = IdConverterFrom<EntityTypeInternal>.FromString(query.EntityTypeId);

        var result = new UpdateCounterQueryInternal(counterId, domainId, entityTypeId, query.Name, query.Value);

        return result;
    }
}
