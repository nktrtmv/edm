using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Inheritors.Boolean;

public sealed class BooleanForeignApprovalGroupArgument : ForeignApprovalGroupArgumentGeneric<bool>
{
    public BooleanForeignApprovalGroupArgument(Id<ForeignApprovalGroupArgument> id, bool[] value) : base(id, value)
    {
    }
}
