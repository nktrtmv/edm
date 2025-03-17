using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.
    CompletionDetails;
using
    Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;
using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Services.Converters;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.
    Assignments;

internal static class EntitiesApprovalWorkflowAssignmentExternalConverter
{
    internal static EntitiesApprovalWorkflowAssignmentExternal FromDto(EntitiesApprovalWorkflowAssignmentDto assignment)
    {
        var status = EntitiesApprovalWorkflowAssignmentStatusExternalConverter.FromDto(assignment.Status);

        var completionDetails =
            NullableConverter.Convert(assignment.CompletionDetails, EntitiesApprovalWorkflowAssignmentCompletionDetailsExternalConverter.FromDto);

        var createdDate = assignment.CreatedDate.ToDateTime();

        var result = new EntitiesApprovalWorkflowAssignmentExternal(
            assignment.Id,
            assignment.ExecutorId,
            status,
            createdDate,
            completionDetails,
            assignment.AuthorId,
            assignment.IsFixed);

        return result;
    }
}
