using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign;

public sealed class ApprovalWorkflowForeignApprovalGroup : ApprovalWorkflowApprovalGroup
{
    public ApprovalWorkflowForeignApprovalGroup(Id<ApprovalWorkflowForeignApprovalGroup> groupId, ForeignApprovalGroupArgument[] arguments)
    {
        GroupId = groupId;
        Arguments = arguments;
    }

    public Id<ApprovalWorkflowForeignApprovalGroup> GroupId { get; }
    public ForeignApprovalGroupArgument[] Arguments { get; }

    public override string ToString()
    {
        string arguments = string.Join<ForeignApprovalGroupArgument>(", ", Arguments);

        return $"{{ {BaseToString()}, GroupId: {GroupId}, Arguments: [{arguments}] }}";
    }
}
