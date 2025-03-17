using Edm.Entities.Approval.Workflows.GenericSubdomain;
using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Contracts.Context;

using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Commands.Inheritors.AddParticipant.Contracts;
using Edm.Entities.Approval.Workflows.Application.Workflows.Actions.Contracts.Context;
using Edm.Entities.Approval.Workflows.Application.Workflows.Contracts.Groups;
using Edm.Entities.Approval.Workflows.Application.Workflows.Markers;

namespace Edm.Entities.Approval.Workflows.Presentation.Controllers.Actions.Converters.Commands.AddParticipant;

internal static class AddParticipantEntitiesApprovalWorkflowsActionsCommandConverter
{
    internal static AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal ToInternal(AddParticipantEntitiesApprovalWorkflowsActionsCommand request)
    {
        ApprovalWorkflowActionContextInternal context =
            EntitiesApprovalWorkflowsActionContextDtoConverter.ToInternal(request.Context);

        Id<EmployeeInternal> newParticipantId =
            IdConverterFrom<EmployeeInternal>.FromString(request.NewParticipantId);

        Id<ApprovalWorkflowGroupInternal>? groupId =
            NullableConverter.Convert(request.GroupId, IdConverterFrom<ApprovalWorkflowGroupInternal>.FromString);

        var result = new AddParticipantEntitiesApprovalWorkflowsActionsCommandInternal(
            context,
            newParticipantId,
            groupId,
            request.GroupName,
            request.Comment,
            request.DryRunAndLock);

        return result;
    }
}
