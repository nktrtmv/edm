using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributesValuesChanged.Audit;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.Audit;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.Audit;

internal static class AuditDocumentEventsHandlersFactory
{
    private static readonly EventsHandler[] Handlers =
    {
        new AuditDocumentAttributesValuesChangedDocumentEventsHandler(),
        new AuditDocumentStatusChangedDocumentEventsHandler()
    };

    internal static EventsHandler[] Create()
    {
        return Handlers;
    }
}
