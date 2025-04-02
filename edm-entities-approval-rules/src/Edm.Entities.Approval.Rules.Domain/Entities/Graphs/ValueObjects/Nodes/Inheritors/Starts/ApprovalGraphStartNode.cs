using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;

public sealed class ApprovalGraphStartNode : ApprovalGraphNode
{
    internal ApprovalGraphStartNode(Id<ApprovalGraphNode> id) : base(id)
    {
    }
}
