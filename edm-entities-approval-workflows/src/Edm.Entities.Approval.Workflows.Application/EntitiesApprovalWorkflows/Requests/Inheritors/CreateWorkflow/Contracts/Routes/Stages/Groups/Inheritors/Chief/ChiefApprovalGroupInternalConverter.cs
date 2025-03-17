using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Chief;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Chief;

internal static class ChiefApprovalGroupInternalConverter
{
    internal static ApprovalWorkflowChiefApprovalGroup ToDomain(Id<Employee> currentUserId)
    {
        var result = new ApprovalWorkflowChiefApprovalGroup(currentUserId);

        return result;
    }
}
