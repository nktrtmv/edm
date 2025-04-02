using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Edges;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Conditions;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.Edges;

internal static class ApprovalGraphEdgeUsedAttributesIdsCollector
{
    internal static void Collect(HashSet<int> attributesIds, ApprovalGraphEdge edge)
    {
        EntityConditionAttributesIdsCollector.Collect(attributesIds, edge.Condition);
    }
}
