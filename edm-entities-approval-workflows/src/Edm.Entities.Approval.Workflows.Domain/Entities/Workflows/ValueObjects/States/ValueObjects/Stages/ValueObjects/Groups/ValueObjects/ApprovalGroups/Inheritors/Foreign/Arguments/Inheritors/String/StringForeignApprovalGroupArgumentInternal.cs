using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Foreign
    .Arguments.Abstractions;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Foreign.Arguments.Inheritors.String;

public sealed class StringForeignApprovalGroupArgument : ForeignApprovalGroupArgumentGeneric<string>
{
    public StringForeignApprovalGroupArgument(Id<ForeignApprovalGroupArgument> id, string[] value) : base(id, value)
    {
    }
}
