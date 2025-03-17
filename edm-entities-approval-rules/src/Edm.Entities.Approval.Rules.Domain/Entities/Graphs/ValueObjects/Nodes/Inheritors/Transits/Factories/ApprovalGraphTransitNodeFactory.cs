using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits.Factories;

public static class ApprovalGraphTransitNodeFactory
{
    public static ApprovalGraphNode CreateNew()
    {
        var id = Id<ApprovalGraphNode>.CreateNew();

        ApprovalGraphNode result = CreateFrom(id);

        return result;
    }

    public static ApprovalGraphNode CreateFrom(Id<ApprovalGraphNode> id)
    {
        var result = new ApprovalGraphTransitNode(id);

        return result;
    }
}
