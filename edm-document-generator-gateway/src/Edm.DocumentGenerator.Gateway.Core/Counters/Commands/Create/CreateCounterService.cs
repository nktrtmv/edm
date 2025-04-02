using Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesCounter;

namespace Edm.DocumentGenerator.Gateway.Core.Counters.Commands.Create;

public sealed class CreateCounterService(IDocumentCountersClient documentCountersClient)
{
    public async Task<CreateCounterCommandResponseBff> Create(CreateCounterCommandBff request, CancellationToken cancellationToken)
    {
        var command = CreateCounterCommandBffConverter.ToExternal(request);

        var response = await documentCountersClient.Create(command, cancellationToken);

        var result = CreateCounterCommandResponseBffConverter.FromExternal(response);

        return result;
    }
}
