using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Inheritors.Number;

public sealed class NumberForeignApprovalGroupArgument : ForeignApprovalGroupArgumentGeneric<long>
{
    public NumberForeignApprovalGroupArgument(Id<ForeignApprovalGroupArgument> id, long[] value) : base(id, value)
    {
    }
}
