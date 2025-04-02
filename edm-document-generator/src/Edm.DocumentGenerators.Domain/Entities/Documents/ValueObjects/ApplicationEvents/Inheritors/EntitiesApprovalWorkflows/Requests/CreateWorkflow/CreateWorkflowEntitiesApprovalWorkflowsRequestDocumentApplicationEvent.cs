using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow;

public sealed record CreateWorkflowEntitiesApprovalWorkflowsRequestDocumentApplicationEvent(
    DocumentApprovalParameters Parameters,
    DocumentApprovalOptions Options,
    Id<User> CurrentUserId,
    Bytes<DocumentApprovalRoute>? FindRouteResponse = null)
    : EntitiesApprovalWorkflowsRequestDocumentApplicationEvent
{
    public Bytes<DocumentApprovalRoute>? FindRouteResponse { get; private set; } = FindRouteResponse;

    public void SetFindRouteResponse(Bytes<DocumentApprovalRoute> findRouteResponse)
    {
        FindRouteResponse = findRouteResponse;
    }
}
