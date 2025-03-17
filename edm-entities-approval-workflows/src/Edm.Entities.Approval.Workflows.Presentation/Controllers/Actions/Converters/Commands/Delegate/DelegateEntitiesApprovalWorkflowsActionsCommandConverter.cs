using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Context;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Delegate.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.Delegate;

internal static class DelegateEntitiesApprovalWorkflowsActionsCommandConverter
{
    internal static DelegateEntitiesApprovalWorkflowsActionsCommandInternal ToInternal(DelegateEntitiesApprovalWorkflowsActionsCommand request)
    {
        ApprovalWorkflowActionContextInternal context =
            EntitiesApprovalWorkflowsActionContextDtoConverter.ToInternal(request.Context);

        Id<EmployeeInternal> executorFromId = IdConverterFrom<EmployeeInternal>.FromString(request.ExecutorFromId);

        Id<EmployeeInternal> executorToId = IdConverterFrom<EmployeeInternal>.FromString(request.ExecutorToId);

        var result = new DelegateEntitiesApprovalWorkflowsActionsCommandInternal(context, executorFromId, executorToId, request.Comment, request.DryRunAndLock);

        return result;
    }
}
