using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;

public sealed class ApprovalGraphEndNode : ApprovalGraphNode
{
    internal ApprovalGraphEndNode(Id<ApprovalGraphNode> id) : base(id)
    {
    }
}
