using Edm.Entities.Approval.Rules.Gateway.Core.Contracts.Conditions;
using Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets.Groups;
using Edm.Entities.Approval.Rules.Gateway.Core.Services.Enrichers.Contexts;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;

namespace Edm.Entities.Approval.Rules.Gateway.Core.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;

internal static class ApprovalGraphStageSetBffConverter
{
    internal static ApprovalGraphStageSetBff FromDto(ApprovalGraphStageSetDto set, ApprovalEnrichersContext context)
    {
        var condition = EntityConditionBffConverter.FromDto(set.Condition, context);

        ApprovalGraphStageGroupBff[] groups =
            set.GroupsIds.Select(i => ApprovalGraphStageGroupBffConverter.FromDto(i, context)).ToArray();

        var result = new ApprovalGraphStageSetBff
        {
            Condition = condition,
            Groups = groups
        };

        return result;
    }

    internal static ApprovalGraphStageSetDto ToDto(ApprovalGraphStageSetBff set)
    {
        var condition = EntityConditionBffConverter.ToDto(set.Condition);

        string[] groupsIds = set.Groups.Select(g => g.Id).ToArray();

        var result = new ApprovalGraphStageSetDto
        {
            Condition = condition,
            GroupsIds = { groupsIds }
        };

        return result;
    }
}
