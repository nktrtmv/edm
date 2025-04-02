using Edm.Entities.Counters.Application.Counters.Queries.Create.Contracts;
using Edm.Entities.Counters.Presentation.Abstractions;

namespace Edm.Entities.Counters.Presentation.Controllers.Counters.Converters.Create;

internal static class CreateCounterQueryInternalResponseConverter
{
    internal static CreateEntityCounterQueryResponse ToDto(CreateCounterQueryInternalResponse response)
    {
        var result = new CreateEntityCounterQueryResponse
        {
            Id = response.Id.ToString()
        };

        return result;
    }
}
