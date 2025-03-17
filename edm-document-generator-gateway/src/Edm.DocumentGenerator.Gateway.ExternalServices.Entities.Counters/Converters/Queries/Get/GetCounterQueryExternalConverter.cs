using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Queries.Get;

internal static class GetCounterQueryExternalConverter
{
    public static GetEntityCounterQuery ToDto(GetCounterQueryExternal query)
    {
        var result = new GetEntityCounterQuery
        {
            Id = query.Id,
            DomainId = query.DomainId
        };

        return result;
    }
}
