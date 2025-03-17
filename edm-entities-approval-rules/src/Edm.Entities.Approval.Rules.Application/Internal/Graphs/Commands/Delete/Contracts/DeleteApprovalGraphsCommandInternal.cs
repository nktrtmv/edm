using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Delete.Contracts;

public sealed class DeleteApprovalGraphsCommandInternal : IRequest
{
    public DeleteApprovalGraphsCommandInternal(
        ApprovalRuleKeyInternal approvalRuleKey,
        Id<ApprovalGraphInternal> graphId,
        Id<UserInternal> currentUserId,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken)
    {
        ApprovalRuleKey = approvalRuleKey;
        GraphId = graphId;
        CurrentUserId = currentUserId;
        ConcurrencyToken = concurrencyToken;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal Id<ApprovalGraphInternal> GraphId { get; }
    internal Id<UserInternal> CurrentUserId { get; }
    internal ConcurrencyToken<ApprovalRuleInternal> ConcurrencyToken { get; }
}
