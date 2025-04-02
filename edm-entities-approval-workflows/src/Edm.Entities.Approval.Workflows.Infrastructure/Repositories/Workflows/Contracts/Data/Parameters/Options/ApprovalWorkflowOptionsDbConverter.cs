using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.Parameters.ValueObjects.Options;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

namespace Edm.Entities.Approval.Workflows.Infrastructure.Repositories.Workflows.Contracts.Data.Parameters.Options;

internal static class ApprovalWorkflowOptionsDbConverter
{
    internal static ApprovalWorkflowOptionsDb FromDomain(ApprovalWorkflowOptions options)
    {
        string[] watchersIds = options.WatchersIds.Select(IdConverterTo.ToString).ToArray();

        var result = new ApprovalWorkflowOptionsDb
        {
            ApprovingWithRemarkIsDisabled = options.ApprovingWithRemarkIsDisabled,
            AutoInProgressAssignmentsIsDisabled = options.AutoInProgressAssignmentsIsDisabled,
            AutoDelegatingIsDisabled = options.AutoDelegatingIsDisabled,
            WatchersIds = { watchersIds }
        };

        return result;
    }

    internal static ApprovalWorkflowOptions ToDomain(ApprovalWorkflowOptionsDb options)
    {
        Id<Employee>[] watchersIds = options.WatchersIds?.Select(IdConverterFrom<Employee>.FromString).ToArray() ?? [];

        var result = new ApprovalWorkflowOptions(
            options.ApprovingWithRemarkIsDisabled,
            options.AutoInProgressAssignmentsIsDisabled,
            options.AutoDelegatingIsDisabled,
            watchersIds);

        return result;
    }
}
