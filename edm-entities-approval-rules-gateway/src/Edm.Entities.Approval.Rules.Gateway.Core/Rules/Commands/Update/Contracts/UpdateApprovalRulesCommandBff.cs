using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Rules.Keys;
using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Actions;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;

public sealed class UpdateApprovalRulesCommandBff
{
    public required ApprovalRuleKeyBff[] Keys { get; init; }
    public required UpdateApprovalRulesCommandActionBff Action { get; init; }
    public required bool IsDryRun { get; init; }
    public required bool IsActivationRequired { get; init; }
    public string? Comment { get; init; }
}
