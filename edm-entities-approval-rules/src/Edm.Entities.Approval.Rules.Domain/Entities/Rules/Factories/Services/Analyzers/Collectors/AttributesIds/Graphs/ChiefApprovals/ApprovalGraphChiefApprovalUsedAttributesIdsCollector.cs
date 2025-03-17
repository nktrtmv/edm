using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.ChiefApprovals;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Conditions;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.ChiefApprovals;

internal static class ApprovalGraphChiefApprovalUsedAttributesIdsCollector
{
    internal static void Collect(HashSet<int> attributesIds, ChiefApprovalStage chiefApproval)
    {
        EntityConditionAttributesIdsCollector.Collect(attributesIds, chiefApproval.Condition);
    }
}
