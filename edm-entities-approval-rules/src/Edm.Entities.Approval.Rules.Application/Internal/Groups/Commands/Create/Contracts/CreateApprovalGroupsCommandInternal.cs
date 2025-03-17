using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts.Kinds;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Groups.Commands.Create.Contracts;

public sealed class CreateApprovalGroupsCommandInternal : IRequest<CreateApprovalGroupsCommandResponseInternal>
{
    public CreateApprovalGroupsCommandInternal(
        ApprovalRuleKeyInternal approvalRuleKey,
        ApprovalGroupKindInternal kind,
        string displayName,
        Id<UserInternal> currentUserId)
    {
        ApprovalRuleKey = approvalRuleKey;
        Kind = kind;
        DisplayName = displayName;
        CurrentUserId = currentUserId;
    }

    internal ApprovalRuleKeyInternal ApprovalRuleKey { get; }
    internal ApprovalGroupKindInternal Kind { get; }
    internal string DisplayName { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
