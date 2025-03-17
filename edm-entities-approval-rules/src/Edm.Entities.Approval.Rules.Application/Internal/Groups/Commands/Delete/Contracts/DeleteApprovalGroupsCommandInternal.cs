using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Delete.Contracts;

public sealed class DeleteApprovalGroupsCommandInternal : IRequest
{
    public DeleteApprovalGroupsCommandInternal(
        ApprovalRuleKeyInternal approvalRuleKey,
        Id<ApprovalGroupInternal> groupId,
        Id<UserInternal> currentUserId,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken)
    {
        ApprovalRuleKey = approvalRuleKey;
        GroupId = groupId;
        CurrentUserId = currentUserId;
        ConcurrencyToken = concurrencyToken;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal Id<ApprovalGroupInternal> GroupId { get; }
    internal Id<UserInternal> CurrentUserId { get; }
    internal ConcurrencyToken<ApprovalRuleInternal> ConcurrencyToken { get; }
}
