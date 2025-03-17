using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Create;

internal static class CreateCounterQueryInternalConverter
{
    internal static CreateCounterQueryInternal FromDto(CreateEntityCounterQuery query)
    {
        Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.FromString(query.DomainId);

        Id<EntityTypeInternal>? entityTypeId = IdConverterFrom<EntityTypeInternal>.FromString(query.EntityTypeId);

        var result = new CreateCounterQueryInternal(domainId, entityTypeId, query.Name, query.Value);

        return result;
    }
}
