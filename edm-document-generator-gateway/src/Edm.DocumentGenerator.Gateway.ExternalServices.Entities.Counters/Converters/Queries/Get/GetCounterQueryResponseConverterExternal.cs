using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Queries.Get;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Queries.Get;

internal static class GetCounterQueryResponseConverterExternal
{
    public static GetCounterQueryResponseExternal FromDto(GetEntityCounterQueryResponse response)
    {
        var counter = CounterConverter.From(response.Counter);

        var result = new GetCounterQueryResponseExternal(counter);

        return result;
    }
}
