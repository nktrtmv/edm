using Edm.Entities.Counters.Application.Counters.Queries.Update.Contracts;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Update;

internal static class UpdateCounterQueryInternalResponseConverter
{
    internal static UpdateEntityCounterQueryResponse ToDto(UpdateCounterQueryInternalResponse response)
    {
        var result = new UpdateEntityCounterQueryResponse
        {
            Id = response.Id.ToString()
        };

        return result;
    }
}
