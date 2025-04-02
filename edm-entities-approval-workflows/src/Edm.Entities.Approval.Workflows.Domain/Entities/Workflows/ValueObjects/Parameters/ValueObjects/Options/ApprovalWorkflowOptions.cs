using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;

public sealed record ApprovalWorkflowOptions(
    bool ApprovingWithRemarkIsDisabled,
    bool AutoInProgressAssignmentsIsDisabled,
    bool AutoDelegatingIsDisabled,
    Id<Employee>[] WatchersIds)
{
    public override string ToString()
    {
        return
            $"{{ ApprovingWithRemarkIsDisabled: {ApprovingWithRemarkIsDisabled}, AutoInProgressAssignmentsIsDisabled: {AutoInProgressAssignmentsIsDisabled}, AutoDelegatingIsDisabled: {AutoDelegatingIsDisabled} }}";
    }
}
