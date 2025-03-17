using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.GetCounters;

public sealed class GetCountersService(IDocumentCountersClient documentCountersClient)
{
    public async Task<GetAllCountersQueryResponseBff> GetAll(GetAllCountersQueryBff query, CancellationToken cancellationToken)
    {
        var countersResponse = await documentCountersClient.GetAll(query.DomainId, cancellationToken);

        var countersBff = GetAllCountersQueryResponseBffConverter.ToBff(countersResponse);

        return countersBff;
    }
}
