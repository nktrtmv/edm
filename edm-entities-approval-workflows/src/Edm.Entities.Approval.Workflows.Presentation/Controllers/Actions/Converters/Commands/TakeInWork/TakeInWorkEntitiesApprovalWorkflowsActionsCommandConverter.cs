using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Context;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.TakeInWork.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.TakeInWork;

internal static class TakeInWorkEntitiesApprovalWorkflowsActionsCommandConverter
{
    internal static TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal ToInternal(TakeInWorkEntitiesApprovalWorkflowsActionsCommand request)
    {
        ApprovalWorkflowActionContextInternal context =
            EntitiesApprovalWorkflowsActionContextDtoConverter.ToInternal(request.Context);

        var result = new TakeInWorkEntitiesApprovalWorkflowsActionsCommandInternal(context, request.DryRunAndLock);

        return result;
    }
}
