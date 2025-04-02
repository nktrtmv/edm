using Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic.Participants;

namespace Edm.Entities.Approval.Workflows.Application.EntitiesApprovalWorkflows.Requests.Inheritors.CreateWorkflow.Contracts.Routes.Stages.Groups.Inheritors.Domestic;

public sealed class DomesticApprovalGroupInternal : ApprovalGroupInternal
{
    public DomesticApprovalGroupInternal(string name, ApprovalParticipantInternal[] participants)
        : base(name)
    {
        Participants = participants;
    }

    public ApprovalParticipantInternal[] Participants { get; }
}
