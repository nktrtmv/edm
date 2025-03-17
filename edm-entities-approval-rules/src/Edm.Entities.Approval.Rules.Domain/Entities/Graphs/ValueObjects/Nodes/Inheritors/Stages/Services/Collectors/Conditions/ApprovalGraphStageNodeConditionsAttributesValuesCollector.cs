using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Collectors.EntitiesConditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions.Inheritors.AttributesValues;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities.ValueObjects.AttributesValues;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.Services.Collectors.Conditions;

internal static class ApprovalGraphStageNodeConditionsAttributesValuesCollector
{
    internal static IEnumerable<EntityAttributeValue> Collect(ApprovalGraph graph)
    {
        ApprovalGraphStageNode[] stageNodes = graph.Nodes.OfType<ApprovalGraphStageNode>().ToArray();

        EntityCondition[] conditions = stageNodes.SelectMany(n => n.Sets).Select(s => s.Condition).ToArray();

        EntityAttributeValueCondition[] attributesValuesConditions = EntityAttributesValuesConditionsCollector.Collect(conditions).ToArray();

        EntityAttributeValue[] result = attributesValuesConditions.Select(c => c.AttributeValue).ToArray();

        return result;
    }
}
