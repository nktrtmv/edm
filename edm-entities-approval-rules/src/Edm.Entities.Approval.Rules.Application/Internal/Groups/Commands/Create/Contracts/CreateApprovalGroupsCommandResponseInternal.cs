using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;

public sealed class CreateApprovalGroupsCommandResponseInternal
{
    internal CreateApprovalGroupsCommandResponseInternal(Id<ApprovalGroupInternal> groupId)
    {
        GroupId = groupId;
    }

    public Id<ApprovalGroupInternal> GroupId { get; }
}
