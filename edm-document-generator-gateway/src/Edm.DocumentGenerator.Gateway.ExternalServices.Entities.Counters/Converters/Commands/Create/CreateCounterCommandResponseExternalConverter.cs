using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Create;

internal static class CreateCounterCommandResponseExternalConverter
{
    public static CreateCounterCommandResponseExternal FromDto(CreateEntityCounterQueryResponse response)
    {
        var counterId = Guid.Parse(response.Id);

        var result = new CreateCounterCommandResponseExternal(counterId);

        return result;
    }
}
