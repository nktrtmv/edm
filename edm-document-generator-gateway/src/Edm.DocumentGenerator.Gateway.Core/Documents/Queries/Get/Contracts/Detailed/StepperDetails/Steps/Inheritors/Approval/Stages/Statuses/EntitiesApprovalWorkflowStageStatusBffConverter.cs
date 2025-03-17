using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Stages.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.Core.Documents.Queries.Get.Contracts.Detailed.StepperDetails.Steps.Inheritors.Approval.Stages.Statuses;

internal static class EntitiesApprovalWorkflowStageStatusBffConverter
{
    public static EntitiesApprovalWorkflowStageStatusBff FromExternal(EntitiesApprovalWorkflowStageStatusExternal status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowStageStatusExternal.InProgress => EntitiesApprovalWorkflowStageStatusBff.InProgress,
            EntitiesApprovalWorkflowStageStatusExternal.NotStarted => EntitiesApprovalWorkflowStageStatusBff.NotStarted,
            EntitiesApprovalWorkflowStageStatusExternal.Approved => EntitiesApprovalWorkflowStageStatusBff.Approved,
            EntitiesApprovalWorkflowStageStatusExternal.Rejected => EntitiesApprovalWorkflowStageStatusBff.Rejected,
            EntitiesApprovalWorkflowStageStatusExternal.ApprovedWithRemark => EntitiesApprovalWorkflowStageStatusBff.ApprovedWithRemark,
            EntitiesApprovalWorkflowStageStatusExternal.ReturnedToRework => EntitiesApprovalWorkflowStageStatusBff.ReturnedToRework,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
