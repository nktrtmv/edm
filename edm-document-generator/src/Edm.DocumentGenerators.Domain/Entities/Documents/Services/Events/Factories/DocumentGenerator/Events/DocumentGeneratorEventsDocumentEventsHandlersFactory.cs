using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributesValuesChanged.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.DocumentGenerator.Events.DocumentChanged;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.DocumentGenerator.Events;

internal static class DocumentGeneratorEventsDocumentEventsHandlersFactory
{
    private static readonly EventsHandler[] Handlers =
    {
        new DocumentChangedDocumentGeneratorEventDocumentAttributesValuesChangedDocumentEventsHandler(),
        new DocumentChangedDocumentGeneratorEventDocumentStatusChangedDocumentEventsHandler()
    };

    internal static EventsHandler[] Create()
    {
        return Handlers;
    }
}
