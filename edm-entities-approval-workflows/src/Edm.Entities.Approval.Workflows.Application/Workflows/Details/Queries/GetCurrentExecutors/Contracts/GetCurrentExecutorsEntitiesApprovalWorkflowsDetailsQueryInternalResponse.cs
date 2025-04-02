using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;

public sealed class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse
{
    internal GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(Id<EmployeeInternal>[] executors)
    {
        Executors = executors;
    }

    public Id<EmployeeInternal>[] Executors { get; }
}
