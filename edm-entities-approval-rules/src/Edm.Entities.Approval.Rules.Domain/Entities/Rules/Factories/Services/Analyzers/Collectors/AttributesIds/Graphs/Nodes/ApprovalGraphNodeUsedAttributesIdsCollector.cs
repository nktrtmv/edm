using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Factories.Services.Analyzers.Collectors.AttributesIds.Graphs.Nodes;

internal static class ApprovalGraphNodeUsedAttributesIdsCollector
{
    internal static void Collect(HashSet<int> attributesIds, ApprovalGraphNode node)
    {
        _ = node switch
        {
            ApprovalGraphEndNode => default,
            ApprovalGraphStageNode n => Collect(attributesIds, n),
            ApprovalGraphStartNode => default,
            ApprovalGraphTransitNode => default,
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };
    }

    private static None Collect(HashSet<int> attributesIds, ApprovalGraphStageNode node)
    {
        foreach (ApprovalGraphStageSet set in node.Sets)
        {
            EntityConditionAttributesIdsCollector.Collect(attributesIds, set.Condition);
        }

        return default;
    }
}
