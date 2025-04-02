using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.Markers;
using Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Options;
using
    Edm.DocumentGenerators.Domain.Entities.Documents.ValueObjects.ApplicationEvents.Inheritors.EntitiesApprovalWorkflows.Requests.CreateWorkflow.ValueObjects.Parameters;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.CreateWorkflow;

public sealed class CreateWorkflowEntitiesApprovalWorkflowsRequestExternal : EntitiesApprovalWorkflowsRequestExternal
{
    public CreateWorkflowEntitiesApprovalWorkflowsRequestExternal(
        Document document,
        DocumentApprovalParameters parameters,
        DocumentApprovalOptions options,
        Id<User> currentUserId,
        Bytes<DocumentApprovalRoute> findRouteResponse) : base(document)
    {
        Parameters = parameters;
        Options = options;
        CurrentUserId = currentUserId;
        FindRouteResponse = findRouteResponse;
    }

    public DocumentApprovalParameters Parameters { get; }
    public DocumentApprovalOptions Options { get; }
    public Id<User> CurrentUserId { get; }
    public Bytes<DocumentApprovalRoute> FindRouteResponse { get; private set; }
}
