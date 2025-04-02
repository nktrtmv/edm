using System.Text.Json.Serialization;

using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes;

[JsonDerivedType(typeof(ApprovalGraphTransitNodeBff), "Transit")]
[JsonDerivedType(typeof(ApprovalGraphStartNodeBff), "Start")]
[JsonDerivedType(typeof(ApprovalGraphStageNodeBff), "Stage")]
[JsonDerivedType(typeof(ApprovalGraphEndNodeBff), "End")]
public abstract class ApprovalGraphNodeBff
{
    public required string Id { get; init; }
}
