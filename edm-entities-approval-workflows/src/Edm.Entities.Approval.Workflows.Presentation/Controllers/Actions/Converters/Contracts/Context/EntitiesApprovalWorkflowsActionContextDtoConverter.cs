using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Details.Queries.GetWorkflows.Contracts.Workflows.Stages;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Context;

internal static class EntitiesApprovalWorkflowsActionContextDtoConverter
{
    internal static ApprovalWorkflowActionContextInternal ToInternal(EntitiesApprovalWorkflowsActionContextDto context)
    {
        Id<ApprovalWorkflowInternal> workflowId = IdConverterFrom<ApprovalWorkflowInternal>.FromString(context.WorkflowId);

        Id<ApprovalWorkflowStageInternal> stageId = IdConverterFrom<ApprovalWorkflowStageInternal>.FromString(context.StageId);

        Id<EmployeeInternal> currentUserId = IdConverterFrom<EmployeeInternal>.FromString(context.CurrentUserId);

        var result = new ApprovalWorkflowActionContextInternal(workflowId, stageId, currentUserId, context.CurrentUserIsOwner, context.CurrentUserIsAdmin);

        return result;
    }
}
