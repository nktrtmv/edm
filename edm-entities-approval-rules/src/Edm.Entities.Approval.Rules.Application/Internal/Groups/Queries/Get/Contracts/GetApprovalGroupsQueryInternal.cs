using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Queries.Get.Contracts;

public sealed class GetApprovalGroupsQueryInternal : IRequest<GetApprovalGroupsQueryResponseInternal>
{
    public GetApprovalGroupsQueryInternal(ApprovalRuleKeyInternal approvalRuleKey, Id<ApprovalGroupInternal> groupId)
    {
        ApprovalRuleKey = approvalRuleKey;
        GroupId = groupId;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal Id<ApprovalGroupInternal> GroupId { get; }
}
