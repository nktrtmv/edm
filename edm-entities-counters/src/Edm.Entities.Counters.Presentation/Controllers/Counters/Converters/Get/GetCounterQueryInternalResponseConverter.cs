using Edm.Entities.Counters.Application.Counters.Queries.Get.Contracts;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Get;

internal static class GetCounterQueryInternalResponseConverter
{
    internal static GetEntityCounterQueryResponse ToDto(GetCounterQueryInternalResponse response)
    {
        EntityCounterDto counter = EntityCounterDtoFromInternalConverter.FromInternal(response.Counter);

        var result = new GetEntityCounterQueryResponse
        {
            Counter = counter
        };

        return result;
    }
}
