using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsUsedInGraphs;
using Edm.Entities.Approval.Rules.Domain.Entities.Groups.Services.Validators.GroupIsValid;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.Entities.Rules.Services.Updaters.Groups.Updaters;

public static class ApprovalGroupsUpdater
{
    public static void AddGroup(ApprovalRule rule, ApprovalGroup group)
    {
        GroupIsValidApprovalGroupValidator.Validate(group, rule);

        ApprovalGroup[] groups = rule.Groups.Concat(new[] { group }).ToArray();

        rule.SetGroups(groups);
    }

    public static void RemoveGroup(ApprovalRule group, Id<ApprovalGroup> groupId)
    {
        GroupIsUsedInGraphsApprovalGroupValidator.Validate(group, groupId);

        ApprovalGroup[] groups = group.Groups.Where(r => r.Id != groupId).ToArray();

        group.SetGroups(groups);
    }

    public static void UpdateGroup(ApprovalRule rule, ApprovalGroup group)
    {
        GroupIsValidApprovalGroupValidator.Validate(group, rule);

        ApprovalGroup[] groups = rule.Groups.Where(r => r.Id != group.Id).Append(group).ToArray();

        rule.SetGroups(groups);
    }
}
