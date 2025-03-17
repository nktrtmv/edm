using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Conditions.Operators;

public abstract class ApprovalConditionsOperatorsServiceBase
{
    protected ApprovalConditionsOperatorsServiceBase(ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceClient operators)
    {
        Operators = operators;
    }

    protected ApprovalConditionsOperatorsService.ApprovalConditionsOperatorsServiceClient Operators { get; }
}
