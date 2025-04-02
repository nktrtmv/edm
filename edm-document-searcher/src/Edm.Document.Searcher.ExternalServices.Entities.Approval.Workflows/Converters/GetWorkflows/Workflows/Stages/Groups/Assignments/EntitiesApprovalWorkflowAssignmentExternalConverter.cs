using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

namespace Edm.Document.Searcher.ExternalServices.Entities.Approval.Workflows.Converters.GetWorkflows.Workflows.Stages.Groups.Assignments;

public static class EntitiesApprovalWorkflowAssignmentExternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentExternal FromDto(EntitiesApprovalWorkflowAssignmentDto assignment)
    {
        EntitiesApprovalWorkflowAssignmentStatusExternal status = EntitiesApprovalWorkflowAssignmentStatusExternalConverter.FromDto(assignment.Status);
        EntitiesApprovalWorkflowAssignmentCompletionDetailsExternal? completionDetails = EntitiesApprovalWorkflowAssignmentCompletionDetailsExternalConverter.FromDto(assignment.CompletionDetails);

        var result = new EntitiesApprovalWorkflowAssignmentExternal(
            assignment.Id,
            assignment.ExecutorId,
            status,
            assignment.CreatedDate.ToDateTime(),
            completionDetails,
            assignment.AuthorId,
            assignment.IsFixed);

        return result;
    }
}
