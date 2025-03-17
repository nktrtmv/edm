using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts;
using Edm.DocumentGenerators.Infrastructure.Abstractions.Producers.DocumentGeneratorEvents.Events.Contracts.Inheritors.DocumentChanged;

namespace Edm.DocumentGenerators.Application.Documents.Services.ApplicationEvents.Processors.DocumentGenerator.Events.Convertors.DocumentChanged;

internal static class DocumentChangedDocumentGeneratorEventConverter
{
    internal static DocumentGeneratorEvent FromDomain(Document document, DocumentChangedDocumentGeneratorEventDocumentApplicationEvent applicationEvent)
    {
        var result = new DocumentChangedDocumentGeneratorEvent(document.DomainId, document.Id);

        return result;
    }
}
