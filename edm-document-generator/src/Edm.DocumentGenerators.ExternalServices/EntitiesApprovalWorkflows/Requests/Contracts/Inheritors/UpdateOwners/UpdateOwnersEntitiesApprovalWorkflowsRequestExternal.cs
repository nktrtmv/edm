using Edm.DocumentGenerators.Domain.Entities.Documents;
using Edm.DocumentGenerators.Domain.Markers;
using Edm.DocumentGenerators.GenericSubdomain;

namespace Edm.DocumentGenerators.ExternalServices.EntitiesApprovalWorkflows.Requests.Contracts.Inheritors.UpdateOwners;

public sealed class UpdateOwnersEntitiesApprovalWorkflowsRequestExternal : EntitiesApprovalWorkflowsRequestExternal
{
    public UpdateOwnersEntitiesApprovalWorkflowsRequestExternal(Document document, Id<User> ownerId) : base(document)
    {
        OwnerId = ownerId;
    }

    public Id<User> OwnerId { get; }
}
