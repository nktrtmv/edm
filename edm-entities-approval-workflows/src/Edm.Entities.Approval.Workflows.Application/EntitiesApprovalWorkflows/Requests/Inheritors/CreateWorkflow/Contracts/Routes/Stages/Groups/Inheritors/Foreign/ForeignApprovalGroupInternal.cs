using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Foreign.Arguments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.
    Foreign;

public sealed class ForeignApprovalGroupInternal : ApprovalGroupInternal
{
    public ForeignApprovalGroupInternal(string name, Id<ForeignApprovalGroupInternal> groupId, ForeignApprovalGroupArgumentInternal[] arguments) : base(name)
    {
        GroupId = groupId;
        Arguments = arguments;
    }

    internal Id<ForeignApprovalGroupInternal> GroupId { get; }
    internal ForeignApprovalGroupArgumentInternal[] Arguments { get; }
}
