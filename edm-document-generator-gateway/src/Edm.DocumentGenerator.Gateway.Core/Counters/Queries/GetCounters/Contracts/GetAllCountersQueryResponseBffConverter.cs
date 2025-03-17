using Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters.Contracts;

internal static class GetAllCountersQueryResponseBffConverter
{
    public static GetAllCountersQueryResponseBff ToBff(GetAllDocumentCountersQueryResponse response)
    {
        DocumentCounterBff[] counters = response.Counters
            .Select(DocumentCounterBffConverter.ToBff)
            .ToArray();

        var result = new GetAllCountersQueryResponseBff(counters);

        return result;
    }
}
