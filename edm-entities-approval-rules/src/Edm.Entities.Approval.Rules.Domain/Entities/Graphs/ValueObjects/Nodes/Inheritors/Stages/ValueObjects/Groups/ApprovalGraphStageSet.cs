using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Conditions;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Graphs.ValueObjects.Nodes.Inheritors.Stages.ValueObjects.Groups;

public sealed class ApprovalGraphStageSet
{
    public ApprovalGraphStageSet(EntityCondition condition, Id<ApprovalGroup>[] groupsIds)
    {
        Condition = condition;
        GroupsIds = groupsIds;
    }

    public EntityCondition Condition { get; }
    public Id<ApprovalGroup>[] GroupsIds { get; private set; }

    public override string ToString()
    {
        string groupsIds = string.Join<Id<ApprovalGroup>>(", ", GroupsIds);

        return $"{{ Condition: {Condition}, GroupsIds: [{groupsIds}] }}";
    }
}
