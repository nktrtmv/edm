using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.Statuses;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments;

internal static class ApprovalWorkflowAssignmentInternalConverter
{
    internal static ApprovalWorkflowAssignmentInternal FromDomain(ApprovalWorkflowAssignment assignment)
    {
        Id<ApprovalWorkflowAssignmentInternal> id =
            IdConverterFrom<ApprovalWorkflowAssignmentInternal>.From(assignment.Id);

        Id<EmployeeInternal> executorId =
            IdConverterFrom<EmployeeInternal>.From(assignment.ExecutorId);

        ApprovalWorkflowAssignmentStatusInternal status =
            ApprovalWorkflowAssignmentStatusInternalConverter.FromDomain(assignment.Status);

        UtcDateTime<ApprovalWorkflowAssignmentInternal> createDate =
            UtcDateTimeConverterFrom<ApprovalWorkflowAssignmentInternal>.From(assignment.CreatedDate);

        ApprovalWorkflowAssignmentCompletionDetailsInternal? completionDetails =
            NullableConverter.Convert(assignment.CompletionDetails, ApprovalWorkflowAssignmentCompletionDetailsInternalConverter.FromDomain);

        Id<EmployeeInternal>? authorId = NullableConverter.Convert(assignment.AuthorId, IdConverterFrom<EmployeeInternal>.From);

        bool isFixed = assignment.IsFixed;

        var result = new ApprovalWorkflowAssignmentInternal(
            id,
            executorId,
            status,
            createDate,
            completionDetails,
            authorId,
            isFixed);

        return result;
    }
}
