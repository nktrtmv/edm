using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Queries.GetAll;

internal static class GetAllDocumentCountersQueryResponseConverter
{
    public static GetAllDocumentCountersQueryResponse FromDto(GetAllEntitiesCountersQueryResponse? response)
    {
        if (response == null)
        {
            return new GetAllDocumentCountersQueryResponse([]);
        }

        DocumentCounterExternal[] counters = response.EntitiesCounters.Select(CounterConverter.From).ToArray();

        var result = new GetAllDocumentCountersQueryResponse(counters);

        return result;
    }
}
