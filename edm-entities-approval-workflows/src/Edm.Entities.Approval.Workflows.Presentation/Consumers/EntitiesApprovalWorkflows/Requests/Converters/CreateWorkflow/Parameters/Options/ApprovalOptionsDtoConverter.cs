using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Parameters.Options;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Parameters.Options;

internal static class ApprovalOptionsDtoConverter
{
    internal static ApprovalOptionsInternal ToInternal(ApprovalOptionsDto options)
    {
        Id<EmployeeInternal>[] watchersIds = options.WatchersIds.Select(IdConverterFrom<EmployeeInternal>.FromString).ToArray();

        var result = new ApprovalOptionsInternal(
            options.ApprovingWithRemarkIsDisabled,
            options.AutoInProgressAssignmentsIsDisabled,
            options.AutoDelegatingIsDisabled,
            watchersIds);

        return result;
    }
}
