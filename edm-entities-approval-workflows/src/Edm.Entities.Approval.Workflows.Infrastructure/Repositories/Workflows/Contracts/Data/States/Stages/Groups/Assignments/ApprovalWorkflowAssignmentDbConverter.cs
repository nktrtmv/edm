using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.Factories;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.
    CompletionDetails;
using
    Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments.ValueObjects.Statuses;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.CompletionDetails;
using Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments.Statuses;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.States.Stages.Groups.Assignments;

internal static class ApprovalWorkflowAssignmentDbConverter
{
    internal static ApprovalWorkflowAssignmentDb FromDomain(ApprovalWorkflowAssignment assigment)
    {
        var id = IdConverterTo.ToString(assigment.Id);

        var executorId = IdConverterTo.ToString(assigment.ExecutorId);

        ApprovalWorkflowAssignmentStatusDb status = ApprovalWorkflowAssignmentStatusDbConverter.FromDomain(assigment.Status);

        var createdDate = UtcDateTimeConverterTo.ToTimeStamp(assigment.CreatedDate);

        ApprovalWorkflowAssignmentCompletionDetailsDb? completionDetails =
            NullableConverter.Convert(assigment.CompletionDetails, ApprovalWorkflowAssignmentCompletionDetailsDbConverter.FromDomain);

        string? authorId = NullableConverter.Convert(assigment.AuthorId, IdConverterTo.ToString);

        var result = new ApprovalWorkflowAssignmentDb
        {
            Id = id,
            ExecutorId = executorId,
            Status = status,
            CreatedDate = createdDate,
            CompletionDetails = completionDetails,
            AuthorId = authorId,
            IsFixed = assigment.IsFixed
        };

        return result;
    }

    internal static ApprovalWorkflowAssignment ToDomain(ApprovalWorkflowAssignmentDb assigment)
    {
        Id<ApprovalWorkflowAssignment> id = IdConverterFrom<ApprovalWorkflowAssignment>.FromString(assigment.Id);

        Id<Employee> executorId = IdConverterFrom<Employee>.FromString(assigment.ExecutorId);

        ApprovalWorkflowAssignmentStatus status = ApprovalWorkflowAssignmentStatusDbConverter.ToDomain(assigment.Status);

        UtcDateTime<ApprovalWorkflowAssignment> createdDate =
            UtcDateTimeConverterFrom<ApprovalWorkflowAssignment>.FromTimestamp(assigment.CreatedDate);

        ApprovalWorkflowAssignmentCompletionDetails? completionDetails =
            NullableConverter.Convert(assigment.CompletionDetails, ApprovalWorkflowAssignmentCompletionDetailsDbConverter.ToDomain);

        Id<Employee>? authorId = NullableConverter.Convert(assigment.AuthorId, IdConverterFrom<Employee>.FromString);

        ApprovalWorkflowAssignment result =
            ApprovalWorkflowAssignmentFactory.CreateFromDb(id, executorId, status, createdDate, completionDetails, authorId, assigment.IsFixed);

        return result;
    }
}
