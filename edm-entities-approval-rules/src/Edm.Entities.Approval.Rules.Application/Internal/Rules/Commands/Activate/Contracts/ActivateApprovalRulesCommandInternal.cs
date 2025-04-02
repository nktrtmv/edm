using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Activate.Contracts;

public sealed class ActivateApprovalRulesCommandInternal : IRequest
{
    public ActivateApprovalRulesCommandInternal(
        ApprovalRuleKeyInternal key,
        string comment,
        Id<UserInternal> currentUserId,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken)
    {
        Key = key;
        Comment = comment;
        CurrentUserId = currentUserId;
        ConcurrencyToken = concurrencyToken;
    }

    internal ApprovalRuleKeyInternal Key { get; }
    internal string Comment { get; }
    internal Id<UserInternal> CurrentUserId { get; }
    internal ConcurrencyToken<ApprovalRuleInternal> ConcurrencyToken { get; }
}
