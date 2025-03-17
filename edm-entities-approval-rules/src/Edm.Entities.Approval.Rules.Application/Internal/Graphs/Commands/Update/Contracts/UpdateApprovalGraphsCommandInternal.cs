using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Markers;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Tokens.Concurrency;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Update.Contracts;

public sealed class UpdateApprovalGraphsCommandInternal : IRequest
{
    public UpdateApprovalGraphsCommandInternal(
        ApprovalRuleKeyInternal approvalRuleKey,
        ApprovalGraphInternal graph,
        Id<UserInternal> currentUserId,
        ConcurrencyToken<ApprovalRuleInternal> concurrencyToken)
    {
        ApprovalRuleKey = approvalRuleKey;
        Graph = graph;
        CurrentUserId = currentUserId;
        ConcurrencyToken = concurrencyToken;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal ApprovalGraphInternal Graph { get; }
    internal Id<UserInternal> CurrentUserId { get; }
    internal ConcurrencyToken<ApprovalRuleInternal> ConcurrencyToken { get; }
}
