using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetAllExecutors.Contracts;

internal static class GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponseConverter
{
    internal static GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse FromDomain(Id<Employee>[] response)
    {
        Id<EmployeeInternal>[] executors = response.Select(IdConverterFrom<EmployeeInternal>.From).ToArray();

        var result = new GetAllExecutorsEntitiesApprovalWorkflowsDetailsQueryInternalResponse(executors);

        return result;
    }
}
