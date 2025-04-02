using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update.Contracts;

internal static class UpdateCounterCommandBffConverter
{
    public static UpdateCounterCommandExternal ToExternal(UpdateCounterCommandBff command)
    {
        var result = new UpdateCounterCommandExternal(
            command.Id,
            command.DomainId,
            command.EntityTypeId,
            command.Name,
            command.Value);

        return result;
    }
}
