using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Abstractions;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.AddParticipant.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Services;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.Services.Actions.Processors.Actions.AddParticipant;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups;
using Edm.Entities.Approval.Workflows.Domain.Markers;
using Edm.Entities.Approval.Workflows.Domain.ValueObjects.Actions.Contexts;
using Edm.Entities.Approval.Workflows.GenericSubdomain;

using JetBrains.Annotations;

namespace Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.AddParticipant;

[UsedImplicitly]
public sealed class AddParticipantEntitiesApprovalWorkflowsActionsCommandInternalHandler(ApprovalWorkflowsFacade workflows)
    : SynchronousEntitiesApprovalWorkflowsActionsCommandInternalHandler<AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal>(workflows)
{
    protected override void Process(
        AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal command,
        ApprovalWorkflowActionContext context)
    {
        var newParticipantId = IdConverterFrom<Employee>.From(command.NewParticipantId);

        Id<ApprovalWorkflowGroup>? groupId = NullableConverter.Convert(command.GroupId, IdConverterFrom<ApprovalWorkflowGroup>.From);

        AddParticipantApprovalWorkflowsActionsCommandProcessor.Add(context, newParticipantId, groupId, command.GroupName);
    }
}
