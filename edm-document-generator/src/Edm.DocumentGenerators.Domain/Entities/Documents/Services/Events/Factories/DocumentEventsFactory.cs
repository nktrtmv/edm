using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Contexts;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.Attributes;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.Audit;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.DocumentGenerator.Events;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.DocumentNotifier.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.EntitiesApprovalWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.EntitiesSigningWorkflows.Requests;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories;

internal static class DocumentEventsFactory
{
    internal static Events<DocumentEventContext> Create(Document document, Id<User> actorId, IRoleAdapter roleAdapter)
    {
        var context = new DocumentEventContext(document, actorId, roleAdapter);

        EventsHandler[]? handlers = CreateHandlers(document);

        var result = new Events<DocumentEventContext>(handlers, context);

        return result;
    }

    private static EventsHandler[] CreateHandlers(Document document)
    {
        EventsHandler[][] handlers =
        [
            AuditDocumentEventsHandlersFactory.Create(),
            AttributesDocumentEventsHandlersFactory.Create(),
            DocumentNotifierRequestsDocumentEventsHandlersFactory.Create(document),
            DocumentGeneratorEventsDocumentEventsHandlersFactory.Create(),
            EntitiesApprovalWorkflowsRequestsDocumentEventsHandlersFactory.Create(),
            EntitiesSigningWorkflowsRequestsDocumentEventsHandlersFactory.Create()
        ];

        EventsHandler[]? result = handlers.SelectMany(h => h).ToArray();

        return result;
    }
}
