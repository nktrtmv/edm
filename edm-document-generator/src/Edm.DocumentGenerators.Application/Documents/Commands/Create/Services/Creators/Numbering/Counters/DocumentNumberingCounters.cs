using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Inheritors;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.Markers;
using Edm.DocumentGenerators.Domain.Entities.DocumentsTemplates.ValueObjects.Prototypes.Numbering.ValueObjects.Segments.ValueObjects.Counters.Values;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters;
using Edm.DocumentGenerators.ExternalServices.EntitiesCounters.Contracts;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Application.Documents.Commands.Create.Services.Creators.Numbering.Counters;

internal sealed class DocumentNumberingCounters : IDocumentNumberingCounters
{
    public DocumentNumberingCounters(IEntitiesCountersIncrementerClient client)
    {
        Client = client;
    }

    private IEntitiesCountersIncrementerClient Client { get; }

    public async Task<CounterValue[]> Increment(DocumentTemplate template, string? entityToken = null)
    {
        Id<Counter>[] countersIds = template.DocumentPrototype.Numbering.Segments
            .OfType<DocumentCounterNumberingSegment>()
            .Select(s => s.CounterId)
            .ToArray();

        var command = new IncrementEntitiesCountersCommandExternal(countersIds, entityToken);

        IncrementEntitiesCountersCommandExternalResponse response = await Client.Increment(command);

        CounterValue[] result = response.CountersValues;

        return result;
    }
}
