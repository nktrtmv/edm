using Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get;

public sealed class GetCounterService(IDocumentCountersClient documentCountersClient)
{
    public async Task<GetCounterQueryResponseBff> Get(GetCounterQueryBff request, CancellationToken cancellationToken)
    {
        var query = GetCounterQueryBffConverter.ToExternal(request);

        var response = await documentCountersClient.Get(query, cancellationToken);

        var result = GetCounterQueryResponseBffConverter.FromExternal(response);

        return result;
    }
}
