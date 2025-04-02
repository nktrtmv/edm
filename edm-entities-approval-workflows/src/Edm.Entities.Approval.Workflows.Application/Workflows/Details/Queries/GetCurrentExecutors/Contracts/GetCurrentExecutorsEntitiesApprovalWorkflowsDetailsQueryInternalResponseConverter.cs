using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetCurrentExecutors.Contracts;

internal static class GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter
{
    internal static GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse FromDomain(Id<Employee>[] response)
    {
        Id<EmployeeInternal>[] executors = response.Select(IdConverterFrom<EmployeeInternal>.From).ToArray();

        var result = new GetCurrentExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(executors);

        return result;
    }
}
