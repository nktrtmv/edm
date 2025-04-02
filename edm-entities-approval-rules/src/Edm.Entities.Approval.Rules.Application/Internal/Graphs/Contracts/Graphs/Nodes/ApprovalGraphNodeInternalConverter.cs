using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Ends.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Starts.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Transits.Factories;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.GenericSubdomain.Exceptions.Arguments;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes;

internal static class ApprovalGraphNodeInternalConverter
{
    internal static ApprovalGraphNodeInternal FromDomain(ApprovalGraphNode node)
    {
        Id<ApprovalGraphNodeInternal> id = IdConverterFrom<ApprovalGraphNodeInternal>.From(node.Id);

        ApprovalGraphNodeInternal result = node switch
        {
            ApprovalGraphEndNode => new ApprovalGraphEndNodeInternal(id),
            ApprovalGraphStageNode n => ApprovalGraphStageNodeInternalConverter.FromDomain(id, n),
            ApprovalGraphStartNode => new ApprovalGraphStartNodeInternal(id),
            ApprovalGraphTransitNode => new ApprovalGraphTransitNodeInternal(id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }

    internal static ApprovalGraphNode ToDomain(ApprovalGraphNodeInternal node)
    {
        Id<ApprovalGraphNode> id = IdConverterFrom<ApprovalGraphNode>.From(node.Id);

        ApprovalGraphNode result = node switch
        {
            ApprovalGraphEndNodeInternal => ApprovalGraphEndNodeFactory.CreateFrom(id),
            ApprovalGraphStageNodeInternal n => ApprovalGraphStageNodeInternalConverter.ToDomain(id, n),
            ApprovalGraphStartNodeInternal => ApprovalGraphStartNodeFactory.CreateFrom(id),
            ApprovalGraphTransitNodeInternal => ApprovalGraphTransitNodeFactory.CreateFrom(id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }
}
