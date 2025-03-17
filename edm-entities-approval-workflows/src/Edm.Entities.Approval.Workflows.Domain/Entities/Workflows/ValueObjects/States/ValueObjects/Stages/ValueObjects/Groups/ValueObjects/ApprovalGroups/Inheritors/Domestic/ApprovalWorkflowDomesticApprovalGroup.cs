using Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic.ValueObjects.ApprovalParticipants;

namespace Edm.Entities.Approval.Workflows.Domain.Entities.Workflows.ValueObjects.States.ValueObjects.Stages.ValueObjects.Groups.ValueObjects.ApprovalGroups.Inheritors.
    Domestic;

public sealed class ApprovalWorkflowDomesticApprovalGroup : ApprovalWorkflowApprovalGroup
{
    public ApprovalWorkflowDomesticApprovalGroup(ApprovalWorkflowApprovalParticipant[] participants)
    {
        Participants = participants;
    }

    public ApprovalWorkflowApprovalParticipant[] Participants { get; }

    public override string ToString()
    {
        string participants = string.Join<ApprovalWorkflowApprovalParticipant>(", ", Participants);

        return $"{{ {BaseToString()}, Participants: [{participants}] }}";
    }
}
