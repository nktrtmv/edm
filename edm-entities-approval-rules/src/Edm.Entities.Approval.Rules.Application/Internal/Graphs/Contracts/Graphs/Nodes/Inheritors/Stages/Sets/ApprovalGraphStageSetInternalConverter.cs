using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;

internal static class ApprovalGraphStageSetInternalConverter
{
    internal static ApprovalGraphStageSetInternal FromDomain(ApprovalGraphStageSet set)
    {
        EntityConditionInternal condition = EntityConditionInternalConverter.FromDomain(set.Condition);

        Id<ApprovalGroupInternal>[] groupsIds = set.GroupsIds.Select(IdConverterFrom<ApprovalGroupInternal>.From).ToArray();

        var result = new ApprovalGraphStageSetInternal(condition, groupsIds);

        return result;
    }

    internal static ApprovalGraphStageSet ToDomain(ApprovalGraphStageSetInternal set)
    {
        EntityCondition condition = EntityConditionInternalConverter.ToDomain(set.Condition);

        Id<ApprovalGroup>[] groupsIds = set.GroupsIds.Select(IdConverterFrom<ApprovalGroup>.From).ToArray();

        var result = new ApprovalGraphStageSet(condition, groupsIds);

        return result;
    }
}
