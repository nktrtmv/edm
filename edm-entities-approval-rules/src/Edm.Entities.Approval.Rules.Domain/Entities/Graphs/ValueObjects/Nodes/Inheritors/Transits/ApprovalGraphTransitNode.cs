using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits;

public sealed class ApprovalGraphTransitNode : ApprovalGraphNode
{
    internal ApprovalGraphTransitNode(Id<ApprovalGraphNode> id) : base(id)
    {
    }
}
