using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Commands.Create.Contracts;

public sealed class CreateApprovalGraphsCommandInternal : IRequest<CreateApprovalGraphsCommandResponseInternal>
{
    public CreateApprovalGraphsCommandInternal(ApprovalRuleKeyInternal approvalRuleKey, string displayName, Id<UserInternal> currentUserId)
    {
        ApprovalRuleKey = approvalRuleKey;
        DisplayName = displayName;
        CurrentUserId = currentUserId;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal string DisplayName { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
