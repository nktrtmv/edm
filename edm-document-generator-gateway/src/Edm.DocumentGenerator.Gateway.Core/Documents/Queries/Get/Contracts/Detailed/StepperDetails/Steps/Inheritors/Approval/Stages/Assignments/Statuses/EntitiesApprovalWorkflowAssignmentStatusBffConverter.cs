using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Assignments.
    Statuses;

internal static class EntitiesApprovalWorkflowAssignmentStatusBffConverter
{
    public static EntitiesApprovalWorkflowAssignmentStatusBff FromExternal(EntitiesApprovalWorkflowAssignmentStatusExternal status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowAssignmentStatusExternal.NotStarted => EntitiesApprovalWorkflowAssignmentStatusBff.NotStarted,
            EntitiesApprovalWorkflowAssignmentStatusExternal.InProgress => EntitiesApprovalWorkflowAssignmentStatusBff.InProgress,
            EntitiesApprovalWorkflowAssignmentStatusExternal.Completed => EntitiesApprovalWorkflowAssignmentStatusBff.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
