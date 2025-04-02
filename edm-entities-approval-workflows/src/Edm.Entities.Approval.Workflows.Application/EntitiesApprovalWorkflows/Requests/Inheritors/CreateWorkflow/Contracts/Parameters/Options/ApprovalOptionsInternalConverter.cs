using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;

internal static class ApprovalWorkflowOptionsInternalConverter
{
    internal static ApprovalWorkflowOptions ToDomain(ApprovalOptionsInternal options)
    {
        Id<Employee>[] watchersIds = options.WatchersIds.Select(IdConverterFrom<Employee>.From).ToArray();

        var result = new ApprovalWorkflowOptions(
            options.ApprovingWithRemarkIsDisabled,
            options.AutoInProgressAssignmentsIsDisabled,
            options.AutoDelegatingIsDisabled,
            watchersIds);

        return result;
    }
}
