using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.Factories;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Types;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages.Types;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages;

internal static class ApprovalGraphStageNodeDbConverter
{
    internal static ApprovalGraphStageNodeDb FromDomain(ApprovalGraphStageNode node)
    {
        ApprovalGraphStageTypeDb type =
            ApprovalGraphStageTypeDbConverter.FromDomain(node.Type);

        ApprovalGraphStageSetDb[] sets =
            node.Sets.Select(ApprovalGraphStageSetDbConverter.FromDomain).ToArray();

        var result = new ApprovalGraphStageNodeDb
        {
            DisplayName = node.DisplayName,
            Label = node.Label,
            Type = type,
            Sets = { sets }
        };

        return result;
    }

    internal static ApprovalGraphNode ToDomain(Id<ApprovalGraphNode> id, ApprovalGraphStageNodeDb node)
    {
        ApprovalGraphStageType type =
            ApprovalGraphStageTypeDbConverter.ToDomain(node.Type);

        ApprovalGraphStageSet[] sets =
            node.Sets.Select(ApprovalGraphStageSetDbConverter.ToDomain).ToArray();

        ApprovalGraphNode result = ApprovalGraphStageNodeFactory.CreateFrom(id, node.DisplayName, node.Label, type, sets);

        return result;
    }
}
