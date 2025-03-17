using Edm.Entities.Approval.Rules.Application.Internal.Contracts.Entities.Conditions;
using Edm.Entities.Approval.Rules.Application.Internal.Groups.Contracts.Groups;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Application.Internal.Graphs.Contracts.Graphs.Nodes.Inheritors.Stages.Sets;

public sealed class ApprovalGraphStageSetInternal
{
    public ApprovalGraphStageSetInternal(EntityConditionInternal condition, Id<ApprovalGroupInternal>[] groupsIds)
    {
        Condition = condition;
        GroupsIds = groupsIds;
    }

    public EntityConditionInternal Condition { get; }
    public Id<ApprovalGroupInternal>[] GroupsIds { get; private set; }
}
