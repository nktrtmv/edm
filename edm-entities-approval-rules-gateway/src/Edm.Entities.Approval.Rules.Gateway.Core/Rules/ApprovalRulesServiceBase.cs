using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Rules;

public abstract class ApprovalRulesServiceBase
{
    protected ApprovalRulesServiceBase(ApprovalRulesService.ApprovalRulesServiceClient rules)
    {
        Rules = rules;
    }

    protected ApprovalRulesService.ApprovalRulesServiceClient Rules { get; }
}
