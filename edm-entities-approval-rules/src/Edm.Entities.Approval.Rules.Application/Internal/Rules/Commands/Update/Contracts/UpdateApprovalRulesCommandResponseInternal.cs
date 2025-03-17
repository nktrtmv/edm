using Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts.Rules;

namespace Edm.Entities.Approval.Rules.Application.Internal.Rules.Commands.Update.Contracts;

public sealed class UpdateApprovalRulesCommandResponseInternal
{
    internal UpdateApprovalRulesCommandResponseInternal(UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal[] failedDuringUpdateApprovalRules)
    {
        FailedDuringUpdateApprovalRules = failedDuringUpdateApprovalRules;
    }

    public UpdateApprovalRulesCommandResponseFailedDuringUpdateApprovalRuleInternal[] FailedDuringUpdateApprovalRules { get; }
}
