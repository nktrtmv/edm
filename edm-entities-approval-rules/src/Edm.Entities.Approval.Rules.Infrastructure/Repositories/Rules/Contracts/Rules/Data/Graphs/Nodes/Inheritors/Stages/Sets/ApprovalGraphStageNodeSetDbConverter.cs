using Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;
using Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Conditions;

namespace Edm.Entities.Approval.Rules.Infrastructure.Repositories.Rules.Contracts.Rules.Data.Graphs.Nodes.Inheritors.Stages.Sets;

internal static class ApprovalGraphStageSetDbConverter
{
    internal static ApprovalGraphStageSetDb FromDomain(ApprovalGraphStageSet set)
    {
        EntityConditionDb condition = EntityConditionDbConverter.FromDomain(set.Condition);

        string[] groupsIds = set.GroupsIds.Select(IdConverterTo.ToString).ToArray();

        var result = new ApprovalGraphStageSetDb
        {
            Condition = condition,
            GroupsIds = { groupsIds }
        };

        return result;
    }

    internal static ApprovalGraphStageSet ToDomain(ApprovalGraphStageSetDb set)
    {
        EntityCondition condition = EntityConditionDbConverter.ToDomain(set.Condition);

        Id<ApprovalGroup>[] groupsIds = set.GroupsIds.Select(IdConverterFrom<ApprovalGroup>.FromString).ToArray();

        var result = new ApprovalGraphStageSet(condition, groupsIds);

        return result;
    }
}
