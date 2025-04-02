using Edm.Entities.Approval.Workflows.Presentation.Abstractions;
using Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Domestic.Participants;

using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic;
using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Workflows.Presentation.Consumers.EntitiesApprovalWorkflows.Requests.Converters.CreateWorkflow.Routes.Stages.Groups.Domestic;

internal static class DomesticApprovalRouteGroupDtoConverter
{
    internal static ApprovalGroupInternal ToInternal(DomesticApprovalRouteGroupDto group, string name)
    {
        ApprovalParticipantInternal[] participants =
            group.Participants.Select(ApprovalRouteParticipantDtoConverter.ToInternal).ToArray();

        var result = new DomesticApprovalGroupInternal(name, participants);

        return result;
    }
}
