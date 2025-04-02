using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Presentation.Abstractions.Internals;
using Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Converters.Entities.Conditions;

namespace Edm.Entities.Approval.Rules.Presentation.Controllers.Internals.Graphs.Converters.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;

internal static class ApprovalGraphStageSetInternalConverter
{
    internal static ApprovalGraphStageSetInternal FromDto(ApprovalGraphStageSetDto set)
    {
        EntityConditionInternal condition = EntityConditionInternalConverter.FromDto(set.Condition);

        Id<ApprovalGroupInternal>[] groupsIds = set.GroupsIds.Select(IdConverterFrom<ApprovalGroupInternal>.FromString).ToArray();

        var result = new ApprovalGraphStageSetInternal(condition, groupsIds);

        return result;
    }

    internal static ApprovalGraphStageSetDto ToDto(ApprovalGraphStageSetInternal set)
    {
        EntityConditionDto condition = EntityConditionInternalConverter.ToDto(set.Condition);

        string[] groupsIds = set.GroupsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new ApprovalGraphStageSetDto
        {
            Condition = condition,
            GroupsIds = { groupsIds }
        };

        return result;
    }
}
