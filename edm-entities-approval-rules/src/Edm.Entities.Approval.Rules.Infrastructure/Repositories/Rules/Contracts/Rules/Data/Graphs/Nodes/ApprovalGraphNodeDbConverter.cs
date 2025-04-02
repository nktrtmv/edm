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
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes;

internal static class ApprovalGraphNodeDbConverter
{
    internal static ApprovalGraphNodeDb FromDomain(ApprovalGraphNode node)
    {
        ApprovalGraphNodeDb result = node switch
        {
            ApprovalGraphEndNode =>
                new ApprovalGraphNodeDb { AsEnd = new ApprovalGraphEndNodeDb() },

            ApprovalGraphStageNode n =>
                new ApprovalGraphNodeDb { AsStage = ApprovalGraphStageNodeDbConverter.FromDomain(n) },

            ApprovalGraphStartNode =>
                new ApprovalGraphNodeDb { AsStart = new ApprovalGraphStartNodeDb() },

            ApprovalGraphTransitNode =>
                new ApprovalGraphNodeDb { AsTransit = new ApprovalGraphTransitNodeDb() },

            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        var id = IdConverterTo.ToString(node.Id);

        result.Id = id;

        return result;
    }

    internal static ApprovalGraphNode ToDomain(ApprovalGraphNodeDb node)
    {
        if (string.IsNullOrEmpty(node.Id))
        {
            return ToDomainObsolete(node);
        }

        Id<ApprovalGraphNode> id = IdConverterFrom<ApprovalGraphNode>.FromString(node.Id);

        ApprovalGraphNode result = node.ValueCase switch
        {
            ApprovalGraphNodeDb.ValueOneofCase.AsEnd => ApprovalGraphEndNodeFactory.CreateFrom(id),
            ApprovalGraphNodeDb.ValueOneofCase.AsStage => ApprovalGraphStageNodeDbConverter.ToDomain(id, node.AsStage),
            ApprovalGraphNodeDb.ValueOneofCase.AsStart => ApprovalGraphStartNodeFactory.CreateFrom(id),
            ApprovalGraphNodeDb.ValueOneofCase.AsTransit => ApprovalGraphTransitNodeFactory.CreateFrom(id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }

    private static ApprovalGraphNode ToDomainObsolete(ApprovalGraphNodeDb node)
    {
        Id<ApprovalGraphNode> id = IdConverterFrom<ApprovalGraphNode>.FromString(node.Data.Id);

        ApprovalGraphNode result = node.ValueCase switch
        {
            ApprovalGraphNodeDb.ValueOneofCase.AsEnd => ApprovalGraphEndNodeFactory.CreateFrom(id),
            ApprovalGraphNodeDb.ValueOneofCase.AsStage => ToDomainStageNodeObsolete(id, node),
            ApprovalGraphNodeDb.ValueOneofCase.AsStart => ApprovalGraphStartNodeFactory.CreateFrom(id),
            ApprovalGraphNodeDb.ValueOneofCase.AsTransit => ApprovalGraphTransitNodeFactory.CreateFrom(id),
            _ => throw new ArgumentTypeOutOfRangeException(node)
        };

        return result;
    }

    private static ApprovalGraphNode ToDomainStageNodeObsolete(Id<ApprovalGraphNode> id, ApprovalGraphNodeDb node)
    {
        ApprovalGraphStageSetDb[] sets = node.AsStage.Sets.ToArray();

        var stageNode = new ApprovalGraphStageNodeDb
        {
            DisplayName = node.Data.DisplayName,
            Type = node.AsStage.Type,
            Sets = { sets }
        };

        ApprovalGraphNode result = ApprovalGraphStageNodeDbConverter.ToDomain(id, stageNode);

        return result;
    }
}
