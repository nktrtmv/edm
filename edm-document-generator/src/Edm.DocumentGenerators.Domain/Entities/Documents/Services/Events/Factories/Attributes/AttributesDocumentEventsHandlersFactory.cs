using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentStatusChanged.Attributes.SetCurrentUsers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.Attributes;

internal class AttributesDocumentEventsHandlersFactory
{
    private static readonly EventsHandler[] Handlers =
    {
        SetCurrentUserToAttributeDocumentStatusChangedDocumentEventsHandler.Instance
    };

    public static EventsHandler[] Create()
    {
        return Handlers;
    }
}
