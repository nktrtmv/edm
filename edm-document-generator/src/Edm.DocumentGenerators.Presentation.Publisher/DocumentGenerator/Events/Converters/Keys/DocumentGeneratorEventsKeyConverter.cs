using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Keys;

internal static class DocumentGeneratorEventsKeyConverter
{
    internal static DocumentGeneratorEventsKey FromDomain(DocumentGeneratorEvent @event)
    {
        var documentId = IdConverterTo.ToString(@event.DocumentId);

        var result = new DocumentGeneratorEventsKey
        {
            Key = documentId
        };

        return result;
    }
}
