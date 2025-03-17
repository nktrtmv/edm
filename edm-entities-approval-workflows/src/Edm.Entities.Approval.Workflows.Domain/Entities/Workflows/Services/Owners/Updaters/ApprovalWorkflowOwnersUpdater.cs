using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Owners.Updaters;

public static class ApprovalWorkflowOwnersUpdater
{
    public static void Update(ApprovalWorkflow workflow, params Id<Employee>[] ownersIds)
    {
        Id<Employee>[] ownersIdsUpdated = workflow.State.OwnersIds
            .Where(id => !ownersIds.Contains(id))
            .Concat(ownersIds)
            .Distinct()
            .ToArray();

        workflow.State.SetOwnersIds(ownersIdsUpdated);
    }
}
