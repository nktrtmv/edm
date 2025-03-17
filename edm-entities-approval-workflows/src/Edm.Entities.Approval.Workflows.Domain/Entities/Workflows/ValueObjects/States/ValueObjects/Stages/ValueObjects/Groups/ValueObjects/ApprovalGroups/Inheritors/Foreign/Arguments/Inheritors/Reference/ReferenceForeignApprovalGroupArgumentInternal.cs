using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Inheritors.Reference;

public sealed class ReferenceForeignApprovalGroupArgument
    : ForeignApprovalGroupArgumentGeneric<Id<ReferenceForeignApprovalGroupArgument>>
{
    public ReferenceForeignApprovalGroupArgument(
        Id<ForeignApprovalGroupArgument> id,
        Id<ReferenceForeignApprovalGroupArgument>[] value) : base(id, value)
    {
    }
}
