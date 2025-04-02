using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Assignments.Delegators.Auto.Contracts.ExecutorDetails;

public sealed record ApprovalWorkflowAssignmentExecutorDetails(
    Id<Employee> PotentialExecutorId,
    Id<Employee>? AvailableExecutorId);
