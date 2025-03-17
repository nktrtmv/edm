using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.
    Arguments;

public abstract class ForeignApprovalGroupArgumentInternal
{
    protected ForeignApprovalGroupArgumentInternal(Id<ForeignApprovalGroupArgumentInternal> id)
    {
        Id = id;
    }

    public Id<ForeignApprovalGroupArgumentInternal> Id { get; }
}
