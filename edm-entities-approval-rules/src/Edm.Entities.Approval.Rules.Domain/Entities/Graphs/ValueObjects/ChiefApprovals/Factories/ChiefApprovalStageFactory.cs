using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.Nones;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals.Factories;

public static class ChiefApprovalStageFactory
{
    public static ChiefApprovalStage CreateNew()
    {
        const bool isRequired = false;

        var condition = EntityNoneCondition.Instance;

        ChiefApprovalStage result = CreateFrom(isRequired, condition);

        return result;
    }

    public static ChiefApprovalStage CreateFrom(bool isRequired, EntityCondition condition)
    {
        var result = new ChiefApprovalStage(isRequired, condition);

        return result;
    }
}
