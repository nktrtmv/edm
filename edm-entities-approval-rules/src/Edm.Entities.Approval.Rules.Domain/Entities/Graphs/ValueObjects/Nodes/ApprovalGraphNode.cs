using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;

[JsonDerivedType(typeof(ApprovalGraphEndNode))]
[JsonDerivedType(typeof(ApprovalGraphStartNode))]
[JsonDerivedType(typeof(ApprovalGraphStageNode))]
[JsonDerivedType(typeof(ApprovalGraphTransitNode))]
public abstract class ApprovalGraphNode
{
    protected ApprovalGraphNode(Id<ApprovalGraphNode> id)
    {
        Id = id;
    }

    public Id<ApprovalGraphNode> Id { get; }

    protected string BaseToString()
    {
        return $"Type: {GetType().Name}, Id: {Id}";
    }

    public override string ToString()
    {
        return $"{{ {BaseToString()} }}";
    }
}
