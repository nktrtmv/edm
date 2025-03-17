using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;

internal static class CreateApprovalGroupsCommandResponseInternalConverter
{
    internal static CreateApprovalGroupsCommandResponseInternal FromDomain(ApprovalGroup group)
    {
        Id<ApprovalGroupInternal> groupId = IdConverterFrom<ApprovalGroupInternal>.From(group.Id);

        var result = new CreateApprovalGroupsCommandResponseInternal(groupId);

        return result;
    }
}
