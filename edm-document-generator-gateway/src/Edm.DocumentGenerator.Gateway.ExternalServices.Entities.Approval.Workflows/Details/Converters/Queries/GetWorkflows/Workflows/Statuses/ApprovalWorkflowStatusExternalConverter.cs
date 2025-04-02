using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.DocumentGenerator.Gateway.ExternalServices.EntitiesApprovalWorkflows.Details.Contracts.Queries.GetWorkflows.Workflows.Statuses;
using Edm.DocumentGenerator.Gateway.GenericSubdomain.Exceptions.Arguments;

namespace Edm.DocumentGenerator.Gateway.ExternalServices.Entities.Approval.Workflows.Details.Converters.Queries.GetWorkflows.Workflows.Statuses;

internal static class ApprovalWorkflowStatusExternalConverter
{
    public static ApprovalWorkflowStatusExternal FromDto(EntitiesApprovalWorkflowStatusDto status)
    {
        var result = status switch
        {
            EntitiesApprovalWorkflowStatusDto.NotStarted => ApprovalWorkflowStatusExternal.NotStarted,
            EntitiesApprovalWorkflowStatusDto.InProgress => ApprovalWorkflowStatusExternal.InProgress,
            EntitiesApprovalWorkflowStatusDto.Approved => ApprovalWorkflowStatusExternal.Approved,
            EntitiesApprovalWorkflowStatusDto.Rejected => ApprovalWorkflowStatusExternal.Rejected,
            EntitiesApprovalWorkflowStatusDto.ReturnedToRework => ApprovalWorkflowStatusExternal.ReturnedToRework,
            EntitiesApprovalWorkflowStatusDto.ApprovedWithRemark => ApprovalWorkflowStatusExternal.ApprovedWithRemark,
            _ => throw new ArgumentTypeOutOfRangeException(status)
        };

        return result;
    }
}
