using Edm.Entities.Approval.Rules.Application.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Actions;
using Edm.Entities.Approval.Rules.Application.Markers;
using Edm.Entities.Approval.Rules.GenericSubdomain;

using MediatR;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;

public sealed class UpdateApprovalRulesCommandInternal : IRequest<UpdateApprovalRulesCommandResponseInternal>
{
    public UpdateApprovalRulesCommandInternal(
        ApprovalRuleKeyInternal[] keys,
        UpdateApprovalRulesCommandActionInternal action,
        bool isDryRun,
        bool isActivationRequired,
        string? comment,
        Id<UserInternal> currentUserId)
    {
        Keys = keys;
        Action = action;
        IsDryRun = isDryRun;
        IsActivationRequired = isActivationRequired;
        Comment = comment;
        CurrentUserId = currentUserId;
    }

    internal ApprovalRuleKeyInternal[] Keys { get; }
    internal UpdateApprovalRulesCommandActionInternal Action { get; }
    internal bool IsDryRun { get; }
    internal bool IsActivationRequired { get; }
    internal string? Comment { get; }
    internal Id<UserInternal> CurrentUserId { get; }
}
