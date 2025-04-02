using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesSigningWorkflows.Requests.UpdateExecutor;
using Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Handlers.Inheritors.DocumentAttributeValueChanged.EntitiesSigningWorkflows.Requests.
    UpdateResponsibleManagers;
using Edm.DocumentGenerators.GenericSubdomain.Domain.Events.Handlers;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.Services.Events.Factories.EntitiesSigningWorkflows.Requests;

internal static class EntitiesSigningWorkflowsRequestsDocumentEventsHandlersFactory
{
    private static readonly EventsHandler[] Handlers =
    {
        new UpdateExecutorEntitiesSigningWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler(),
        new UpdateUpdateResponsibleManagerEntitiesSigningWorkflowsRequestDocumentAttributeValueChangedDocumentEventsHandler()
    };

    internal static EventsHandler[] Create()
    {
        return Handlers;
    }
}
