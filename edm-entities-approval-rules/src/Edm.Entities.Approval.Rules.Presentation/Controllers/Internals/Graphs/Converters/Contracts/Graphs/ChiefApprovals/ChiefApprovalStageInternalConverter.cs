using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.ChiefApprovals;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.ChiefApprovals;

internal static class ChiefApprovalStageInternalConverter
{
    internal static ChiefApprovalStageDto ToDto(ChiefApprovalStageInternal chiefApproval)
    {
        EntityConditionDto condition = EntityConditionInternalConverter.ToDto(chiefApproval.Condition);

        var result = new ChiefApprovalStageDto
        {
            IsRequired = chiefApproval.IsRequired,
            Condition = condition
        };

        return result;
    }

    internal static ChiefApprovalStageInternal FromDto(ChiefApprovalStageDto chiefApproval)
    {
        EntityConditionInternal condition = EntityConditionInternalConverter.FromDto(chiefApproval.Condition);

        var result = new ChiefApprovalStageInternal(chiefApproval.IsRequired, condition);

        return result;
    }
}
