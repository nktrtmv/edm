using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Inheritors.Date;

public sealed class DateForeignApprovalGroupArgument
    : ForeignApprovalGroupArgumentGeneric<UtcDateTime<DateForeignApprovalGroupArgument>>
{
    public DateForeignApprovalGroupArgument(
        Id<ForeignApprovalGroupArgument> id,
        UtcDateTime<DateForeignApprovalGroupArgument>[] value) : base(id, value)
    {
    }
}
