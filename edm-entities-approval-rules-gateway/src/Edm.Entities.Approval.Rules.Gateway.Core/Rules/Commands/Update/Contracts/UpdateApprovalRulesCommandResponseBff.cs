using Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules.Commands.Update.Contracts;

public sealed class UpdateApprovalRulesCommandResponseBff
{
    public required UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleBff[] FailedDuringUpdateApprovalRules { get; init; }
}
