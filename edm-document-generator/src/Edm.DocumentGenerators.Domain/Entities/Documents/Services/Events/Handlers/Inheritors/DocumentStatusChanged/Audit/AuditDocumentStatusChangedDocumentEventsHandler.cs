using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.Audit;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.Statuses.StatusChanged;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.Audit;

public sealed class AuditDocumentStatusChangedDocumentEventsHandler : AuditDocumentEventsHandler<DocumentStatusChangedEventArgs>
{
}
