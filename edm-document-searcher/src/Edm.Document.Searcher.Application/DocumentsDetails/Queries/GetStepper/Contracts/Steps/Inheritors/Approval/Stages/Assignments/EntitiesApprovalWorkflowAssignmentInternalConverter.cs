using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.CompletionDetails;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments.Statuses;
using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Services.Enrichment.Contexts;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages;
using Edm.Document.Searcher.ExternalServices.ApprovalWorkflows.Contracts.Queries.GetWorkflow.Workflows.Stages.Groups.Assignments;
using Edm.Document.Searcher.GenericSubdomain;

namespace Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments;

internal static class EntitiesApprovalWorkflowAssignmentInternalConverter
{
    public static EntitiesApprovalWorkflowAssignmentInternal[] FromExternal(
        EntitiesApprovalWorkflowAssignmentExternal[] assignments,
        EntitiesApprovalWorkflowStageExternal stage,
        EntitiesApprovalWorkflowExternal workflow,
        DocumentConversionContext conversionContext)
    {
        var index = 1;

        var result = new List<EntitiesApprovalWorkflowAssignmentInternal>();

        foreach (var assignment in assignments)
        {
            var executor = assignment.ExecutorId;

            var status =
                EntitiesApprovalWorkflowAssignmentStatusInternalConverter.FromExternal(assignment.Status);

            var completionDetails =
                NullableConverter.Convert(assignment.CompletionDetails, EntitiesApprovalWorkflowAssignmentCompletionDetailsInternalConverter.FromExternal);

            var author = assignment.AuthorId;

            var tempParticipant = new EntitiesApprovalWorkflowAssignmentInternal(
                assignment.Id,
                index,
                executor,
                status,
                assignment.CreatedDate,
                completionDetails,
                author,
                assignment.IsFixed);

            result.Add(tempParticipant);

            index++;
        }

        return result.ToArray();
    }
}
