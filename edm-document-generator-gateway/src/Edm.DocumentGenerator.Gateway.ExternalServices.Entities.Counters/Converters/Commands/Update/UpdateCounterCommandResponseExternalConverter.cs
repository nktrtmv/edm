using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Update;

internal static class UpdateCounterCommandResponseExternalConverter
{
    public static UpdateCounterCommandResponseExternal FromDto(UpdateEntityCounterQueryResponse response)
    {
        var counterId = Guid.Parse(response.Id);

        var result = new UpdateCounterCommandResponseExternal(counterId);

        return result;
    }
}
