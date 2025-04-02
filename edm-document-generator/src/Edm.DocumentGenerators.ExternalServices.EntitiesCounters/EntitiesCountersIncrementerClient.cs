using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Converters.Commands;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Converters.Entities;
using Edm.DocumentGenerators.GenericSubdomain.Tracing;
using Edm.Entities.Counters.Presentation.Abstractions;

using Microsoft.Extensions.Logging;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesCounters;

public sealed class EntitiesCountersIncrementerClient : IEntitiesCountersIncrementerClient
{
    public EntitiesCountersIncrementerClient(
        EntitiesCountersIncrementerService.EntitiesCountersIncrementerServiceClient client,
        ILogger<EntitiesCountersIncrementerClient> logger)
    {
        Logger = logger;
        Client = client;
    }

    private EntitiesCountersIncrementerService.EntitiesCountersIncrementerServiceClient Client { get; }
    private ILogger<EntitiesCountersIncrementerClient> Logger { get; }

    public async Task<IncrementEntitiesCountersCommandExternalResponse> Increment(IncrementEntitiesCountersCommandExternal externalCommand)
    {
        IncrementEntitiesCountersCommand command = IncrementEntitiesCountersCommandConverter.FromExternal(externalCommand);

        IncrementEntitiesCountersCommandResponse response = await TracingFacility.TraceGrpc(
            Logger,
            nameof(Increment),
            command,
            async () => await Client.IncrementAsync(command));

        CounterValue[] countersValues = response.EntitiesCountersValues.Select(CounterValueConverter.FromDto).ToArray();

        var result = new IncrementEntitiesCountersCommandExternalResponse(countersValues);

        return result;
    }
}
