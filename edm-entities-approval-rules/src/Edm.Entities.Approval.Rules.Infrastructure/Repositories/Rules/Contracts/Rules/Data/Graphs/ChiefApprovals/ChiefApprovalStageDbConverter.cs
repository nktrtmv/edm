using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals.Factories;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.ChiefApprovals;

internal static class ChiefApprovalStageDbConverter
{
    internal static ChiefApprovalStageDb FromDomain(ChiefApprovalStage chiefApproval)
    {
        bool isRequired = chiefApproval.IsRequired;

        EntityConditionDb condition = EntityConditionDbConverter.FromDomain(chiefApproval.Condition);

        var result = new ChiefApprovalStageDb
        {
            IsRequired = isRequired,
            Condition = condition
        };

        return result;
    }

    internal static ChiefApprovalStage ToDomain(ChiefApprovalStageDb chiefApproval)
    {
        bool isRequired = chiefApproval.IsRequired;

        EntityCondition condition = EntityConditionDbConverter.ToDomain(chiefApproval.Condition);

        ChiefApprovalStage result = ChiefApprovalStageFactory.CreateFrom(isRequired, condition);

        return result;
    }
}
