using Edm.Entities.Counters.Application.Contracts.Counters;
using Edm.Entities.Counters.Application.Contracts.Markers;
using Edm.Entities.Counters.Application.Counters.Queries.Get.Contracts;
using Edm.Entities.Counters.GenericSubdomain;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Get;

internal static class GetCounterQueryInternalConverter
{
    internal static GetCounterQueryInternal FromDto(GetEntityCounterQuery query)
    {
        Id<CounterInternal> counterId = IdConverterFrom<CounterInternal>.FromString(query.Id);

        Id<EntityDomainInternal> domainId = IdConverterFrom<EntityDomainInternal>.FromString(query.DomainId);

        var result = new GetCounterQueryInternal(domainId, counterId);

        return result;
    }
}
