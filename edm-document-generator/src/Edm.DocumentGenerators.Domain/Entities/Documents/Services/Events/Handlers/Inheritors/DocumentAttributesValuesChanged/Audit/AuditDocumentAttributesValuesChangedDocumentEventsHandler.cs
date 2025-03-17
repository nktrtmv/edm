using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Abstractions.Audit;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Triggers.AttributesValues.AttributesValuesChanged;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributesValuesChanged.
    Audit;

public sealed class AuditDocumentAttributesValuesChangedDocumentEventsHandler : AuditDocumentEventsHandler<DocumentAttributesValuesChangedEventArgs>
{
}
