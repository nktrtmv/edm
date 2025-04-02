using Edm.Entities.Approval.Rules.Domain.Entities.Groups;
using Edm.Entities.Approval.Rules.Domain.Entities.Rules;
using Edm.Entities.Approval.Rules.Domain.ValueObjects.Entities;
using Edm.Entities.Approval.Rules.GenericSubdomain;

namespace Edm.Entities.Approval.Rules.Domain.ValueObjects.Routes.Services.Finders.Services.Builders.Contexts;

internal sealed class RouteStageBuilderContext(Entity entity, ApprovalGroup[] groups, ApprovalRule approvalRule)
{
    public Entity Entity { get; } = entity;
    public ApprovalRule ApprovalRule { get; } = approvalRule;
    private Dictionary<Id<ApprovalGroup>, ApprovalGroup> Groups { get; } = groups.ToDictionary(g => g.Id);

    internal ApprovalGroup GetRequiredGroup(Id<ApprovalGroup> id)
    {
        ApprovalGroup? result = Groups.GetValueOrDefault(id);

        if (result is not null)
        {
            return result;
        }

        throw new ApplicationException(
            $"""
             Required Approval group is not found.
             ApprovalGroupId: {id}
             """);
    }
}
