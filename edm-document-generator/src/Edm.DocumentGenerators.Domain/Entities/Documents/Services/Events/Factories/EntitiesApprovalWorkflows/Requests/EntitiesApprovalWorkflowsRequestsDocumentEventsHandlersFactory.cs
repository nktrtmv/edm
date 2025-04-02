using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesApprovalWorkflows.Requests.
    UpdateDocumentAuthor;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesApprovalWorkflows.Requests.UpdateOwners;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.EntitiesApprovalWorkflows.Requests;

internal static class EntitiesApprovalWorkflowsRequestsDocumentEventsHandlersFactory
{
    private static readonly EventsHandler[] Handlers =
    {
        new UpdateOwnersEntitiesApprovalWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler(),
        new UpdateDocumentAuthorEntitiesApprovalWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler()
    };

    internal static EventsHandler[] Create()
    {
        return Handlers;
    }
}
