using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.ChiefApprovals;

internal static class ChiefApprovalStageBffConverter
{
    internal static ChiefApprovalStageBff FromDto(ChiefApprovalStageDto chiefApproval, ApprovalEnrichersContext context)
    {
        var condition = EntityConditionBffConverter.FromDto(chiefApproval.Condition, context);

        var result = new ChiefApprovalStageBff
        {
            IsRequired = chiefApproval.IsRequired,
            Condition = condition
        };

        return result;
    }

    internal static ChiefApprovalStageDto ToDto(ChiefApprovalStageBff chiefApproval)
    {
        var condition = EntityConditionBffConverter.ToDto(chiefApproval.Condition);

        var result = new ChiefApprovalStageDto
        {
            IsRequired = chiefApproval.IsRequired,
            Condition = condition
        };

        return result;
    }
}
