using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Create;

internal static class CreateCounterCommandExternalConverter
{
    public static CreateEntityCounterQuery ToDto(CreateCounterCommandExternal command)
    {
        var result = new CreateEntityCounterQuery
        {
            DomainId = command.DomainId,
            EntityTypeId = command.EntityTypeId,
            Name = command.Name,
            Value = command.Value
        };

        return result;
    }
}
