using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Groups.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Groups.
    Statuses;

internal static class EntitiesApprovalWorkflowGroupStatusBffConverter
{
    internal static EntitiesApprovalWorkflowGroupStatusBff FromExternal(EntitiesApprovalWorkflowGroupStatusExternal status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowGroupStatusExternal.NotStarted => EntitiesApprovalWorkflowGroupStatusBff.NotStarted,
            EntitiesApprovalWorkflowGroupStatusExternal.InProgress => EntitiesApprovalWorkflowGroupStatusBff.InProgress,
            EntitiesApprovalWorkflowGroupStatusExternal.Completed => EntitiesApprovalWorkflowGroupStatusBff.Completed,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
