using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Domestic;
using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.Domestic.ValueObjects.ApprovalParticipants;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

internal static class DomesticApprovalGroupInternalConverter
{
    internal static ApprovalWorkflowDomesticApprovalGroup ToDomain(DomesticApprovalGroupInternal group)
    {
        ApprovalWorkflowApprovalParticipant[] participants =
            group.Participants.Select(ApprovalParticipantInternalConverter.ToDomain).ToArray();

        var result = new ApprovalWorkflowDomesticApprovalGroup(participants);

        return result;
    }
}
