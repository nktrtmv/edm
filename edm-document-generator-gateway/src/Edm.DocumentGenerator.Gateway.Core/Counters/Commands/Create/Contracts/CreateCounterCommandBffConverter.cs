using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create.Contracts;

internal static class CreateCounterCommandBffConverter
{
    public static CreateCounterCommandExternal ToExternal(CreateCounterCommandBff command)
    {
        var result = new CreateCounterCommandExternal(
            command.DomainId,
            command.EntityTypeId,
            command.Name,
            command.Value);

        return result;
    }
}
