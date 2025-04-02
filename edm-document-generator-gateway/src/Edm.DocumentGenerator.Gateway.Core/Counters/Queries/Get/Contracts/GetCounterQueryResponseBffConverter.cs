using Edm.DocumentGenerator.Gateway.Core.Counters.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Queries.Get.Contracts;

internal static class GetCounterQueryResponseBffConverter
{
    public static GetCounterQueryResponseBff FromExternal(GetCounterQueryResponseExternal response)
    {
        var comment = DocumentCounterBffConverter.ToBff(response.Counter);

        var result = new GetCounterQueryResponseBff
        {
            Counter = comment
        };

        return result;
    }
}
