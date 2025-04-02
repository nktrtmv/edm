using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter.Contracts.Commands.Update;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update.Contracts;

internal static class UpdateCounterCommandResponseBffConverter
{
    public static UpdateCounterCommandResponseBff FromExternal(UpdateCounterCommandResponseExternal response)
    {
        var result = new UpdateCounterCommandResponseBff
        {
            Id = response.Id
        };

        return result;
    }
}
