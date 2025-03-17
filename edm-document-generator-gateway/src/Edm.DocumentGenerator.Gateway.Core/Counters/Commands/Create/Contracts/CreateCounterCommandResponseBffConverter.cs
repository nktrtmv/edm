using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Create;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create.Contracts;

internal static class CreateCounterCommandResponseBffConverter
{
    public static CreateCounterCommandResponseBff FromExternal(CreateCounterCommandResponseExternal response)
    {
        var result = new CreateCounterCommandResponseBff
        {
            Id = response.Id
        };

        return result;
    }
}
