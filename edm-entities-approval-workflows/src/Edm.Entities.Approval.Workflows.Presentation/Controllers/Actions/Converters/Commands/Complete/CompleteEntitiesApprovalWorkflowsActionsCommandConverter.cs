using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Complete.Reasons;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Context;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Complete.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups.Assignments.CompletionDetails.CompletionReasons;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Complete;

internal static class CompleteEntitiesApprovalWorkflowsActionsCommandConverter
{
    internal static CompleteEntitiesApprovalWorkflowsActionsCommandInternal ToInternal(CompleteEntitiesApprovalWorkflowsActionsCommand request)
    {
        ApprovalWorkflowActionContextInternal context =
            EntitiesApprovalWorkflowsActionContextDtoConverter.ToInternal(request.Context);

        ApprovalWorkflowAssignmentCompletionReasonInternal reason =
            EntitiesApprovalWorkflowAssignmentCompleteReasonDtoConverter.ToInternal(request.CompletionReason);

        var result = new CompleteEntitiesApprovalWorkflowsActionsCommandInternal(context, reason, request.Comment, request.DryRunAndLock);

        return result;
    }
}
