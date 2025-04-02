using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.CompletionDetails;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments.Statuses;

using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Details.Converters.Queries.GetWorkflows.Workflows.Stages.Groups.Assignments;

internal static class EntitiesApprovalWorkflowAssignmentDtoConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDto FromInternal(ApprovalWorkflowAssignmentInternal assignment)
    {
        var id = assignment.Id.ToString();

        var executorId = assignment.ExecutorId.ToString();

        EntitiesApprovalWorkflowAssignmentStatusDto status =
            EntitiesApprovalWorkflowAssignmentStatusDtoConverter.FromInternal(assignment.Status);

        var createdDate = UtcDateTimeConverterTo.ToTimeStamp(assignment.CreatedDate);

        EntitiesApprovalWorkflowAssignmentCompletionDetailsDto? completionDetails =
            NullableConverter.Convert(assignment.CompletionDetails, EntitiesApprovalWorkflowAssignmentCompletionDetailsDtoConverter.FromInternal);

        string? authorId = NullableConverter.Convert(assignment.AuthorId, IdConverterTo.ToString);

        var result = new EntitiesApprovalWorkflowAssignmentDto
        {
            Id = id,
            ExecutorId = executorId,
            Status = status,
            CreatedDate = createdDate,
            CompletionDetails = completionDetails,
            AuthorId = authorId,
            IsFixed = assignment.IsFixed
        };

        return result;
    }
}
