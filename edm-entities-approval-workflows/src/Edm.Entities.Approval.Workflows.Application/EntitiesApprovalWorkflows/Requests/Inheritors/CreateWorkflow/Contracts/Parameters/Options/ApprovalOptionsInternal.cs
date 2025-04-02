using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;

public sealed record ApprovalOptionsInternal(
    bool ApprovingWithRemarkIsDisabled,
    bool AutoInProgressAssignmentsIsDisabled,
    bool AutoDelegatingIsDisabled,
    Id<EmployeeInternal>[] WatchersIds);
