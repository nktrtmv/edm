using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;

internal static class ChiefApprovalStageInternalConverter
{
    internal static ChiefApprovalStageInternal FromDomain(ChiefApprovalStage chiefApproval)
    {
        EntityConditionInternal condition = EntityConditionInternalConverter.FromDomain(chiefApproval.Condition);

        var result = new ChiefApprovalStageInternal(chiefApproval.IsRequired, condition);

        return result;
    }

    internal static ChiefApprovalStage ToDomain(ChiefApprovalStageInternal chiefApproval)
    {
        EntityCondition condition = EntityConditionInternalConverter.ToDomain(chiefApproval.Condition);

        ChiefApprovalStage result = ChiefApprovalStageFactory.CreateFrom(chiefApproval.IsRequired, condition);

        return result;
    }
}
