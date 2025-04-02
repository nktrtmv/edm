using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;

internal static class GetCounterQueryBffConverter
{
    public static GetCounterQueryExternal ToExternal(GetCounterQueryBff request)
    {
        var result = new GetCounterQueryExternal(request.DomainId, request.Id);

        return result;
    }
}
