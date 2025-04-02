using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Update;

public sealed class UpdateCounterService(IDocumentCountersClient documentCounterClient)
{
    public async Task<UpdateCounterCommandResponseBff> Update(UpdateCounterCommandBff request, CancellationToken cancellationToken)
    {
        var command = UpdateCounterCommandBffConverter.ToExternal(request);

        var response = await documentCounterClient.Update(command, cancellationToken);

        var result = UpdateCounterCommandResponseBffConverter.FromExternal(response);

        return result;
    }
}
