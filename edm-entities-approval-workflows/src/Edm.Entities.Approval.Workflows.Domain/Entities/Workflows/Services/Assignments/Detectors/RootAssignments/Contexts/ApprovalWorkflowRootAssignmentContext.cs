using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.Assignments;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Detectors.RootAssignments.Contexts;

public sealed record ApprovalWorkflowRootAssignmentContext(
    ApprovalWorkflowAssignment RootAssignment,
    ApprovalWorkflowAssignment AssignmentToDelegate);
