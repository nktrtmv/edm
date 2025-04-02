using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.CreateNewVersion.Contracts;

public sealed class CreateNewVersionApprovalRulesCommandInternal : IRequest<CreateNewVersionApprovalRulesCommandResponseInternal>
{
    public CreateNewVersionApprovalRulesCommandInternal(ApprovalRuleKeyInternal originalApprovalRuleKey, Id<UserInternal> currentUserId)
    {
        OriginalApprovalRuleKey = originalApprovalRuleKey;
        CurrentUserId = currentUserId;
    }

    internal ApprovalRuleKeyInternal OriginalApprovalRuleKey { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
