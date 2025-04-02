using Edm.Document.Searcher.Application.DocumentsDetails.Queries.GetStepper.Contracts.Steps.Inheritors.Approval.Stages.Assignments;
using Edm.Document.Searcher.GenericSubdomain;
using Edm.Document.Searcher.Presentation.Abstractions;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.
    CompletionDetails;
using Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments.Statuses;

using Google.Protobuf.WellKnownTypes;

namespace Edm.Document.Searcher.Presentation.Controllers.DocumentsDetails.Queries.GetStepper.Converters.Steps.Inheritors.Approvals.Steps.Stages.Groups.Assignments;

internal static class EntitiesApprovalWorkflowAssignmentConverter
{
    internal static EntitiesApprovalWorkflowAssignmentDto FromInternal(EntitiesApprovalWorkflowAssignmentInternal assignment)
    {
        var status = EntitiesApprovalWorkflowAssignmentStatusConverter.FromInternal(assignment.Status);
        var completionDetails = NullableConverter.Convert(assignment.CompletionDetails, EntitiesApprovalWorkflowAssignmentCompletionDetailsConverter.FromInternal);

        var result = new EntitiesApprovalWorkflowAssignmentDto
        {
            Id = assignment.Id,
            Number = assignment.Number,
            Executor = assignment.Executor ?? string.Empty,
            Status = status,
            CreatedDate = assignment.CreatedDate.ToTimestamp(),
            CompletionDetails = completionDetails,
            Author = assignment.Author ?? string.Empty,
            IsFixed = assignment.IsFixed
        };

        return result;
    }
}
