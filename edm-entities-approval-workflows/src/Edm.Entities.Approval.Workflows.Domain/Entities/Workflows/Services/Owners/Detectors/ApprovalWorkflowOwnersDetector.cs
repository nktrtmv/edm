using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Owners.Detectors;

internal static class ApprovalWorkflowOwnersDetector
{
    internal static bool Detect(ApprovalWorkflowActionContext context)
    {
        Id<Employee> potentialOwnerId = IdConverterFrom<Employee>.From(context.CurrentUserId);

        Id<Employee>? activeOwnerId = context.Workflow.State.OwnersIds.LastOrDefault();

        bool result = activeOwnerId == potentialOwnerId || context.CurrentUserIsOwner;

        return result;
    }
}
