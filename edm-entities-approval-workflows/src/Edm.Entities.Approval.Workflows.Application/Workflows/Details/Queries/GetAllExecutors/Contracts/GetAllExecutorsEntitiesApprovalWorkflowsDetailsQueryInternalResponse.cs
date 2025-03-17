using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;

public sealed class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse
{
    internal GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(Id<EmployeeInternal>[] executors)
    {
        Executors = executors;
    }

    public Id<EmployeeInternal>[] Executors { get; }
}
