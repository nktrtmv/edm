using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;

public sealed class ChiefApprovalStage
{
    internal ChiefApprovalStage(bool isRequired, EntityCondition condition)
    {
        IsRequired = isRequired;
        Condition = condition;
    }

    public bool IsRequired { get; }
    public EntityCondition Condition { get; }
}
