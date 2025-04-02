using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Abstractions;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Delegate.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.Delegate;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.Delegate;

[UsedImplicitly]
public sealed class DelegateEntitiesApprovalWorkflowsActionsCommandInternalHandler(ApprovalWorkflowsFacade workflows)
    : SynchronousEntitiesApprovalWorkflowsActionsCommandInternalHandler<DelegateEntitiesApprovalWorkflowsActionsCommandInternal>(workflows)
{
    protected override void Process(
        DelegateEntitiesApprovalWorkflowsActionsCommandInternal command,
        ApprovalWorkflowActionContext context)
    {
        var delegateFromUserId = IdConverterFrom<Employee>.From(command.DelegateFromUserId);

        Id<Employee> delegateToUserId = IdConverterFrom<Employee>.From(command.DelegateToUserId);

        DelegateApprovalWorkflowsActionsCommandProcessor.Delegate(context, delegateFromUserId, delegateToUserId, command.Comment);
    }
}
