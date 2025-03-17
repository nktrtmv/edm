using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.DocumentGenerator.Events.
    DocumentChanged;

internal sealed class DocumentChangedDocumentGeneratorEventDocumentStatusChangedDocumentEventsHandler
    : DocumentChangedDocumentGeneratorEventDocumentEventsHandler<DocumentStatusChangedEventArgs>
{
}
