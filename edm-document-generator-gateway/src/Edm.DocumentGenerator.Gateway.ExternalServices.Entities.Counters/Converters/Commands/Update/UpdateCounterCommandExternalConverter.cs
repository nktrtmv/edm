using Edm.Entities.Counters.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Counters.Converters.Commands.Update;

internal static class UpdateCounterCommandExternalConverter
{
    public static UpdateEntityCounterQuery ToDto(UpdateCounterCommandExternal command)
    {
        var result = new UpdateEntityCounterQuery
        {
            Id = command.Id,
            DomainId = command.DomainId,
            EntityTypeId = command.EntityTypeId,
            Name = command.Name,
            Value = command.Value
        };

        return result;
    }
}
