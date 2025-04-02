using Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events.Convertors.DocumentChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.GenericSubdomain.Exceptions;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events.Convertors;

internal static class DocumentGeneratorEventsConverter
{
    internal static DocumentGeneratorEvent FromDomain(
        DocumentGeneratorEventDocumentApplicationEvent applicationEvent,
        Document document)
    {
        DocumentGeneratorEvent? result = applicationEvent switch
        {
            DocumentChangedDocumentGeneratorEventDocumentApplicationEvent e =>
                DocumentChangedDocumentGeneratorEventConverter.FromDomain(document, e),

            _ => throw new ArgumentTypeOutOfRangeException(applicationEvent)
        };

        return result;
    }
}
