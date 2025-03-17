using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends.Factories;

public static class ApprovalGraphEndNodeFactory
{
    public static ApprovalGraphNode CreateNew()
    {
        var id = Id<ApprovalGraphNode>.CreateNew();

        ApprovalGraphNode result = CreateFrom(id);

        return result;
    }

    public static ApprovalGraphNode CreateFrom(Id<ApprovalGraphNode> id)
    {
        var result = new ApprovalGraphEndNode(id);

        return result;
    }
}
