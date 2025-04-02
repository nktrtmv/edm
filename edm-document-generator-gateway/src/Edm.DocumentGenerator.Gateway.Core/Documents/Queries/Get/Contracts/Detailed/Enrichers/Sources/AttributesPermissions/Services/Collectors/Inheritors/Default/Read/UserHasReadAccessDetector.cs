using Edm.DocumentGenerator.Gateway.Core.Contracts.Users;
using Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Services.Workflows.Contracts;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.Enrichers.Sources.AttributesPermissions.Services.Collectors.Inheritors.Default.
    Read;

internal static class UserHasReadAccessDetector
{
    internal static bool Detect(DocumentWorkflows workflows, UserBff user)
    {
        var result = UserHasApprovalWorkflowAssignmentsInPast(workflows.Approval, user);

        return result;
    }

    private static bool UserHasApprovalWorkflowAssignmentsInPast(EntitiesApprovalWorkflowExternal[] workflows, UserBff user)
    {
        IEnumerable<EntitiesApprovalWorkflowAssignmentExternal> assignments =
            from workflow in workflows
            from stage in workflow.Stages
            from approver in stage.Groups
            from assignment in approver.Assignments
            select assignment;

        var result = assignments.Any(a => a.ExecutorId == user.Id);

        return result;
    }
}
