using Edm.DocumentGenerators.Domain;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts.Inheritors.DocumentChanged;
using Edm.DocumentGenerators.Presentation.Abstractions;

namespace Edm.DocumentGenerators.Presentation.Publisher.DocumentGenerator.Events.Converters.Values.DocumentChanged;

internal static class DocumentChangedDocumentGeneratorEventConverter
{
    internal static DocumentGeneratorEventsValue FromDomain(DocumentChangedDocumentGeneratorEvent @event)
    {
        var documentId = IdConverterTo.ToString(@event.DocumentId);
        string? domainId = DomainIdHelper.GetDomainIdOrSetDefault(@event.DomainId.Value);
        var asDocumentChanged = new DocumentChangedDocumentGeneratorEventDto
        {
            DocumentId = documentId,
            DomainId = domainId
        };

        var result = new DocumentGeneratorEventsValue
        {
            AsDocumentChanged = asDocumentChanged
        };

        return result;
    }
}
