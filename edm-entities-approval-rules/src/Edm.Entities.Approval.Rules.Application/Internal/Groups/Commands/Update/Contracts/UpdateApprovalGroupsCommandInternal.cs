using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Update.Contracts;

public sealed class UpdateApprovalGroupsCommandInternal : IRequest
{
    public UpdateApprovalGroupsCommandInternal(
        ApprovalRuleKeyInternal approvalRuleKey,
        ApprovalGroupInternal group,
        Id<UserInternal> currentUserId,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken)
    {
        ApprovalRuleKey = approvalRuleKey;
        Group = group;
        CurrentUserId = currentUserId;
        ConcurrencyToken = concurrencyToken;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal ApprovalGroupInternal Group { get; }
    internal Id<UserInternal> CurrentUserId { get; }
    internal ConcurrencyToken<ApprovalRuleInternal> ConcurrencyToken { get; }
}
